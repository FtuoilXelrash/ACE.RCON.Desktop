using System;
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

        public MainWindow()
        {
            InitializeComponent();
            this.Load += MainWindow_Load;
            this.FormClosing += MainWindow_FormClosing;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Logger.Info("Main window loaded");

            // Set default values
            txtAddress.Text = "127.0.0.1";
            txtPort.Text = "9005";
            radioWebSocket.Checked = true;

            UpdateConnectionUI(false);
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

                var connected = await rconClient.ConnectAsync(address, port, useTcp, connectionCts.Token);

                if (connected)
                {
                    // Now authenticate
                    bool authenticated = false;

                    // Try authentication based on what user entered
                    if (!string.IsNullOrWhiteSpace(txtAccountName.Text))
                    {
                        // ACE-style auth
                        authenticated = await rconClient.AuthenticateAceStyleAsync(
                            txtAccountName.Text,
                            txtPassword.Text,
                            connectionCts.Token);
                    }
                    else
                    {
                        // Rust-style auth
                        authenticated = await rconClient.AuthenticateRustStyleAsync(
                            txtPassword.Text,
                            connectionCts.Token);
                    }

                    if (authenticated)
                    {
                        lblStatus.Text = $"Connected ({rconClient.ConnectionType})";
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                        UpdateConnectionUI(true);

                        AppendLog($"[INFO] Connected to {address}:{port} via {rconClient.ConnectionType}");
                        AppendLog($"[INFO] Authenticated successfully");

                        // Send initial "hello" command to get server info
                        var response = await rconClient.SendCommandAsync("hello", connectionCts.Token);
                        if (response != null && response.IsSuccess)
                        {
                            AppendLog($"[SUCCESS] {response.Message}");
                        }
                    }
                    else
                    {
                        lblStatus.Text = "Authentication failed";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                        MessageBox.Show("Authentication failed. Please check your credentials.", "Auth Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        await DisconnectAsync();
                    }
                }
                else
                {
                    lblStatus.Text = "Connection failed";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    MessageBox.Show("Failed to connect to server. Please check the address and port.", "Connection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Connection error", ex);
                lblStatus.Text = "Error";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show($"Connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
