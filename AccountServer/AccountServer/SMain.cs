using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using AccountServer.Networking;
using System.Drawing;
using AccountServer.AccountServer;
using AccountServer.AccountServer.Accounts;

namespace AccountServer;

public partial class SMain : Form
{
    public sealed class GameServerInfo
    {
        public string ServerName { get; set; }

        public string TicketAddressIP { get; set; }
        public ushort TicketAddressPort { get; set; }
        public string PublicAddressIP { get; set; }
        public ushort PublicAddressPort { get; set; }

        [JsonIgnore]
        public IPEndPoint TicketAddress;

        [JsonIgnore]
        public IPEndPoint PublicAddress;
    }

    public static uint TotalTickets;
    public static long TotalBytesReceived;
    public static long TotalBytesSent;

    public static SMain Instance;

    public static string PatchDirectory = Path.Combine(".", "Patches");
    public static string ServerConfigFile = Path.Combine(".", "!ServerInfo.txt");
    public static string PatchConfigFile = Path.Combine(".", "!Patch.txt");


    public static List<GameServerInfo> ServerList = new List<GameServerInfo>();

    public static string PatchFile = Path.Combine(".", "GameLogin.exe");
    public static byte[] PatchData;
    public static ulong PatchChecksum;
    public static int PatchChunks;

    public static string PublicServerInfo => string.Join("\n", ServerList.Select(x => $"{x.PublicAddressIP}:{x.PublicAddressPort}/{x.ServerName}"));

    public static char[] RandomNumberChars = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    public static Dictionary<string, DateTime> PhoneCaptchaTime = new Dictionary<string, DateTime>();
    public static Dictionary<string, string> PhoneCaptcha = new Dictionary<string, string>();

    public SMain()
    {
        InitializeComponent();
        Instance = this;

        Settings.Default.Load();
    }

    public static void UpdateServerStats()
    {
        Instance?.BeginInvoke(() =>
        {
            Instance.ExistingAccountsLabel.Text = $"Accounts: {SAccounts.AccountCount}";
            Instance.NewAccountsLabel.Text = $"New Accounts: {SAccounts.CreatedAccounts}";
            Instance.TicketsGeneratedLabel.Text = $"Tickets: {TotalTickets}";
            Instance.BytesReceivedLabel.Text = $"Bytes Received: {TotalBytesReceived}";
            Instance.BytesSentLabel.Text = $"Bytes Sent: {TotalBytesSent}";

            string gameServerProcessName = "GameServer";
            bool gameServerProcessFound = Process.GetProcessesByName(gameServerProcessName).Length > 0;
            Instance.GameServerLabel.Text = gameServerProcessFound ? "Game Server: Online" : "Game Server: Offline";
            Instance.GameServerLabel.ForeColor = gameServerProcessFound ? Color.Green : Color.Red;
        });
    }

    public static void AddLogMessage(string message)
    {
        static void AddLog(string message)
        {
            Instance.LogTextBox.AppendText($"[{DateTime.Now}] {message}\r\n");
            Instance.LogTextBox.ScrollToCaret();
        }

        if (Instance == null) return;

        if (Instance.InvokeRequired)
            Instance.BeginInvoke(() => AddLog(message));
        else
            AddLog(message);
    }

    public static string CreateVerificationCode()
    {
        var text = string.Empty;
        for (var i = 0; i < 4; i++)
        {
            text += RandomNumberChars[Random.Shared.Next(RandomNumberChars.Length)];
        }
        return text;
    }

    public static ulong CalcFileChecksum(byte[] buffer)
    {
        ulong csum = 0uL;
        foreach (var b in buffer)
            csum += b;
        return csum;
    }

    private void SMain_Load(object sender, EventArgs e)
    {

        if (!File.Exists(ServerConfigFile))
        {
            AddLogMessage("The server profile was not found, note the configuration");
        }
        if (!Directory.Exists(SAccounts.AccountDirectory))
        {
            AddLogMessage("The account configuration folder could not be found, please note the guide");
        }
        if (!File.Exists(".\\00000.pak"))
        {
            AddLogMessage("The game patch update file was not found, please check the import");
        }
        if (!File.Exists(PatchConfigFile))
        {
            AddLogMessage("The update profile was not found, please check configuration");
        }
    }

    private void FormClosing_Click(object sender, FormClosingEventArgs e)
    {
        if (MessageBox.Show("Are you sure to shut down the server?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        {
            TrayIcon.Visible = false;
            Environment.Exit(0);
            return;
        }

        e.Cancel = true;

        // Check if we're running, if not dont move to background.
        if (!SEngine.Running)
            return;

        TrayIcon.Visible = true;
        Hide();
        TrayIcon.ShowBalloonTip(1000, "", "The server has been turned to run in the background.", ToolTipIcon.Info);
    }

    private void RestoreWindow_Click(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            Visible = true;
            TrayIcon.Visible = false;
        }
    }

