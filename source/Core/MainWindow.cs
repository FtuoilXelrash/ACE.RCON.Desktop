using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ACE.RCON.Desktop.RCON;
using ACE.RCON.Desktop.RCON.Models;
using ACE.RCON.Desktop.Utilities;

namespace ACE.RCON.Desktop
{
    public partial class MainWindow : Form
    {
        private AceRconClient rconClient;
        private CancellationTokenSource connectionCts;

        // Command and broadcast history
        private List<string> commandHistory = new List<string>();
        private List<string> broadcastHistory = new List<string>();
        private const int MaxHistoryItems = 50;

        // Player tracking
        private List<PlayerInfo> currentPlayers = new List<PlayerInfo>();
        private Timer playerRefreshTimer;

        // Chat messages
        private List<ChatMessage> chatMessages = new List<ChatMessage>();

        // Ban list
        private List<BannedAccount> bannedAccounts = new List<BannedAccount>();

        // Server status
        private ServerStatus serverStatus = new ServerStatus();

        // Console filters
        private HashSet<string> activeModuleFilters = new HashSet<string>();

        public MainWindow()
        {
            InitializeComponent();
            this.Load += MainWindow_Load;
            this.FormClosing += MainWindow_FormClosing;
            this.Resize += MainWindow_Resize;

            // Wire up all event handlers
            WireUpEventHandlers();
        }

        private void WireUpEventHandlers()
        {
            // Connection panel
            btnConnect.Click += btnConnect_Click;

            // Console tab
            btnSendCommand.Click += btnSendCommand_Click;
            comboCommandHistory.SelectedIndexChanged += comboCommandHistory_SelectedIndexChanged;
            txtCommand.KeyPress += txtCommand_KeyPress;
            btnSendBroadcast.Click += btnSendBroadcast_Click;
            comboBroadcastHistory.SelectedIndexChanged += comboBroadcastHistory_SelectedIndexChanged;

            // Console filters
            chkFilterACEProgram.CheckedChanged += ConsoleFilter_CheckedChanged;
            chkFilterDatabase.CheckedChanged += ConsoleFilter_CheckedChanged;
            chkFilterDatManager.CheckedChanged += ConsoleFilter_CheckedChanged;
            chkFilterEntity.CheckedChanged += ConsoleFilter_CheckedChanged;
            chkFilterEventManager.CheckedChanged += ConsoleFilter_CheckedChanged;
            chkFilterGuidManager.CheckedChanged += ConsoleFilter_CheckedChanged;
            chkFilterLandblockManager.CheckedChanged += ConsoleFilter_CheckedChanged;
            chkFilterManagers.CheckedChanged += ConsoleFilter_CheckedChanged;
            chkFilterModManager.CheckedChanged += ConsoleFilter_CheckedChanged;
            chkFilterNetwork.CheckedChanged += ConsoleFilter_CheckedChanged;
            chkFilterPlayerManager.CheckedChanged += ConsoleFilter_CheckedChanged;
            chkFilterPropertyManager.CheckedChanged += ConsoleFilter_CheckedChanged;

            // Players tab
            btnRefreshPlayers.Click += btnRefreshPlayers_Click;
            chkAutoRefreshPlayers.CheckedChanged += chkAutoRefreshPlayers_CheckedChanged;
            dataGridPlayers.SelectionChanged += dataGridPlayers_SelectionChanged;
            btnBootPlayer.Click += btnBootPlayer_Click;
            btnBanPlayer.Click += btnBanPlayer_Click;
            btnMutePlayer.Click += btnMutePlayer_Click;

            // Server Info tab - quick commands
            btnStatusCommand.Click += btnStatusCommand_Click;
            btnHelloCommand.Click += btnHelloCommand_Click;
            btnAceCommandsCommand.Click += btnAceCommandsCommand_Click;
            btnListPlayersCommand.Click += btnListPlayersCommand_Click;
            btnPopulationCommand.Click += btnPopulationCommand_Click;
            btnOpenWorldCommand.Click += btnOpenWorldCommand_Click;
            btnCloseWorldCommand.Click += btnCloseWorldCommand_Click;
            btnStopServerCommand.Click += btnStopServerCommand_Click;

            // Bans tab
            btnFetchBans.Click += btnFetchBans_Click;
            dataGridBans.SelectionChanged += dataGridBans_SelectionChanged;
            btnUnbanAccount.Click += btnUnbanAccount_Click;

            // System tray
            notifyIcon.DoubleClick += notifyIcon_DoubleClick;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Logger.Info("Main window loaded");

            // Initialize console filters (all enabled by default)
            InitializeConsoleFilters();

            // Initialize player auto-refresh timer
            playerRefreshTimer = new Timer();
            playerRefreshTimer.Interval = 30000; // 30 seconds
            playerRefreshTimer.Tick += PlayerRefreshTimer_Tick;

            // Initialize DataGridView columns
            InitializePlayerDataGrid();
            InitializeBanDataGrid();

            // Load saved settings
            LoadConnectionSettings();

            UpdateConnectionUI(false);

            // Set initial tab
            tabControl.SelectedIndex = 0;
        }

