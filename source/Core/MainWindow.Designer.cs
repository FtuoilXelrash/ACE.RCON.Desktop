namespace ACE.RCON.Desktop
{
    partial class MainWindow
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
            this.comboProfiles = new System.Windows.Forms.ComboBox();
            this.lblProfile = new System.Windows.Forms.Label();
            this.radioWebSocket = new System.Windows.Forms.RadioButton();
            this.radioTCP = new System.Windows.Forms.RadioButton();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabConsole = new System.Windows.Forms.TabPage();
            this.splitConsole = new System.Windows.Forms.SplitContainer();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.panelCommand = new System.Windows.Forms.Panel();
            this.comboCommandHistory = new System.Windows.Forms.ComboBox();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.lblCommand = new System.Windows.Forms.Label();
            this.panelConsoleSidebar = new System.Windows.Forms.Panel();
            this.groupBoxFilters = new System.Windows.Forms.GroupBox();
            this.chkShowModule = new System.Windows.Forms.CheckBox();
            this.chkShowTimestamp = new System.Windows.Forms.CheckBox();
            this.chkFilterPropertyManager = new System.Windows.Forms.CheckBox();
            this.chkFilterPlayerManager = new System.Windows.Forms.CheckBox();
            this.chkFilterNetwork = new System.Windows.Forms.CheckBox();
            this.chkFilterModManager = new System.Windows.Forms.CheckBox();
            this.chkFilterManagers = new System.Windows.Forms.CheckBox();
            this.chkFilterLandblockManager = new System.Windows.Forms.CheckBox();
            this.chkFilterGuidManager = new System.Windows.Forms.CheckBox();
            this.chkFilterEventManager = new System.Windows.Forms.CheckBox();
            this.chkFilterEntity = new System.Windows.Forms.CheckBox();
            this.chkFilterDatManager = new System.Windows.Forms.CheckBox();
            this.chkFilterDatabase = new System.Windows.Forms.CheckBox();
            this.chkFilterAceProgram = new System.Windows.Forms.CheckBox();
            this.tabPlayers = new System.Windows.Forms.TabPage();
            this.splitPlayers = new System.Windows.Forms.SplitContainer();
            this.dataGridPlayers = new System.Windows.Forms.DataGridView();
            this.panelPlayersTop = new System.Windows.Forms.Panel();
            this.btnRefreshPlayers = new System.Windows.Forms.Button();
            this.chkAutoRefreshPlayers = new System.Windows.Forms.CheckBox();
            this.lblPlayerCount = new System.Windows.Forms.Label();
            this.panelPlayersSidebar = new System.Windows.Forms.Panel();
            this.groupBoxPlayerActions = new System.Windows.Forms.GroupBox();
            this.btnMutePlayer = new System.Windows.Forms.Button();
            this.btnBanPlayer = new System.Windows.Forms.Button();
            this.btnBootPlayer = new System.Windows.Forms.Button();
            this.lblSelectedPlayer = new System.Windows.Forms.Label();
            this.tabChat = new System.Windows.Forms.TabPage();
            this.splitChat = new System.Windows.Forms.SplitContainer();
            this.txtChat = new System.Windows.Forms.RichTextBox();
            this.panelChatSidebar = new System.Windows.Forms.Panel();
            this.groupBoxChatFilters = new System.Windows.Forms.GroupBox();
            this.chkChatShowTimestamp = new System.Windows.Forms.CheckBox();
            this.chkChatTrade = new System.Windows.Forms.CheckBox();
            this.chkChatGuild = new System.Windows.Forms.CheckBox();
            this.chkChatGeneral = new System.Windows.Forms.CheckBox();
            this.tabServerInfo = new System.Windows.Forms.TabPage();
            this.panelServerInfo = new System.Windows.Forms.Panel();
            this.groupBoxQuickCommands = new System.Windows.Forms.GroupBox();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnCloseWorld = new System.Windows.Forms.Button();
            this.btnOpenWorld = new System.Windows.Forms.Button();
            this.btnPopulation = new System.Windows.Forms.Button();
            this.btnListPlayers = new System.Windows.Forms.Button();
            this.btnAceCommands = new System.Windows.Forms.Button();
            this.btnHello = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.groupBoxServerStatus = new System.Windows.Forms.GroupBox();
            this.lblDbPatchVersion = new System.Windows.Forms.Label();
            this.lblDbBaseVersion = new System.Windows.Forms.Label();
            this.lblAceVersion = new System.Windows.Forms.Label();
            this.lblUptime = new System.Windows.Forms.Label();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.tabBans = new System.Windows.Forms.TabPage();
            this.splitBans = new System.Windows.Forms.SplitContainer();
            this.dataGridBans = new System.Windows.Forms.DataGridView();
            this.panelBansTop = new System.Windows.Forms.Panel();
            this.btnRefreshBans = new System.Windows.Forms.Button();
            this.panelBansSidebar = new System.Windows.Forms.Panel();
            this.groupBoxBanDetails = new System.Windows.Forms.GroupBox();
            this.btnUnban = new System.Windows.Forms.Button();
            this.lblBanExpiration = new System.Windows.Forms.Label();
            this.lblBanAccount = new System.Windows.Forms.Label();
            this.tabConfiguration = new System.Windows.Forms.TabPage();
            this.panelConfiguration = new System.Windows.Forms.Panel();
            this.groupBoxDisplayOptions = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxServerSettings = new System.Windows.Forms.GroupBox();
            this.lblConfigNote = new System.Windows.Forms.Label();
            this.lblServerSettings = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBoxConnection.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitConsole)).BeginInit();
            this.splitConsole.Panel1.SuspendLayout();
            this.splitConsole.Panel2.SuspendLayout();
            this.splitConsole.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.panelConsoleSidebar.SuspendLayout();
            this.groupBoxFilters.SuspendLayout();
            this.tabPlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPlayers)).BeginInit();
            this.splitPlayers.Panel1.SuspendLayout();
            this.splitPlayers.Panel2.SuspendLayout();
            this.splitPlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPlayers)).BeginInit();
            this.panelPlayersTop.SuspendLayout();
            this.panelPlayersSidebar.SuspendLayout();
            this.groupBoxPlayerActions.SuspendLayout();
            this.tabChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitChat)).BeginInit();
            this.splitChat.Panel1.SuspendLayout();
            this.splitChat.Panel2.SuspendLayout();
            this.splitChat.SuspendLayout();
            this.panelChatSidebar.SuspendLayout();
            this.groupBoxChatFilters.SuspendLayout();
            this.tabServerInfo.SuspendLayout();
            this.panelServerInfo.SuspendLayout();
            this.groupBoxQuickCommands.SuspendLayout();
            this.groupBoxServerStatus.SuspendLayout();
            this.tabBans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitBans)).BeginInit();
            this.splitBans.Panel1.SuspendLayout();
            this.splitBans.Panel2.SuspendLayout();
            this.splitBans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBans)).BeginInit();
            this.panelBansTop.SuspendLayout();
            this.panelBansSidebar.SuspendLayout();
            this.groupBoxBanDetails.SuspendLayout();
            this.tabConfiguration.SuspendLayout();
            this.panelConfiguration.SuspendLayout();
            this.groupBoxDisplayOptions.SuspendLayout();
            this.groupBoxServerSettings.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            //
            // groupBoxConnection
            //
            this.groupBoxConnection.Controls.Add(this.comboProfiles);
            this.groupBoxConnection.Controls.Add(this.lblProfile);
            this.groupBoxConnection.Controls.Add(this.radioWebSocket);
            this.groupBoxConnection.Controls.Add(this.radioTCP);
            this.groupBoxConnection.Controls.Add(this.lblStatus);
            this.groupBoxConnection.Controls.Add(this.btnConnect);
            this.groupBoxConnection.Controls.Add(this.txtAccountName);
            this.groupBoxConnection.Controls.Add(this.lblAccountName);
            this.groupBoxConnection.Controls.Add(this.txtPassword);
            this.groupBoxConnection.Controls.Add(this.lblPassword);
            this.groupBoxConnection.Controls.Add(this.txtPort);
            this.groupBoxConnection.Controls.Add(this.lblPort);
            this.groupBoxConnection.Controls.Add(this.txtAddress);
            this.groupBoxConnection.Controls.Add(this.lblAddress);
            this.groupBoxConnection.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxConnection.Location = new System.Drawing.Point(0, 0);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new System.Drawing.Size(1184, 100);
            this.groupBoxConnection.TabIndex = 0;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "Connection";
            //
            // comboProfiles
            //
            this.comboProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProfiles.FormattingEnabled = true;
            this.comboProfiles.Location = new System.Drawing.Point(430, 22);
            this.comboProfiles.Name = "comboProfiles";
            this.comboProfiles.Size = new System.Drawing.Size(200, 21);
            this.comboProfiles.TabIndex = 5;
            //
            // lblProfile
            //
            this.lblProfile.AutoSize = true;
            this.lblProfile.Location = new System.Drawing.Point(375, 25);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(39, 13);
            this.lblProfile.TabIndex = 13;
            this.lblProfile.Text = "Profile:";
            //
            // radioWebSocket
            //
            this.radioWebSocket.AutoSize = true;
            this.radioWebSocket.Location = new System.Drawing.Point(740, 48);
            this.radioWebSocket.Name = "radioWebSocket";
            this.radioWebSocket.Size = new System.Drawing.Size(82, 17);
            this.radioWebSocket.TabIndex = 7;
            this.radioWebSocket.TabStop = true;
            this.radioWebSocket.Text = "WebSocket";
            this.radioWebSocket.UseVisualStyleBackColor = true;
            //
            // radioTCP
            //
            this.radioTCP.AutoSize = true;
            this.radioTCP.Location = new System.Drawing.Point(740, 25);
            this.radioTCP.Name = "radioTCP";
            this.radioTCP.Size = new System.Drawing.Size(46, 17);
            this.radioTCP.TabIndex = 6;
            this.radioTCP.TabStop = true;
            this.radioTCP.Text = "TCP";
            this.radioTCP.UseVisualStyleBackColor = true;
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(950, 70);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(93, 15);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Disconnected";
            //
            // btnConnect
            //
            this.btnConnect.Location = new System.Drawing.Point(850, 65);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(90, 23);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            //
            // txtAccountName
            //
            this.txtAccountName.Location = new System.Drawing.Point(470, 67);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(160, 20);
            this.txtAccountName.TabIndex = 4;
            //
            // lblAccountName
            //
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Location = new System.Drawing.Point(375, 70);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(90, 13);
            this.lblAccountName.TabIndex = 7;
            this.lblAccountName.Text = "Account (ACE): ";
            //
            // txtPassword
            //
            this.txtPassword.Location = new System.Drawing.Point(115, 67);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(250, 20);
            this.txtPassword.TabIndex = 3;
            //
            // lblPassword
            //
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(15, 70);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password:";
            //
            // txtPort
            //
            this.txtPort.Location = new System.Drawing.Point(115, 48);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 2;
            //
            // lblPort
            //
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(15, 51);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Port:";
            //
            // txtAddress
            //
            this.txtAddress.Location = new System.Drawing.Point(115, 22);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(250, 20);
            this.txtAddress.TabIndex = 1;
            //
            // lblAddress
            //
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(15, 25);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(51, 13);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "Address:";
            //
            // tabControl
            //
            this.tabControl.Controls.Add(this.tabConsole);
            this.tabControl.Controls.Add(this.tabPlayers);
            this.tabControl.Controls.Add(this.tabChat);
            this.tabControl.Controls.Add(this.tabServerInfo);
            this.tabControl.Controls.Add(this.tabBans);
            this.tabControl.Controls.Add(this.tabConfiguration);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 100);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1184, 561);
            this.tabControl.TabIndex = 1;
            //
            // tabConsole
            //
            this.tabConsole.Controls.Add(this.splitConsole);
            this.tabConsole.Location = new System.Drawing.Point(4, 22);
            this.tabConsole.Name = "tabConsole";
            this.tabConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsole.Size = new System.Drawing.Size(1176, 535);
            this.tabConsole.TabIndex = 0;
            this.tabConsole.Text = "Console";
            this.tabConsole.UseVisualStyleBackColor = true;
            //
            // splitConsole
            //
            this.splitConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitConsole.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitConsole.Location = new System.Drawing.Point(3, 3);
            this.splitConsole.Name = "splitConsole";
            //
            // splitConsole.Panel1
            //
            this.splitConsole.Panel1.Controls.Add(this.txtConsole);
            this.splitConsole.Panel1.Controls.Add(this.panelCommand);
            //
            // splitConsole.Panel2
            //
            this.splitConsole.Panel2.Controls.Add(this.panelConsoleSidebar);
            this.splitConsole.Size = new System.Drawing.Size(1170, 529);
            this.splitConsole.SplitterDistance = 920;
            this.splitConsole.TabIndex = 0;
            //
            // txtConsole
            //
            this.txtConsole.BackColor = System.Drawing.Color.Black;
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtConsole.ForeColor = System.Drawing.Color.Lime;
            this.txtConsole.Location = new System.Drawing.Point(0, 0);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(920, 489);
            this.txtConsole.TabIndex = 1;
            this.txtConsole.Text = "";
            //
            // panelCommand
            //
            this.panelCommand.Controls.Add(this.comboCommandHistory);
            this.panelCommand.Controls.Add(this.btnSendCommand);
            this.panelCommand.Controls.Add(this.txtCommand);
            this.panelCommand.Controls.Add(this.lblCommand);
            this.panelCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommand.Location = new System.Drawing.Point(0, 489);
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Size = new System.Drawing.Size(920, 40);
            this.panelCommand.TabIndex = 0;
            //
            // comboCommandHistory
            //
            this.comboCommandHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboCommandHistory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCommandHistory.FormattingEnabled = true;
            this.comboCommandHistory.Location = new System.Drawing.Point(715, 10);
            this.comboCommandHistory.Name = "comboCommandHistory";
            this.comboCommandHistory.Size = new System.Drawing.Size(120, 21);
            this.comboCommandHistory.TabIndex = 3;
            //
            // btnSendCommand
            //
            this.btnSendCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendCommand.Location = new System.Drawing.Point(840, 8);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(75, 23);
            this.btnSendCommand.TabIndex = 2;
            this.btnSendCommand.Text = "Send";
            this.btnSendCommand.UseVisualStyleBackColor = true;
            this.btnSendCommand.Click += new System.EventHandler(this.btnSendCommand_Click);
            //
            // txtCommand
            //
            this.txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommand.Location = new System.Drawing.Point(75, 10);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(634, 20);
            this.txtCommand.TabIndex = 1;
            this.txtCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCommand_KeyPress);
            //
            // lblCommand
            //
            this.lblCommand.AutoSize = true;
            this.lblCommand.Location = new System.Drawing.Point(10, 13);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(57, 13);
            this.lblCommand.TabIndex = 0;
            this.lblCommand.Text = "Command:";
            //
            // panelConsoleSidebar
            //
            this.panelConsoleSidebar.Controls.Add(this.groupBoxFilters);
            this.panelConsoleSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConsoleSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelConsoleSidebar.Name = "panelConsoleSidebar";
            this.panelConsoleSidebar.Size = new System.Drawing.Size(246, 529);
            this.panelConsoleSidebar.TabIndex = 0;
            //
            // groupBoxFilters
            //
            this.groupBoxFilters.Controls.Add(this.chkShowModule);
            this.groupBoxFilters.Controls.Add(this.chkShowTimestamp);
            this.groupBoxFilters.Controls.Add(this.chkFilterPropertyManager);
            this.groupBoxFilters.Controls.Add(this.chkFilterPlayerManager);
            this.groupBoxFilters.Controls.Add(this.chkFilterNetwork);
            this.groupBoxFilters.Controls.Add(this.chkFilterModManager);
            this.groupBoxFilters.Controls.Add(this.chkFilterManagers);
            this.groupBoxFilters.Controls.Add(this.chkFilterLandblockManager);
            this.groupBoxFilters.Controls.Add(this.chkFilterGuidManager);
            this.groupBoxFilters.Controls.Add(this.chkFilterEventManager);
            this.groupBoxFilters.Controls.Add(this.chkFilterEntity);
            this.groupBoxFilters.Controls.Add(this.chkFilterDatManager);
            this.groupBoxFilters.Controls.Add(this.chkFilterDatabase);
            this.groupBoxFilters.Controls.Add(this.chkFilterAceProgram);
            this.groupBoxFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFilters.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFilters.Name = "groupBoxFilters";
            this.groupBoxFilters.Size = new System.Drawing.Size(246, 529);
            this.groupBoxFilters.TabIndex = 0;
            this.groupBoxFilters.TabStop = false;
            this.groupBoxFilters.Text = "Filters && Options";
            //
            // chkShowModule
            //
            this.chkShowModule.AutoSize = true;
            this.chkShowModule.Location = new System.Drawing.Point(10, 385);
            this.chkShowModule.Name = "chkShowModule";
            this.chkShowModule.Size = new System.Drawing.Size(122, 17);
            this.chkShowModule.TabIndex = 13;
            this.chkShowModule.Text = "Show ACE Module";
            this.chkShowModule.UseVisualStyleBackColor = true;
            //
            // chkShowTimestamp
            //
            this.chkShowTimestamp.AutoSize = true;
            this.chkShowTimestamp.Checked = true;
            this.chkShowTimestamp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowTimestamp.Location = new System.Drawing.Point(10, 365);
            this.chkShowTimestamp.Name = "chkShowTimestamp";
            this.chkShowTimestamp.Size = new System.Drawing.Size(109, 17);
            this.chkShowTimestamp.TabIndex = 12;
            this.chkShowTimestamp.Text = "Show Timestamp";
            this.chkShowTimestamp.UseVisualStyleBackColor = true;
            //
            // chkFilterPropertyManager
            //
            this.chkFilterPropertyManager.AutoSize = true;
            this.chkFilterPropertyManager.Checked = true;
            this.chkFilterPropertyManager.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterPropertyManager.Location = new System.Drawing.Point(10, 335);
            this.chkFilterPropertyManager.Name = "chkFilterPropertyManager";
            this.chkFilterPropertyManager.Size = new System.Drawing.Size(116, 17);
            this.chkFilterPropertyManager.TabIndex = 11;
            this.chkFilterPropertyManager.Text = "PropertyManager";
            this.chkFilterPropertyManager.UseVisualStyleBackColor = true;
            //
            // chkFilterPlayerManager
            //
            this.chkFilterPlayerManager.AutoSize = true;
            this.chkFilterPlayerManager.Checked = true;
            this.chkFilterPlayerManager.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterPlayerManager.Location = new System.Drawing.Point(10, 305);
            this.chkFilterPlayerManager.Name = "chkFilterPlayerManager";
            this.chkFilterPlayerManager.Size = new System.Drawing.Size(102, 17);
            this.chkFilterPlayerManager.TabIndex = 10;
            this.chkFilterPlayerManager.Text = "PlayerManager";
            this.chkFilterPlayerManager.UseVisualStyleBackColor = true;
            //
            // chkFilterNetwork
            //
            this.chkFilterNetwork.AutoSize = true;
            this.chkFilterNetwork.Checked = true;
            this.chkFilterNetwork.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterNetwork.Location = new System.Drawing.Point(10, 275);
            this.chkFilterNetwork.Name = "chkFilterNetwork";
            this.chkFilterNetwork.Size = new System.Drawing.Size(67, 17);
            this.chkFilterNetwork.TabIndex = 9;
            this.chkFilterNetwork.Text = "Network";
            this.chkFilterNetwork.UseVisualStyleBackColor = true;
            //
            // chkFilterModManager
            //
            this.chkFilterModManager.AutoSize = true;
            this.chkFilterModManager.Checked = true;
            this.chkFilterModManager.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterModManager.Location = new System.Drawing.Point(10, 245);
            this.chkFilterModManager.Name = "chkFilterModManager";
            this.chkFilterModManager.Size = new System.Drawing.Size(93, 17);
            this.chkFilterModManager.TabIndex = 8;
            this.chkFilterModManager.Text = "ModManager";
            this.chkFilterModManager.UseVisualStyleBackColor = true;
            //
            // chkFilterManagers
            //
            this.chkFilterManagers.AutoSize = true;
            this.chkFilterManagers.Checked = true;
            this.chkFilterManagers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterManagers.Location = new System.Drawing.Point(10, 215);
            this.chkFilterManagers.Name = "chkFilterManagers";
            this.chkFilterManagers.Size = new System.Drawing.Size(75, 17);
            this.chkFilterManagers.TabIndex = 7;
            this.chkFilterManagers.Text = "Managers";
            this.chkFilterManagers.UseVisualStyleBackColor = true;
            //
            // chkFilterLandblockManager
            //
            this.chkFilterLandblockManager.AutoSize = true;
            this.chkFilterLandblockManager.Checked = true;
            this.chkFilterLandblockManager.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterLandblockManager.Location = new System.Drawing.Point(10, 185);
            this.chkFilterLandblockManager.Name = "chkFilterLandblockManager";
            this.chkFilterLandblockManager.Size = new System.Drawing.Size(124, 17);
            this.chkFilterLandblockManager.TabIndex = 6;
            this.chkFilterLandblockManager.Text = "LandblockManager";
            this.chkFilterLandblockManager.UseVisualStyleBackColor = true;
            //
            // chkFilterGuidManager
            //
            this.chkFilterGuidManager.AutoSize = true;
            this.chkFilterGuidManager.Checked = true;
            this.chkFilterGuidManager.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterGuidManager.Location = new System.Drawing.Point(10, 155);
            this.chkFilterGuidManager.Name = "chkFilterGuidManager";
            this.chkFilterGuidManager.Size = new System.Drawing.Size(94, 17);
            this.chkFilterGuidManager.TabIndex = 5;
            this.chkFilterGuidManager.Text = "GuidManager";
            this.chkFilterGuidManager.UseVisualStyleBackColor = true;
            //
            // chkFilterEventManager
            //
            this.chkFilterEventManager.AutoSize = true;
            this.chkFilterEventManager.Checked = true;
            this.chkFilterEventManager.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterEventManager.Location = new System.Drawing.Point(10, 125);
            this.chkFilterEventManager.Name = "chkFilterEventManager";
            this.chkFilterEventManager.Size = new System.Drawing.Size(98, 17);
            this.chkFilterEventManager.TabIndex = 4;
            this.chkFilterEventManager.Text = "EventManager";
            this.chkFilterEventManager.UseVisualStyleBackColor = true;
            //
            // chkFilterEntity
            //
            this.chkFilterEntity.AutoSize = true;
            this.chkFilterEntity.Checked = true;
            this.chkFilterEntity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterEntity.Location = new System.Drawing.Point(10, 95);
            this.chkFilterEntity.Name = "chkFilterEntity";
            this.chkFilterEntity.Size = new System.Drawing.Size(52, 17);
            this.chkFilterEntity.TabIndex = 3;
            this.chkFilterEntity.Text = "Entity";
            this.chkFilterEntity.UseVisualStyleBackColor = true;
            //
            // chkFilterDatManager
            //
            this.chkFilterDatManager.AutoSize = true;
            this.chkFilterDatManager.Checked = true;
            this.chkFilterDatManager.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterDatManager.Location = new System.Drawing.Point(10, 65);
            this.chkFilterDatManager.Name = "chkFilterDatManager";
            this.chkFilterDatManager.Size = new System.Drawing.Size(86, 17);
            this.chkFilterDatManager.TabIndex = 2;
            this.chkFilterDatManager.Text = "DatManager";
            this.chkFilterDatManager.UseVisualStyleBackColor = true;
            //
            // chkFilterDatabase
            //
            this.chkFilterDatabase.AutoSize = true;
            this.chkFilterDatabase.Checked = true;
            this.chkFilterDatabase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterDatabase.Location = new System.Drawing.Point(10, 35);
            this.chkFilterDatabase.Name = "chkFilterDatabase";
            this.chkFilterDatabase.Size = new System.Drawing.Size(72, 17);
            this.chkFilterDatabase.TabIndex = 1;
            this.chkFilterDatabase.Text = "Database";
            this.chkFilterDatabase.UseVisualStyleBackColor = true;
            //
            // chkFilterAceProgram
            //
            this.chkFilterAceProgram.AutoSize = true;
            this.chkFilterAceProgram.Checked = true;
            this.chkFilterAceProgram.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterAceProgram.Location = new System.Drawing.Point(10, 20);
            this.chkFilterAceProgram.Name = "chkFilterAceProgram";
            this.chkFilterAceProgram.Size = new System.Drawing.Size(91, 17);
            this.chkFilterAceProgram.TabIndex = 0;
            this.chkFilterAceProgram.Text = "ACE Program";
            this.chkFilterAceProgram.UseVisualStyleBackColor = true;
            //
            // tabPlayers
            //
            this.tabPlayers.Controls.Add(this.splitPlayers);
            this.tabPlayers.Location = new System.Drawing.Point(4, 22);
            this.tabPlayers.Name = "tabPlayers";
            this.tabPlayers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlayers.Size = new System.Drawing.Size(1176, 535);
            this.tabPlayers.TabIndex = 1;
            this.tabPlayers.Text = "Players";
            this.tabPlayers.UseVisualStyleBackColor = true;
            //
            // splitPlayers
            //
            this.splitPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPlayers.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitPlayers.Location = new System.Drawing.Point(3, 3);
            this.splitPlayers.Name = "splitPlayers";
            //
            // splitPlayers.Panel1
            //
            this.splitPlayers.Panel1.Controls.Add(this.dataGridPlayers);
            this.splitPlayers.Panel1.Controls.Add(this.panelPlayersTop);
            //
            // splitPlayers.Panel2
            //
            this.splitPlayers.Panel2.Controls.Add(this.panelPlayersSidebar);
            this.splitPlayers.Size = new System.Drawing.Size(1170, 529);
            this.splitPlayers.SplitterDistance = 920;
            this.splitPlayers.TabIndex = 0;
            //
            // dataGridPlayers
            //
            this.dataGridPlayers.AllowUserToAddRows = false;
            this.dataGridPlayers.AllowUserToDeleteRows = false;
            this.dataGridPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPlayers.Location = new System.Drawing.Point(0, 40);
            this.dataGridPlayers.MultiSelect = false;
            this.dataGridPlayers.Name = "dataGridPlayers";
            this.dataGridPlayers.ReadOnly = true;
            this.dataGridPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridPlayers.Size = new System.Drawing.Size(920, 489);
            this.dataGridPlayers.TabIndex = 1;
            //
            // panelPlayersTop
            //
            this.panelPlayersTop.Controls.Add(this.btnRefreshPlayers);
            this.panelPlayersTop.Controls.Add(this.chkAutoRefreshPlayers);
            this.panelPlayersTop.Controls.Add(this.lblPlayerCount);
            this.panelPlayersTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPlayersTop.Location = new System.Drawing.Point(0, 0);
            this.panelPlayersTop.Name = "panelPlayersTop";
            this.panelPlayersTop.Size = new System.Drawing.Size(920, 40);
            this.panelPlayersTop.TabIndex = 0;
            //
            // btnRefreshPlayers
            //
            this.btnRefreshPlayers.Location = new System.Drawing.Point(10, 8);
            this.btnRefreshPlayers.Name = "btnRefreshPlayers";
            this.btnRefreshPlayers.Size = new System.Drawing.Size(90, 23);
            this.btnRefreshPlayers.TabIndex = 0;
            this.btnRefreshPlayers.Text = "Refresh";
            this.btnRefreshPlayers.UseVisualStyleBackColor = true;
            //
            // chkAutoRefreshPlayers
            //
            this.chkAutoRefreshPlayers.AutoSize = true;
            this.chkAutoRefreshPlayers.Checked = true;
            this.chkAutoRefreshPlayers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoRefreshPlayers.Location = new System.Drawing.Point(110, 12);
            this.chkAutoRefreshPlayers.Name = "chkAutoRefreshPlayers";
            this.chkAutoRefreshPlayers.Size = new System.Drawing.Size(86, 17);
            this.chkAutoRefreshPlayers.TabIndex = 1;
            this.chkAutoRefreshPlayers.Text = "Auto-Refresh";
            this.chkAutoRefreshPlayers.UseVisualStyleBackColor = true;
            //
            // lblPlayerCount
            //
            this.lblPlayerCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlayerCount.AutoSize = true;
            this.lblPlayerCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblPlayerCount.Location = new System.Drawing.Point(800, 12);
            this.lblPlayerCount.Name = "lblPlayerCount";
            this.lblPlayerCount.Size = new System.Drawing.Size(110, 15);
            this.lblPlayerCount.TabIndex = 2;
            this.lblPlayerCount.Text = "0 players online";
            //
            // panelPlayersSidebar
            //
            this.panelPlayersSidebar.Controls.Add(this.groupBoxPlayerActions);
            this.panelPlayersSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPlayersSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelPlayersSidebar.Name = "panelPlayersSidebar";
            this.panelPlayersSidebar.Size = new System.Drawing.Size(246, 529);
            this.panelPlayersSidebar.TabIndex = 0;
            //
            // groupBoxPlayerActions
            //
            this.groupBoxPlayerActions.Controls.Add(this.btnMutePlayer);
            this.groupBoxPlayerActions.Controls.Add(this.btnBanPlayer);
            this.groupBoxPlayerActions.Controls.Add(this.btnBootPlayer);
            this.groupBoxPlayerActions.Controls.Add(this.lblSelectedPlayer);
            this.groupBoxPlayerActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPlayerActions.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPlayerActions.Name = "groupBoxPlayerActions";
            this.groupBoxPlayerActions.Size = new System.Drawing.Size(246, 529);
            this.groupBoxPlayerActions.TabIndex = 0;
            this.groupBoxPlayerActions.TabStop = false;
            this.groupBoxPlayerActions.Text = "Player Actions";
            //
            // btnMutePlayer
            //
            this.btnMutePlayer.Enabled = false;
            this.btnMutePlayer.Location = new System.Drawing.Point(10, 130);
            this.btnMutePlayer.Name = "btnMutePlayer";
            this.btnMutePlayer.Size = new System.Drawing.Size(220, 30);
            this.btnMutePlayer.TabIndex = 3;
            this.btnMutePlayer.Text = "Mute Player";
            this.btnMutePlayer.UseVisualStyleBackColor = true;
            //
            // btnBanPlayer
            //
            this.btnBanPlayer.Enabled = false;
            this.btnBanPlayer.Location = new System.Drawing.Point(10, 90);
            this.btnBanPlayer.Name = "btnBanPlayer";
            this.btnBanPlayer.Size = new System.Drawing.Size(220, 30);
            this.btnBanPlayer.TabIndex = 2;
            this.btnBanPlayer.Text = "Ban Player";
            this.btnBanPlayer.UseVisualStyleBackColor = true;
            //
            // btnBootPlayer
            //
            this.btnBootPlayer.Enabled = false;
            this.btnBootPlayer.Location = new System.Drawing.Point(10, 50);
            this.btnBootPlayer.Name = "btnBootPlayer";
            this.btnBootPlayer.Size = new System.Drawing.Size(220, 30);
            this.btnBootPlayer.TabIndex = 1;
            this.btnBootPlayer.Text = "Boot Player (Kick)";
            this.btnBootPlayer.UseVisualStyleBackColor = true;
            //
            // lblSelectedPlayer
            //
            this.lblSelectedPlayer.AutoSize = true;
            this.lblSelectedPlayer.Location = new System.Drawing.Point(10, 25);
            this.lblSelectedPlayer.Name = "lblSelectedPlayer";
            this.lblSelectedPlayer.Size = new System.Drawing.Size(103, 13);
            this.lblSelectedPlayer.TabIndex = 0;
            this.lblSelectedPlayer.Text = "No player selected";
            //
            // tabChat
            //
            this.tabChat.Controls.Add(this.splitChat);
            this.tabChat.Location = new System.Drawing.Point(4, 22);
            this.tabChat.Name = "tabChat";
            this.tabChat.Size = new System.Drawing.Size(1176, 535);
            this.tabChat.TabIndex = 2;
            this.tabChat.Text = "Server Chat";
            this.tabChat.UseVisualStyleBackColor = true;
            //
            // splitChat
            //
            this.splitChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitChat.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitChat.Location = new System.Drawing.Point(0, 0);
            this.splitChat.Name = "splitChat";
            //
            // splitChat.Panel1
            //
            this.splitChat.Panel1.Controls.Add(this.txtChat);
            //
            // splitChat.Panel2
            //
            this.splitChat.Panel2.Controls.Add(this.panelChatSidebar);
            this.splitChat.Size = new System.Drawing.Size(1176, 535);
            this.splitChat.SplitterDistance = 926;
            this.splitChat.TabIndex = 0;
            //
            // txtChat
            //
            this.txtChat.BackColor = System.Drawing.Color.Black;
            this.txtChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChat.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtChat.ForeColor = System.Drawing.Color.Lime;
            this.txtChat.Location = new System.Drawing.Point(0, 0);
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.Size = new System.Drawing.Size(926, 535);
            this.txtChat.TabIndex = 0;
            this.txtChat.Text = "";
            //
            // panelChatSidebar
            //
            this.panelChatSidebar.Controls.Add(this.groupBoxChatFilters);
            this.panelChatSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChatSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelChatSidebar.Name = "panelChatSidebar";
            this.panelChatSidebar.Size = new System.Drawing.Size(246, 535);
            this.panelChatSidebar.TabIndex = 0;
            //
            // groupBoxChatFilters
            //
            this.groupBoxChatFilters.Controls.Add(this.chkChatShowTimestamp);
            this.groupBoxChatFilters.Controls.Add(this.chkChatTrade);
            this.groupBoxChatFilters.Controls.Add(this.chkChatGuild);
            this.groupBoxChatFilters.Controls.Add(this.chkChatGeneral);
            this.groupBoxChatFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxChatFilters.Location = new System.Drawing.Point(0, 0);
            this.groupBoxChatFilters.Name = "groupBoxChatFilters";
            this.groupBoxChatFilters.Size = new System.Drawing.Size(246, 535);
            this.groupBoxChatFilters.TabIndex = 0;
            this.groupBoxChatFilters.TabStop = false;
            this.groupBoxChatFilters.Text = "Chat Filters";
            //
            // chkChatShowTimestamp
            //
            this.chkChatShowTimestamp.AutoSize = true;
            this.chkChatShowTimestamp.Checked = true;
            this.chkChatShowTimestamp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChatShowTimestamp.Location = new System.Drawing.Point(10, 125);
            this.chkChatShowTimestamp.Name = "chkChatShowTimestamp";
            this.chkChatShowTimestamp.Size = new System.Drawing.Size(109, 17);
            this.chkChatShowTimestamp.TabIndex = 3;
            this.chkChatShowTimestamp.Text = "Show Timestamp";
            this.chkChatShowTimestamp.UseVisualStyleBackColor = true;
            //
            // chkChatTrade
            //
            this.chkChatTrade.AutoSize = true;
            this.chkChatTrade.Checked = true;
            this.chkChatTrade.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChatTrade.Location = new System.Drawing.Point(10, 80);
            this.chkChatTrade.Name = "chkChatTrade";
            this.chkChatTrade.Size = new System.Drawing.Size(56, 17);
            this.chkChatTrade.TabIndex = 2;
            this.chkChatTrade.Text = "Trade";
            this.chkChatTrade.UseVisualStyleBackColor = true;
            //
            // chkChatGuild
            //
            this.chkChatGuild.AutoSize = true;
            this.chkChatGuild.Checked = true;
            this.chkChatGuild.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChatGuild.Location = new System.Drawing.Point(10, 50);
            this.chkChatGuild.Name = "chkChatGuild";
            this.chkChatGuild.Size = new System.Drawing.Size(105, 17);
            this.chkChatGuild.TabIndex = 1;
            this.chkChatGuild.Text = "Guild (Allegiance)";
            this.chkChatGuild.UseVisualStyleBackColor = true;
            //
            // chkChatGeneral
            //
            this.chkChatGeneral.AutoSize = true;
            this.chkChatGeneral.Checked = true;
            this.chkChatGeneral.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChatGeneral.Location = new System.Drawing.Point(10, 20);
            this.chkChatGeneral.Name = "chkChatGeneral";
            this.chkChatGeneral.Size = new System.Drawing.Size(63, 17);
            this.chkChatGeneral.TabIndex = 0;
            this.chkChatGeneral.Text = "General";
            this.chkChatGeneral.UseVisualStyleBackColor = true;
            //
            // tabServerInfo
            //
            this.tabServerInfo.Controls.Add(this.panelServerInfo);
            this.tabServerInfo.Location = new System.Drawing.Point(4, 22);
            this.tabServerInfo.Name = "tabServerInfo";
            this.tabServerInfo.Size = new System.Drawing.Size(1176, 535);
            this.tabServerInfo.TabIndex = 3;
            this.tabServerInfo.Text = "Server Info";
            this.tabServerInfo.UseVisualStyleBackColor = true;
            //
            // panelServerInfo
            //
            this.panelServerInfo.Controls.Add(this.groupBoxQuickCommands);
            this.panelServerInfo.Controls.Add(this.groupBoxServerStatus);
            this.panelServerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelServerInfo.Location = new System.Drawing.Point(0, 0);
            this.panelServerInfo.Name = "panelServerInfo";
            this.panelServerInfo.Padding = new System.Windows.Forms.Padding(10);
            this.panelServerInfo.Size = new System.Drawing.Size(1176, 535);
            this.panelServerInfo.TabIndex = 0;
            //
            // groupBoxQuickCommands
            //
            this.groupBoxQuickCommands.Controls.Add(this.btnStopServer);
            this.groupBoxQuickCommands.Controls.Add(this.btnCloseWorld);
            this.groupBoxQuickCommands.Controls.Add(this.btnOpenWorld);
            this.groupBoxQuickCommands.Controls.Add(this.btnPopulation);
            this.groupBoxQuickCommands.Controls.Add(this.btnListPlayers);
            this.groupBoxQuickCommands.Controls.Add(this.btnAceCommands);
            this.groupBoxQuickCommands.Controls.Add(this.btnHello);
            this.groupBoxQuickCommands.Controls.Add(this.btnStatus);
            this.groupBoxQuickCommands.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxQuickCommands.Location = new System.Drawing.Point(10, 210);
            this.groupBoxQuickCommands.Name = "groupBoxQuickCommands";
            this.groupBoxQuickCommands.Size = new System.Drawing.Size(1156, 150);
            this.groupBoxQuickCommands.TabIndex = 1;
            this.groupBoxQuickCommands.TabStop = false;
            this.groupBoxQuickCommands.Text = "Quick Commands";
            //
            // btnStopServer
            //
            this.btnStopServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnStopServer.ForeColor = System.Drawing.Color.White;
            this.btnStopServer.Location = new System.Drawing.Point(20, 100);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(150, 35);
            this.btnStopServer.TabIndex = 7;
            this.btnStopServer.Text = "Stop Server Now";
            this.btnStopServer.UseVisualStyleBackColor = false;
            //
            // btnCloseWorld
            //
            this.btnCloseWorld.Location = new System.Drawing.Point(550, 55);
            this.btnCloseWorld.Name = "btnCloseWorld";
            this.btnCloseWorld.Size = new System.Drawing.Size(150, 35);
            this.btnCloseWorld.TabIndex = 6;
            this.btnCloseWorld.Text = "Close World";
            this.btnCloseWorld.UseVisualStyleBackColor = true;
            //
            // btnOpenWorld
            //
            this.btnOpenWorld.Location = new System.Drawing.Point(375, 55);
            this.btnOpenWorld.Name = "btnOpenWorld";
            this.btnOpenWorld.Size = new System.Drawing.Size(150, 35);
            this.btnOpenWorld.TabIndex = 5;
            this.btnOpenWorld.Text = "Open World";
            this.btnOpenWorld.UseVisualStyleBackColor = true;
            //
            // btnPopulation
            //
            this.btnPopulation.Location = new System.Drawing.Point(200, 55);
            this.btnPopulation.Name = "btnPopulation";
            this.btnPopulation.Size = new System.Drawing.Size(150, 35);
            this.btnPopulation.TabIndex = 4;
            this.btnPopulation.Text = "Population";
            this.btnPopulation.UseVisualStyleBackColor = true;
            //
            // btnListPlayers
            //
            this.btnListPlayers.Location = new System.Drawing.Point(20, 55);
            this.btnListPlayers.Name = "btnListPlayers";
            this.btnListPlayers.Size = new System.Drawing.Size(150, 35);
            this.btnListPlayers.TabIndex = 3;
            this.btnListPlayers.Text = "List Players";
            this.btnListPlayers.UseVisualStyleBackColor = true;
            //
            // btnAceCommands
            //
            this.btnAceCommands.Location = new System.Drawing.Point(550, 20);
            this.btnAceCommands.Name = "btnAceCommands";
            this.btnAceCommands.Size = new System.Drawing.Size(150, 35);
            this.btnAceCommands.TabIndex = 2;
            this.btnAceCommands.Text = "ACE Commands";
            this.btnAceCommands.UseVisualStyleBackColor = true;
            //
            // btnHello
            //
            this.btnHello.Location = new System.Drawing.Point(375, 20);
            this.btnHello.Name = "btnHello";
            this.btnHello.Size = new System.Drawing.Size(150, 35);
            this.btnHello.TabIndex = 1;
            this.btnHello.Text = "Hello";
            this.btnHello.UseVisualStyleBackColor = true;
            //
            // btnStatus
            //
            this.btnStatus.Location = new System.Drawing.Point(20, 20);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(150, 35);
            this.btnStatus.TabIndex = 0;
            this.btnStatus.Text = "Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            //
            // groupBoxServerStatus
            //
            this.groupBoxServerStatus.Controls.Add(this.lblDbPatchVersion);
            this.groupBoxServerStatus.Controls.Add(this.lblDbBaseVersion);
            this.groupBoxServerStatus.Controls.Add(this.lblAceVersion);
            this.groupBoxServerStatus.Controls.Add(this.lblUptime);
            this.groupBoxServerStatus.Controls.Add(this.lblPlayers);
            this.groupBoxServerStatus.Controls.Add(this.lblServerStatus);
            this.groupBoxServerStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxServerStatus.Location = new System.Drawing.Point(10, 10);
            this.groupBoxServerStatus.Name = "groupBoxServerStatus";
            this.groupBoxServerStatus.Size = new System.Drawing.Size(1156, 200);
            this.groupBoxServerStatus.TabIndex = 0;
            this.groupBoxServerStatus.TabStop = false;
            this.groupBoxServerStatus.Text = "Server Status";
            //
            // lblDbPatchVersion
            //
            this.lblDbPatchVersion.AutoSize = true;
            this.lblDbPatchVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblDbPatchVersion.Location = new System.Drawing.Point(20, 160);
            this.lblDbPatchVersion.Name = "lblDbPatchVersion";
            this.lblDbPatchVersion.Size = new System.Drawing.Size(190, 17);
            this.lblDbPatchVersion.TabIndex = 5;
            this.lblDbPatchVersion.Text = "Database Patch Version: ---";
            //
            // lblDbBaseVersion
            //
            this.lblDbBaseVersion.AutoSize = true;
            this.lblDbBaseVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblDbBaseVersion.Location = new System.Drawing.Point(20, 130);
            this.lblDbBaseVersion.Name = "lblDbBaseVersion";
            this.lblDbBaseVersion.Size = new System.Drawing.Size(186, 17);
            this.lblDbBaseVersion.TabIndex = 4;
            this.lblDbBaseVersion.Text = "Database Base Version: ---";
            //
            // lblAceVersion
            //
            this.lblAceVersion.AutoSize = true;
            this.lblAceVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblAceVersion.Location = new System.Drawing.Point(20, 100);
            this.lblAceVersion.Name = "lblAceVersion";
            this.lblAceVersion.Size = new System.Drawing.Size(138, 17);
            this.lblAceVersion.TabIndex = 3;
            this.lblAceVersion.Text = "ACE Version: ---";
            //
            // lblUptime
            //
            this.lblUptime.AutoSize = true;
            this.lblUptime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblUptime.Location = new System.Drawing.Point(20, 70);
            this.lblUptime.Name = "lblUptime";
            this.lblUptime.Size = new System.Drawing.Size(84, 17);
            this.lblUptime.TabIndex = 2;
            this.lblUptime.Text = "Uptime: ---";
            //
            // lblPlayers
            //
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPlayers.Location = new System.Drawing.Point(20, 40);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(93, 17);
            this.lblPlayers.TabIndex = 1;
            this.lblPlayers.Text = "Players: 0 / 0";
            //
            // lblServerStatus
            //
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblServerStatus.Location = new System.Drawing.Point(20, 20);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(118, 20);
            this.lblServerStatus.TabIndex = 0;
            this.lblServerStatus.Text = "Status: Offline";
            //
            // tabBans
            //
            this.tabBans.Controls.Add(this.splitBans);
            this.tabBans.Location = new System.Drawing.Point(4, 22);
            this.tabBans.Name = "tabBans";
            this.tabBans.Size = new System.Drawing.Size(1176, 535);
            this.tabBans.TabIndex = 4;
            this.tabBans.Text = "Bans";
            this.tabBans.UseVisualStyleBackColor = true;
            //
            // splitBans
            //
            this.splitBans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitBans.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitBans.Location = new System.Drawing.Point(0, 0);
            this.splitBans.Name = "splitBans";
            //
            // splitBans.Panel1
            //
            this.splitBans.Panel1.Controls.Add(this.dataGridBans);
            this.splitBans.Panel1.Controls.Add(this.panelBansTop);
            //
            // splitBans.Panel2
            //
            this.splitBans.Panel2.Controls.Add(this.panelBansSidebar);
            this.splitBans.Size = new System.Drawing.Size(1176, 535);
            this.splitBans.SplitterDistance = 926;
            this.splitBans.TabIndex = 0;
            //
            // dataGridBans
            //
            this.dataGridBans.AllowUserToAddRows = false;
            this.dataGridBans.AllowUserToDeleteRows = false;
            this.dataGridBans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridBans.Location = new System.Drawing.Point(0, 40);
            this.dataGridBans.MultiSelect = false;
            this.dataGridBans.Name = "dataGridBans";
            this.dataGridBans.ReadOnly = true;
            this.dataGridBans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridBans.Size = new System.Drawing.Size(926, 495);
            this.dataGridBans.TabIndex = 1;
            //
            // panelBansTop
            //
            this.panelBansTop.Controls.Add(this.btnRefreshBans);
            this.panelBansTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBansTop.Location = new System.Drawing.Point(0, 0);
            this.panelBansTop.Name = "panelBansTop";
            this.panelBansTop.Size = new System.Drawing.Size(926, 40);
            this.panelBansTop.TabIndex = 0;
            //
            // btnRefreshBans
            //
            this.btnRefreshBans.Location = new System.Drawing.Point(10, 8);
            this.btnRefreshBans.Name = "btnRefreshBans";
            this.btnRefreshBans.Size = new System.Drawing.Size(100, 23);
            this.btnRefreshBans.TabIndex = 0;
            this.btnRefreshBans.Text = "Fetch Bans";
            this.btnRefreshBans.UseVisualStyleBackColor = true;
            //
            // panelBansSidebar
            //
            this.panelBansSidebar.Controls.Add(this.groupBoxBanDetails);
            this.panelBansSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBansSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelBansSidebar.Name = "panelBansSidebar";
            this.panelBansSidebar.Size = new System.Drawing.Size(246, 535);
            this.panelBansSidebar.TabIndex = 0;
            //
            // groupBoxBanDetails
            //
            this.groupBoxBanDetails.Controls.Add(this.btnUnban);
            this.groupBoxBanDetails.Controls.Add(this.lblBanExpiration);
            this.groupBoxBanDetails.Controls.Add(this.lblBanAccount);
            this.groupBoxBanDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxBanDetails.Location = new System.Drawing.Point(0, 0);
            this.groupBoxBanDetails.Name = "groupBoxBanDetails";
            this.groupBoxBanDetails.Size = new System.Drawing.Size(246, 535);
            this.groupBoxBanDetails.TabIndex = 0;
            this.groupBoxBanDetails.TabStop = false;
            this.groupBoxBanDetails.Text = "Ban Details";
            //
            // btnUnban
            //
            this.btnUnban.Enabled = false;
            this.btnUnban.Location = new System.Drawing.Point(10, 90);
            this.btnUnban.Name = "btnUnban";
            this.btnUnban.Size = new System.Drawing.Size(220, 30);
            this.btnUnban.TabIndex = 2;
            this.btnUnban.Text = "Unban Account";
            this.btnUnban.UseVisualStyleBackColor = true;
            //
            // lblBanExpiration
            //
            this.lblBanExpiration.AutoSize = true;
            this.lblBanExpiration.Location = new System.Drawing.Point(10, 50);
            this.lblBanExpiration.Name = "lblBanExpiration";
            this.lblBanExpiration.Size = new System.Drawing.Size(79, 13);
            this.lblBanExpiration.TabIndex = 1;
            this.lblBanExpiration.Text = "Expiration: ---";
            //
            // lblBanAccount
            //
            this.lblBanAccount.AutoSize = true;
            this.lblBanAccount.Location = new System.Drawing.Point(10, 25);
            this.lblBanAccount.Name = "lblBanAccount";
            this.lblBanAccount.Size = new System.Drawing.Size(94, 13);
            this.lblBanAccount.TabIndex = 0;
            this.lblBanAccount.Text = "No ban selected";
            //
            // tabConfiguration
            //
            this.tabConfiguration.Controls.Add(this.panelConfiguration);
            this.tabConfiguration.Location = new System.Drawing.Point(4, 22);
            this.tabConfiguration.Name = "tabConfiguration";
            this.tabConfiguration.Size = new System.Drawing.Size(1176, 535);
            this.tabConfiguration.TabIndex = 5;
            this.tabConfiguration.Text = "Configuration";
            this.tabConfiguration.UseVisualStyleBackColor = true;
            //
            // panelConfiguration
            //
            this.panelConfiguration.Controls.Add(this.groupBoxDisplayOptions);
            this.panelConfiguration.Controls.Add(this.groupBoxServerSettings);
            this.panelConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConfiguration.Location = new System.Drawing.Point(0, 0);
            this.panelConfiguration.Name = "panelConfiguration";
            this.panelConfiguration.Padding = new System.Windows.Forms.Padding(10);
            this.panelConfiguration.Size = new System.Drawing.Size(1176, 535);
            this.panelConfiguration.TabIndex = 0;
            //
            // groupBoxDisplayOptions
            //
            this.groupBoxDisplayOptions.Controls.Add(this.label1);
            this.groupBoxDisplayOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDisplayOptions.Location = new System.Drawing.Point(410, 10);
            this.groupBoxDisplayOptions.Name = "groupBoxDisplayOptions";
            this.groupBoxDisplayOptions.Size = new System.Drawing.Size(756, 515);
            this.groupBoxDisplayOptions.TabIndex = 1;
            this.groupBoxDisplayOptions.TabStop = false;
            this.groupBoxDisplayOptions.Text = "Display Options";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Color customization and options coming in Phase 3";
            //
            // groupBoxServerSettings
            //
            this.groupBoxServerSettings.Controls.Add(this.lblConfigNote);
            this.groupBoxServerSettings.Controls.Add(this.lblServerSettings);
            this.groupBoxServerSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxServerSettings.Location = new System.Drawing.Point(10, 10);
            this.groupBoxServerSettings.Name = "groupBoxServerSettings";
            this.groupBoxServerSettings.Size = new System.Drawing.Size(400, 515);
            this.groupBoxServerSettings.TabIndex = 0;
            this.groupBoxServerSettings.TabStop = false;
            this.groupBoxServerSettings.Text = "Server Settings (Read-Only)";
            //
            // lblConfigNote
            //
            this.lblConfigNote.AutoSize = true;
            this.lblConfigNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.lblConfigNote.Location = new System.Drawing.Point(20, 490);
            this.lblConfigNote.Name = "lblConfigNote";
            this.lblConfigNote.Size = new System.Drawing.Size(255, 13);
            this.lblConfigNote.TabIndex = 1;
            this.lblConfigNote.Text = "Note: Most settings require server restart to apply.";
            //
            // lblServerSettings
            //
            this.lblServerSettings.AutoSize = true;
            this.lblServerSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblServerSettings.Location = new System.Drawing.Point(20, 25);
            this.lblServerSettings.Name = "lblServerSettings";
            this.lblServerSettings.Size = new System.Drawing.Size(199, 15);
            this.lblServerSettings.TabIndex = 0;
            this.lblServerSettings.Text = "Connect to server to view settings";
            //
            // statusStrip
            //
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 661);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            //
            // toolStripStatusLabel
            //
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(259, 17);
            this.toolStripStatusLabel.Text = "ACE RCON Desktop v0.0.10 - Ftuoil Xelrash of Darktide";
            //
            // notifyIcon
            //
            this.notifyIcon.Text = "ACE RCON Desktop";
            this.notifyIcon.Visible = true;
            //
            // MainWindow
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 683);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBoxConnection);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACE RCON Desktop - v0.0.10";
            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabConsole.ResumeLayout(false);
            this.splitConsole.Panel1.ResumeLayout(false);
            this.splitConsole.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitConsole)).EndInit();
            this.splitConsole.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.panelCommand.PerformLayout();
            this.panelConsoleSidebar.ResumeLayout(false);
            this.groupBoxFilters.ResumeLayout(false);
            this.groupBoxFilters.PerformLayout();
            this.tabPlayers.ResumeLayout(false);
            this.splitPlayers.Panel1.ResumeLayout(false);
            this.splitPlayers.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPlayers)).EndInit();
            this.splitPlayers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPlayers)).EndInit();
            this.panelPlayersTop.ResumeLayout(false);
            this.panelPlayersTop.PerformLayout();
            this.panelPlayersSidebar.ResumeLayout(false);
            this.groupBoxPlayerActions.ResumeLayout(false);
            this.groupBoxPlayerActions.PerformLayout();
            this.tabChat.ResumeLayout(false);
            this.splitChat.Panel1.ResumeLayout(false);
            this.splitChat.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitChat)).EndInit();
            this.splitChat.ResumeLayout(false);
            this.panelChatSidebar.ResumeLayout(false);
            this.groupBoxChatFilters.ResumeLayout(false);
            this.groupBoxChatFilters.PerformLayout();
            this.tabServerInfo.ResumeLayout(false);
            this.panelServerInfo.ResumeLayout(false);
            this.groupBoxQuickCommands.ResumeLayout(false);
            this.groupBoxServerStatus.ResumeLayout(false);
            this.groupBoxServerStatus.PerformLayout();
            this.tabBans.ResumeLayout(false);
            this.splitBans.Panel1.ResumeLayout(false);
            this.splitBans.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitBans)).EndInit();
            this.splitBans.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBans)).EndInit();
            this.panelBansTop.ResumeLayout(false);
            this.panelBansSidebar.ResumeLayout(false);
            this.groupBoxBanDetails.ResumeLayout(false);
            this.groupBoxBanDetails.PerformLayout();
            this.tabConfiguration.ResumeLayout(false);
            this.panelConfiguration.ResumeLayout(false);
            this.groupBoxDisplayOptions.ResumeLayout(false);
            this.groupBoxDisplayOptions.PerformLayout();
            this.groupBoxServerSettings.ResumeLayout(false);
            this.groupBoxServerSettings.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.ComboBox comboProfiles;
        private System.Windows.Forms.Label lblProfile;
        private System.Windows.Forms.RadioButton radioWebSocket;
        private System.Windows.Forms.RadioButton radioTCP;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabConsole;
        private System.Windows.Forms.SplitContainer splitConsole;
        private System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.Panel panelCommand;
        private System.Windows.Forms.ComboBox comboCommandHistory;
        private System.Windows.Forms.Button btnSendCommand;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Label lblCommand;
        private System.Windows.Forms.Panel panelConsoleSidebar;
        private System.Windows.Forms.GroupBox groupBoxFilters;
        private System.Windows.Forms.CheckBox chkShowModule;
        private System.Windows.Forms.CheckBox chkShowTimestamp;
        private System.Windows.Forms.CheckBox chkFilterPropertyManager;
        private System.Windows.Forms.CheckBox chkFilterPlayerManager;
        private System.Windows.Forms.CheckBox chkFilterNetwork;
        private System.Windows.Forms.CheckBox chkFilterModManager;
        private System.Windows.Forms.CheckBox chkFilterManagers;
        private System.Windows.Forms.CheckBox chkFilterLandblockManager;
        private System.Windows.Forms.CheckBox chkFilterGuidManager;
        private System.Windows.Forms.CheckBox chkFilterEventManager;
        private System.Windows.Forms.CheckBox chkFilterEntity;
        private System.Windows.Forms.CheckBox chkFilterDatManager;
        private System.Windows.Forms.CheckBox chkFilterDatabase;
        private System.Windows.Forms.CheckBox chkFilterAceProgram;
        private System.Windows.Forms.TabPage tabPlayers;
        private System.Windows.Forms.SplitContainer splitPlayers;
        private System.Windows.Forms.DataGridView dataGridPlayers;
        private System.Windows.Forms.Panel panelPlayersTop;
        private System.Windows.Forms.Button btnRefreshPlayers;
        private System.Windows.Forms.CheckBox chkAutoRefreshPlayers;
        private System.Windows.Forms.Label lblPlayerCount;
        private System.Windows.Forms.Panel panelPlayersSidebar;
        private System.Windows.Forms.GroupBox groupBoxPlayerActions;
        private System.Windows.Forms.Button btnMutePlayer;
        private System.Windows.Forms.Button btnBanPlayer;
        private System.Windows.Forms.Button btnBootPlayer;
        private System.Windows.Forms.Label lblSelectedPlayer;
        private System.Windows.Forms.TabPage tabChat;
        private System.Windows.Forms.SplitContainer splitChat;
        private System.Windows.Forms.RichTextBox txtChat;
        private System.Windows.Forms.Panel panelChatSidebar;
        private System.Windows.Forms.GroupBox groupBoxChatFilters;
        private System.Windows.Forms.CheckBox chkChatShowTimestamp;
        private System.Windows.Forms.CheckBox chkChatTrade;
        private System.Windows.Forms.CheckBox chkChatGuild;
        private System.Windows.Forms.CheckBox chkChatGeneral;
        private System.Windows.Forms.TabPage tabServerInfo;
        private System.Windows.Forms.Panel panelServerInfo;
        private System.Windows.Forms.GroupBox groupBoxQuickCommands;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Button btnCloseWorld;
        private System.Windows.Forms.Button btnOpenWorld;
        private System.Windows.Forms.Button btnPopulation;
        private System.Windows.Forms.Button btnListPlayers;
        private System.Windows.Forms.Button btnAceCommands;
        private System.Windows.Forms.Button btnHello;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.GroupBox groupBoxServerStatus;
        private System.Windows.Forms.Label lblDbPatchVersion;
        private System.Windows.Forms.Label lblDbBaseVersion;
        private System.Windows.Forms.Label lblAceVersion;
        private System.Windows.Forms.Label lblUptime;
        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.TabPage tabBans;
        private System.Windows.Forms.SplitContainer splitBans;
        private System.Windows.Forms.DataGridView dataGridBans;
        private System.Windows.Forms.Panel panelBansTop;
        private System.Windows.Forms.Button btnRefreshBans;
        private System.Windows.Forms.Panel panelBansSidebar;
        private System.Windows.Forms.GroupBox groupBoxBanDetails;
        private System.Windows.Forms.Button btnUnban;
        private System.Windows.Forms.Label lblBanExpiration;
        private System.Windows.Forms.Label lblBanAccount;
        private System.Windows.Forms.TabPage tabConfiguration;
        private System.Windows.Forms.Panel panelConfiguration;
        private System.Windows.Forms.GroupBox groupBoxDisplayOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxServerSettings;
        private System.Windows.Forms.Label lblConfigNote;
        private System.Windows.Forms.Label lblServerSettings;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}