    private void RestoreWindowMenuItem_Click(object sender, EventArgs e)
    {
        Visible = true;
        TrayIcon.Visible = false;
    }

    private void EndProcessMenuItem_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Are you sure to shut down the server?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        {
            SEngine.StopService();
            TrayIcon.Visible = false;
            Environment.Exit(0);
        }
    }

    private void ReadPatchFile()
    {
        if (!File.Exists(PatchFile)) return;

        var buffer = File.ReadAllBytes(PatchFile);
        using var ms = new MemoryStream();
        using (var writer = new DeflateStream(ms, CompressionMode.Decompress, false))
            writer.Write(buffer, 0, buffer.Length);

        PatchData = ms.ToArray();
        PatchChecksum = CalcFileChecksum(buffer);
        PatchChunks = (int)Math.Ceiling((float)PatchData.Length / 40960f);

        AddLogMessage($"{PatchData.Length} {PatchChecksum}");
    }

    #region Start/Stop Account Server
    private void startServiceToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ReadPatchFile();

        if (ServerList.Count == 0)
            loadConfigurationToolStripMenuItem_Click(sender, e);

        if (ServerList.Count == 0)
        {
            AddLogMessage("The server configuration is empty and the startup fails");
            return;
        }
        if (SAccounts.AccountCount == 0)
        {
            loadAccountsToolStripMenuItem_Click(sender, e);
        }

        Settings.Default.Save();

        SEngine.StartService();

        if (!SEngine.Running)
            return;

        stopServiceToolStripMenuItem.Enabled = true;
        loadAccountsToolStripMenuItem.Enabled = false;
        loadConfigurationToolStripMenuItem.Enabled = false;
        startServiceToolStripMenuItem.Enabled = false;
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void stopServiceToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (!SEngine.Running)
            return;

        SEngine.StopService();

        stopServiceToolStripMenuItem.Enabled = false;
        loadAccountsToolStripMenuItem.Enabled = true;
        loadConfigurationToolStripMenuItem.Enabled = true;
        startServiceToolStripMenuItem.Enabled = true;
    }

    private void openServerConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (!File.Exists(ServerConfigFile))
        {
            AddLogMessage("The configuration file does not exist and has been created automatically");
            File.WriteAllBytes(ServerConfigFile, Array.Empty<byte>());
        }
        Process.Start("notepad.exe", ServerConfigFile);
    }
    #endregion
    private void loadConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (!File.Exists(ServerConfigFile))
            return;

        ServerList.Clear();

        try
        {
            var json = File.ReadAllText(ServerConfigFile, Encoding.UTF8);
            var settings = new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };

            ServerList = JsonConvert.DeserializeObject<List<GameServerInfo>>(json, settings);
            foreach (var server in ServerList)
            {
                server.TicketAddress = new IPEndPoint(IPAddress.Loopback, server.TicketAddressPort);
                server.PublicAddress = new IPEndPoint(IPAddress.Parse(server.PublicAddressIP), server.PublicAddressPort);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Server configuration error, parsing failed. \n\n" + ex.ToString());
            Environment.Exit(0);
        }

        AddLogMessage($"The network configuration loaded {ServerList.Count}.");
    }

    private void openAccountDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (!Directory.Exists(SAccounts.AccountDirectory))
        {
            AddLogMessage("The account directory does not exist and is automatically created");
            Directory.CreateDirectory(SAccounts.AccountDirectory);
            return;
        }

        Process.Start("explorer.exe", SAccounts.AccountDirectory);
    }

    private void loadAccountsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (!Directory.Exists(SAccounts.AccountDirectory))
        {
            AddLogMessage("The account directory does not exist and is automatically created");
            Directory.CreateDirectory(SAccounts.AccountDirectory);
            return;
        }

        SAccounts.LoadAccounts();

        AddLogMessage($"Account data loaded, the current number of accounts: {SAccounts.Accounts.Count}");
        ExistingAccountsLabel.Text = $"Accounts: {SAccounts.Accounts.Count}";
    }

    private void OpenUpdateConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (!File.Exists(PatchConfigFile))
        {
            AddLogMessage($"The configuration file does not exist and has been created automatically");
            File.WriteAllBytes(PatchConfigFile, Array.Empty<byte>());
        }
        Process.Start("notepad.exe", PatchConfigFile);
    }

    private void openPatchDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (!Directory.Exists(PatchDirectory))
        {
            AddLogMessage("The patch directory does not exist and is automatically created");
            Directory.CreateDirectory(PatchDirectory);
        }
        else
        {
            Process.Start("explorer.exe", PatchDirectory);
        }
    }

    private void LoadUpdateConfiguration(object sender, EventArgs e)
    {
        ReadPatchFile();
    }

    private void configToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ConfigForm configForm = new ConfigForm();

        configForm.ShowDialog();
    }

    private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        AccountsForm accountsForm = new AccountsForm();

        accountsForm.Show();
    }
}