        private void InitializeConsoleFilters()
        {
            // Enable all module filters by default
            activeModuleFilters.Add("ACE.Server.Program");
            activeModuleFilters.Add("ACE.Database");
            activeModuleFilters.Add("ACE.DatLoader");
            activeModuleFilters.Add("ACE.Entity");
            activeModuleFilters.Add("ACE.Server.Managers.EventManager");
            activeModuleFilters.Add("ACE.Server.Managers.GuidManager");
            activeModuleFilters.Add("ACE.Server.Managers.LandblockManager");
            activeModuleFilters.Add("ACE.Server.Managers");
            activeModuleFilters.Add("ACE.Server.Mods");
            activeModuleFilters.Add("ACE.Server.Network");
            activeModuleFilters.Add("ACE.Server.Managers.PlayerManager");
            activeModuleFilters.Add("ACE.Server.Managers.PropertyManager");
        }

        private void InitializePlayerDataGrid()
        {
            dataGridPlayers.AutoGenerateColumns = false;
            dataGridPlayers.Columns.Clear();

            dataGridPlayers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPlayerName",
                HeaderText = "Character",
                DataPropertyName = "Name",
                Width = 150
            });

            dataGridPlayers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colAccountName",
                HeaderText = "Account",
                DataPropertyName = "AccountName",
                Width = 120
            });

            dataGridPlayers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLevel",
                HeaderText = "Level",
                DataPropertyName = "Level",
                Width = 60
            });

            dataGridPlayers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRace",
                HeaderText = "Race",
                DataPropertyName = "Race",
                Width = 80
            });

            dataGridPlayers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLocation",
                HeaderText = "Location",
                DataPropertyName = "Location",
                Width = 200,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void InitializeBanDataGrid()
        {
            dataGridBans.AutoGenerateColumns = false;
            dataGridBans.Columns.Clear();

            dataGridBans.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colBanAccount",
                HeaderText = "Account Name",
                DataPropertyName = "AccountName",
                Width = 200
            });

            dataGridBans.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colBanExpiration",
                HeaderText = "Ban Expiration",
                DataPropertyName = "BanExpiration",
                Width = 150
            });

            dataGridBans.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colBanReason",
                HeaderText = "Reason",
                DataPropertyName = "BanReason",
                Width = 300,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void LoadConnectionSettings()
        {
            try
            {
                var configFile = "data/connection.json";
                if (System.IO.File.Exists(configFile))
                {
                    var json = System.IO.File.ReadAllText(configFile);
                    var settings = Newtonsoft.Json.JsonConvert.DeserializeObject<ConnectionSettings>(json);

                    txtAddress.Text = settings.Address ?? "127.0.0.1";
                    txtPort.Text = settings.Port.ToString();
                    txtPassword.Text = settings.Password ?? "";
                    txtAccountName.Text = settings.AccountName ?? "";
                    radioTCP.Checked = settings.UseTcp;
                    radioWebSocket.Checked = !settings.UseTcp;

                    Logger.Info("Loaded connection settings");
                }
                else
                {
                    // Set defaults
                    txtAddress.Text = "127.0.0.1";
                    txtPort.Text = "9005";
                    radioWebSocket.Checked = true;
                    Logger.Info("Using default connection settings");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to load connection settings", ex);
                // Use defaults
                txtAddress.Text = "127.0.0.1";
                txtPort.Text = "9005";
                radioWebSocket.Checked = true;
            }
        }

        private void SaveConnectionSettings()
        {
            try
            {
                var settings = new ConnectionSettings
                {
                    Address = txtAddress.Text,
                    Port = int.Parse(txtPort.Text),
                    Password = txtPassword.Text,
                    AccountName = txtAccountName.Text,
                    UseTcp = radioTCP.Checked
                };

                var configDir = "data";
                if (!System.IO.Directory.Exists(configDir))
                {
                    System.IO.Directory.CreateDirectory(configDir);
                }

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText("data/connection.json", json);

                Logger.Info("Saved connection settings");
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to save connection settings", ex);
            }
        }

        private class ConnectionSettings
        {
            public string Address { get; set; }
            public int Port { get; set; }
            public string Password { get; set; }
            public string AccountName { get; set; }
            public bool UseTcp { get; set; }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rconClient != null && rconClient.IsConnected)
            {
                var result = MessageBox.Show("You are currently connected. Do you want to disconnect and exit?",
                    "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                DisconnectAsync().Wait();
            }
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (rconClient != null && rconClient.IsConnected)
            {
                await DisconnectAsync();
                return;
            }

            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please enter a server address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtPort.Text, out int port) || port < 1 || port > 65535)
            {
                MessageBox.Show("Please enter a valid port (1-65535).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await ConnectAsync(txtAddress.Text, port, radioTCP.Checked);
        }

        private async System.Threading.Tasks.Task ConnectAsync(string address, int port, bool useTcp)
        {
            try
            {
                UpdateConnectionUI(false);
                lblStatus.Text = "Connecting...";
                lblStatus.ForeColor = System.Drawing.Color.Orange;

                rconClient = new AceRconClient();

                // Subscribe to events
                rconClient.Connected += RconClient_Connected;
                rconClient.Disconnected += RconClient_Disconnected;
                rconClient.MessageReceived += RconClient_MessageReceived;
                rconClient.PlayerLogin += RconClient_PlayerLogin;
                rconClient.PlayerLogoff += RconClient_PlayerLogoff;
                rconClient.ErrorOccurred += RconClient_ErrorOccurred;

                connectionCts = new CancellationTokenSource();

                // New simplified connect and authenticate method
                var success = await rconClient.ConnectAndAuthenticateAsync(
                    address,
                    port,
                    useTcp,
                    txtPassword.Text,
                    txtAccountName.Text, // Empty for Rust-style, filled for ACE-style
                    connectionCts.Token);

                if (success)
                {
                    lblStatus.Text = $"Connected ({rconClient.ConnectionType})";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    UpdateConnectionUI(true);

                    AppendLog($"[INFO] Connected to {address}:{port} via {rconClient.ConnectionType}");
                    AppendLog($"[INFO] Authenticated successfully");

                    // Save settings for next time
                    SaveConnectionSettings();

                    // Send initial "hello" command to get server info
                    var response = await rconClient.SendCommandAsync("hello", connectionCts.Token);
                    if (response != null && response.IsSuccess)
                    {
                        AppendLog($"[SUCCESS] {response.Message}");
                    }
                }
                else
                {
                    lblStatus.Text = "Connection/Auth failed";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    MessageBox.Show("Failed to connect or authenticate. Check logs for details.\n\nMake sure:\n- Server is running\n- RCON is enabled\n- Correct password\n- For ACE auth: Account has AccessLevel >= 4",
                        "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await DisconnectAsync();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Connection error", ex);
                lblStatus.Text = "Error";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show($"Connection error: {ex.Message}\n\nCheck logs for details.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async System.Threading.Tasks.Task DisconnectAsync()
        {
            try
            {
                lblStatus.Text = "Disconnecting...";
                lblStatus.ForeColor = System.Drawing.Color.Orange;

                connectionCts?.Cancel();

                if (rconClient != null)
                {
                    await rconClient.DisconnectAsync();
                    rconClient.Dispose();
                    rconClient = null;
                }

                lblStatus.Text = "Disconnected";
                lblStatus.ForeColor = System.Drawing.Color.Gray;
                UpdateConnectionUI(false);

                AppendLog("[INFO] Disconnected from server");
            }
            catch (Exception ex)
            {
                Logger.Error("Disconnection error", ex);
                MessageBox.Show($"Disconnection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSendCommand_Click(object sender, EventArgs e)
        {
            if (rconClient == null || !rconClient.IsAuthenticated)
            {
                MessageBox.Show("Not connected or authenticated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var command = txtCommand.Text.Trim();
            if (string.IsNullOrEmpty(command))
                return;

            try
            {
                AppendLog($"[CMD] > {command}");

                // Add to command history
                AddCommandToHistory(command);

                var response = await rconClient.SendCommandAsync(command, connectionCts.Token);

                if (response != null)
                {
                    if (response.IsSuccess)
                    {
                        AppendLog($"[SUCCESS] {response.Message}");
                    }
                    else
                    {
                        AppendLog($"[ERROR] {response.Message}");
                    }
                }
                else
                {
                    AppendLog("[ERROR] No response from server (timeout)");
                }

                txtCommand.Clear();
            }
            catch (Exception ex)
            {
                Logger.Error("Command send error", ex);
                AppendLog($"[ERROR] {ex.Message}");
            }
        }

        private void txtCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSendCommand.PerformClick();
            }
        }

        private void UpdateConnectionUI(bool connected)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool>(UpdateConnectionUI), connected);
                return;
            }

            txtAddress.Enabled = !connected;
            txtPort.Enabled = !connected;
            txtPassword.Enabled = !connected;
            txtAccountName.Enabled = !connected;
            radioTCP.Enabled = !connected;
            radioWebSocket.Enabled = !connected;

            btnConnect.Text = connected ? "Disconnect" : "Connect";
            btnSendCommand.Enabled = connected;
            txtCommand.Enabled = connected;
        }

        private void AppendLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendLog), message);
                return;
            }

            var timestamp = DateTime.Now.ToString("HH:mm:ss");
            txtConsole.AppendText($"[{timestamp}] {message}{Environment.NewLine}");
            txtConsole.ScrollToCaret();
        }

        // RCON Event Handlers

        private void RconClient_Connected(object sender, EventArgs e)
        {
            Logger.Info("RCON client connected event");
        }

        private void RconClient_Disconnected(object sender, string reason)
        {
            Logger.Info($"RCON client disconnected: {reason}");
            AppendLog($"[DISCONNECTED] {reason}");

            UpdateConnectionUI(false);
            lblStatus.Text = "Disconnected";
            lblStatus.ForeColor = System.Drawing.Color.Gray;
        }

        private void RconClient_MessageReceived(object sender, RconMessageEventArgs e)
        {
            var logLevel = e.Response.GetLogLevel() ?? "INFO";
            AppendLog($"[{logLevel}] {e.Response.Message}");
        }

        private void RconClient_PlayerLogin(object sender, PlayerEventArgs e)
        {
            AppendLog($"[PLAYER] {e.PlayerEvent.PlayerName} logged in (Level {e.PlayerEvent.Level})");
        }

        private void RconClient_PlayerLogoff(object sender, PlayerEventArgs e)
        {
            AppendLog($"[PLAYER] {e.PlayerEvent.PlayerName} logged off");
        }

        private void RconClient_ErrorOccurred(object sender, Exception e)
        {
            Logger.Error("RCON error", e);
            AppendLog($"[ERROR] {e.Message}");
        }

        // ==================== CONSOLE TAB ====================

        private void comboCommandHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCommandHistory.SelectedItem != null)
            {
                txtCommand.Text = comboCommandHistory.SelectedItem.ToString();
                txtCommand.SelectAll();
                txtCommand.Focus();
            }
        }

        private void comboBroadcastHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBroadcastHistory.SelectedItem != null)
            {
                txtBroadcast.Text = comboBroadcastHistory.SelectedItem.ToString();
                txtBroadcast.SelectAll();
                txtBroadcast.Focus();
            }
        }

        private async void btnSendBroadcast_Click(object sender, EventArgs e)
        {
            if (rconClient == null || !rconClient.IsAuthenticated)
            {
                MessageBox.Show("Not connected or authenticated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var message = txtBroadcast.Text.Trim();
            if (string.IsNullOrEmpty(message))
                return;

            try
            {
                AppendLog($"[BROADCAST] {message}");

                // Send broadcast command
                var response = await rconClient.SendCommandAsync($"broadcast {message}", connectionCts.Token);

                if (response != null && response.IsSuccess)
                {
                    AppendLog($"[SUCCESS] Broadcast sent");

                    // Add to history
                    AddBroadcastToHistory(message);
                    txtBroadcast.Clear();
                }
                else
                {
                    AppendLog($"[ERROR] Failed to send broadcast");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Broadcast error", ex);
                AppendLog($"[ERROR] {ex.Message}");
            }
        }

        private void AddCommandToHistory(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                return;

            // Remove if already exists
            commandHistory.Remove(command);

            // Add to beginning
            commandHistory.Insert(0, command);

            // Limit size
            if (commandHistory.Count > MaxHistoryItems)
                commandHistory.RemoveAt(commandHistory.Count - 1);

            // Update dropdown
            RefreshCommandHistoryDropdown();
        }

        private void AddBroadcastToHistory(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return;

            broadcastHistory.Remove(message);
            broadcastHistory.Insert(0, message);

            if (broadcastHistory.Count > MaxHistoryItems)
                broadcastHistory.RemoveAt(broadcastHistory.Count - 1);

            RefreshBroadcastHistoryDropdown();
        }

        private void RefreshCommandHistoryDropdown()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(RefreshCommandHistoryDropdown));
                return;
            }

            comboCommandHistory.Items.Clear();
            foreach (var cmd in commandHistory)
            {
                comboCommandHistory.Items.Add(cmd);
            }
        }

        private void RefreshBroadcastHistoryDropdown()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(RefreshBroadcastHistoryDropdown));
                return;
            }

            comboBroadcastHistory.Items.Clear();
            foreach (var msg in broadcastHistory)
            {
                comboBroadcastHistory.Items.Add(msg);
            }
        }

        private void ConsoleFilter_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = sender as CheckBox;
            if (checkbox == null)
                return;

            string moduleName = GetModuleNameForCheckbox(checkbox);
            if (string.IsNullOrEmpty(moduleName))
                return;

            if (checkbox.Checked)
            {
                activeModuleFilters.Add(moduleName);
            }
            else
            {
                activeModuleFilters.Remove(moduleName);
            }

            Logger.Debug($"Filter {moduleName}: {checkbox.Checked}");
        }

        private string GetModuleNameForCheckbox(CheckBox checkbox)
        {
            if (checkbox == chkFilterACEProgram) return "ACE.Server.Program";
            if (checkbox == chkFilterDatabase) return "ACE.Database";
            if (checkbox == chkFilterDatManager) return "ACE.DatLoader";
            if (checkbox == chkFilterEntity) return "ACE.Entity";
            if (checkbox == chkFilterEventManager) return "ACE.Server.Managers.EventManager";
            if (checkbox == chkFilterGuidManager) return "ACE.Server.Managers.GuidManager";
            if (checkbox == chkFilterLandblockManager) return "ACE.Server.Managers.LandblockManager";
            if (checkbox == chkFilterManagers) return "ACE.Server.Managers";
            if (checkbox == chkFilterModManager) return "ACE.Server.Mods";
            if (checkbox == chkFilterNetwork) return "ACE.Server.Network";
            if (checkbox == chkFilterPlayerManager) return "ACE.Server.Managers.PlayerManager";
            if (checkbox == chkFilterPropertyManager) return "ACE.Server.Managers.PropertyManager";
            return null;
        }

        // ==================== PLAYERS TAB ====================

        private async void btnRefreshPlayers_Click(object sender, EventArgs e)
        {
            await RefreshPlayerListAsync();
        }

        private void chkAutoRefreshPlayers_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoRefreshPlayers.Checked)
            {
                playerRefreshTimer.Start();
                Logger.Info("Player auto-refresh enabled");
            }
            else
            {
                playerRefreshTimer.Stop();
                Logger.Info("Player auto-refresh disabled");
            }
        }

        private async void PlayerRefreshTimer_Tick(object sender, EventArgs e)
        {
            await RefreshPlayerListAsync();
        }

        private async System.Threading.Tasks.Task RefreshPlayerListAsync()
        {
            if (rconClient == null || !rconClient.IsAuthenticated)
                return;

            try
            {
                var response = await rconClient.SendCommandAsync("listplayers", connectionCts.Token);

                if (response != null && response.IsSuccess)
                {
                    // Parse player list from response
                    // The response.Data should contain player info
                    var players = response.GetData<List<PlayerInfo>>();

                    if (players != null)
                    {
                        UpdatePlayerList(players);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to refresh player list", ex);
            }
        }

        private void UpdatePlayerList(List<PlayerInfo> players)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<List<PlayerInfo>>(UpdatePlayerList), players);
                return;
            }

            currentPlayers = players;
            dataGridPlayers.DataSource = null;
            dataGridPlayers.DataSource = currentPlayers;

            lblPlayerCount.Text = $"Players: {currentPlayers.Count}";
        }

        private void dataGridPlayers_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dataGridPlayers.SelectedRows.Count > 0;

            btnBootPlayer.Enabled = hasSelection;
            btnBanPlayer.Enabled = hasSelection;
            btnMutePlayer.Enabled = hasSelection;

            if (hasSelection && dataGridPlayers.SelectedRows[0].DataBoundItem is PlayerInfo player)
            {
                lblSelectedPlayer.Text = $"Selected: {player.Name}";
            }
            else
            {
                lblSelectedPlayer.Text = "Selected: None";
            }
        }

        private async void btnBootPlayer_Click(object sender, EventArgs e)
        {
            if (dataGridPlayers.SelectedRows.Count == 0)
                return;

            var player = dataGridPlayers.SelectedRows[0].DataBoundItem as PlayerInfo;
            if (player == null)
                return;

            var result = MessageBox.Show(
                $"Boot player '{player.Name}'?\n\nThis will disconnect them from the server.",
                "Confirm Boot",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                var response = await rconClient.SendCommandAsync($"boot char {player.Name}", connectionCts.Token);

                if (response != null && response.IsSuccess)
                {
                    AppendLog($"[SUCCESS] Booted player: {player.Name}");
                    await RefreshPlayerListAsync();
                }
                else
                {
                    AppendLog($"[ERROR] Failed to boot player: {player.Name}");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Boot player error", ex);
                MessageBox.Show($"Error booting player: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnBanPlayer_Click(object sender, EventArgs e)
        {
            if (dataGridPlayers.SelectedRows.Count == 0)
                return;

            var player = dataGridPlayers.SelectedRows[0].DataBoundItem as PlayerInfo;
            if (player == null || string.IsNullOrEmpty(player.AccountName))
                return;

            var result = MessageBox.Show(
                $"Ban account '{player.AccountName}' (character: {player.Name})?\n\nThis will permanently ban the account.",
                "Confirm Ban",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                var response = await rconClient.SendCommandAsync($"ban {player.AccountName}", connectionCts.Token);

                if (response != null && response.IsSuccess)
                {
                    AppendLog($"[SUCCESS] Banned account: {player.AccountName}");
                    await RefreshPlayerListAsync();
                }
                else
                {
                    AppendLog($"[ERROR] Failed to ban account: {player.AccountName}");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Ban player error", ex);
                MessageBox.Show($"Error banning player: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnMutePlayer_Click(object sender, EventArgs e)
        {
            if (dataGridPlayers.SelectedRows.Count == 0)
                return;

            var player = dataGridPlayers.SelectedRows[0].DataBoundItem as PlayerInfo;
            if (player == null)
                return;

            var result = MessageBox.Show(
                $"Mute player '{player.Name}'?\n\nThis will prevent them from using chat.",
                "Confirm Mute",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                var response = await rconClient.SendCommandAsync($"gag {player.Name}", connectionCts.Token);

                if (response != null && response.IsSuccess)
                {
                    AppendLog($"[SUCCESS] Muted player: {player.Name}");
                }
                else
                {
                    AppendLog($"[ERROR] Failed to mute player: {player.Name}");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Mute player error", ex);
                MessageBox.Show($"Error muting player: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== SERVER INFO TAB ====================

        private async void btnStatusCommand_Click(object sender, EventArgs e)
        {
            await SendQuickCommandAsync("status");
        }

        private async void btnHelloCommand_Click(object sender, EventArgs e)
        {
            await SendQuickCommandAsync("hello");
        }

        private async void btnAceCommandsCommand_Click(object sender, EventArgs e)
        {
            await SendQuickCommandAsync("acecommands");
        }

        private async void btnListPlayersCommand_Click(object sender, EventArgs e)
        {
            await SendQuickCommandAsync("listplayers");
        }

        private async void btnPopulationCommand_Click(object sender, EventArgs e)
        {
            await SendQuickCommandAsync("pop");
        }

        private async void btnOpenWorldCommand_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Open the server to new connections?",
                "Confirm Open World",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                await SendQuickCommandAsync("world-open");
            }
        }

        private async void btnCloseWorldCommand_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Close the server to new connections?\n\nExisting players will remain connected.",
                "Confirm Close World",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                await SendQuickCommandAsync("world-closed");
            }
        }

        private async void btnStopServerCommand_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "STOP THE SERVER NOW?\n\nThis will immediately shut down the server and disconnect all players!\n\nAre you absolutely sure?",
                "CONFIRM STOP SERVER",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop);

            if (result == DialogResult.Yes)
            {
                await SendQuickCommandAsync("stop now");
            }
        }

        private async System.Threading.Tasks.Task SendQuickCommandAsync(string command)
        {
            if (rconClient == null || !rconClient.IsAuthenticated)
            {
                MessageBox.Show("Not connected or authenticated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                AppendLog($"[CMD] > {command}");
                var response = await rconClient.SendCommandAsync(command, connectionCts.Token);

                if (response != null)
                {
                    if (response.IsSuccess)
                    {
                        AppendLog($"[SUCCESS] {response.Message}");
                    }
                    else
                    {
                        AppendLog($"[ERROR] {response.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Quick command error", ex);
                AppendLog($"[ERROR] {ex.Message}");
            }
        }

        private void UpdateServerInfo(ServerStatus status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<ServerStatus>(UpdateServerInfo), status);
                return;
            }

            serverStatus = status;

            lblServerStatus.Text = $"Status: {status.Status ?? "Unknown"}";
            lblServerPlayers.Text = $"Players: {status.CurrentPlayers}/{status.MaxPlayers}";
            lblServerUptime.Text = $"Uptime: {status.GetFormattedUptime()}";
            lblAceVersion.Text = $"ACE Version: {status.AceServerVersion ?? "Unknown"}";
            lblDatabaseBaseVersion.Text = $"Base Version: {status.DatabaseBaseVersion ?? "Unknown"}";
            lblDatabasePatchVersion.Text = $"Patch Version: {status.DatabasePatchVersion ?? "Unknown"}";
        }

        // ==================== BANS TAB ====================

        private async void btnFetchBans_Click(object sender, EventArgs e)
        {
            if (rconClient == null || !rconClient.IsAuthenticated)
            {
                MessageBox.Show("Not connected or authenticated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var response = await rconClient.SendCommandAsync("listbans", connectionCts.Token);

                if (response != null && response.IsSuccess)
                {
                    var bans = response.GetData<List<BannedAccount>>();

                    if (bans != null)
                    {
                        UpdateBanList(bans);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to fetch ban list. Check logs for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Fetch bans error", ex);
                MessageBox.Show($"Error fetching bans: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateBanList(List<BannedAccount> bans)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<List<BannedAccount>>(UpdateBanList), bans);
                return;
            }

            bannedAccounts = bans;
            dataGridBans.DataSource = null;
            dataGridBans.DataSource = bannedAccounts;
        }

        private void dataGridBans_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dataGridBans.SelectedRows.Count > 0;

            btnUnbanAccount.Enabled = hasSelection;

            if (hasSelection && dataGridBans.SelectedRows[0].DataBoundItem is BannedAccount ban)
            {
                lblBanAccount.Text = $"Account: {ban.AccountName}";
                lblBanExpiration.Text = $"Expires: {ban.BanExpiration ?? "Permanent"}";
            }
            else
            {
                lblBanAccount.Text = "Account: None";
                lblBanExpiration.Text = "Expires: N/A";
            }
        }

        private async void btnUnbanAccount_Click(object sender, EventArgs e)
        {
            if (dataGridBans.SelectedRows.Count == 0)
                return;

            var ban = dataGridBans.SelectedRows[0].DataBoundItem as BannedAccount;
            if (ban == null)
                return;

            var result = MessageBox.Show(
                $"Unban account '{ban.AccountName}'?\n\nThis will allow the account to connect again.",
                "Confirm Unban",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                var response = await rconClient.SendCommandAsync($"unban {ban.AccountName}", connectionCts.Token);

                if (response != null && response.IsSuccess)
                {
                    AppendLog($"[SUCCESS] Unbanned account: {ban.AccountName}");
                    await System.Threading.Tasks.Task.Delay(500);
                    btnFetchBans.PerformClick();
                }
                else
                {
                    AppendLog($"[ERROR] Failed to unban account: {ban.AccountName}");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Unban account error", ex);
                MessageBox.Show($"Error unbanning account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== SYSTEM TRAY ====================

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(2000, "ACE RCON Desktop", "Minimized to system tray", ToolTipIcon.Info);
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            notifyIcon.Visible = false;
        }
    }
}
