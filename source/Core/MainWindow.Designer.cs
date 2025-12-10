namespace ACE.RCON.Desktop
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
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
            this.groupBoxConsole = new System.Windows.Forms.GroupBox();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.panelCommand = new System.Windows.Forms.Panel();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.lblCommand = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxConnection.SuspendLayout();
            this.groupBoxConsole.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            //
            // groupBoxConnection
            //
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
            this.groupBoxConnection.Size = new System.Drawing.Size(984, 120);
            this.groupBoxConnection.TabIndex = 0;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "Connection";
            //
            // radioWebSocket
            //
            this.radioWebSocket.AutoSize = true;
            this.radioWebSocket.Location = new System.Drawing.Point(640, 48);
            this.radioWebSocket.Name = "radioWebSocket";
            this.radioWebSocket.Size = new System.Drawing.Size(82, 17);
            this.radioWebSocket.TabIndex = 6;
            this.radioWebSocket.TabStop = true;
            this.radioWebSocket.Text = "WebSocket";
            this.radioWebSocket.UseVisualStyleBackColor = true;
            //
            // radioTCP
            //
            this.radioTCP.AutoSize = true;
            this.radioTCP.Location = new System.Drawing.Point(640, 25);
            this.radioTCP.Name = "radioTCP";
            this.radioTCP.Size = new System.Drawing.Size(46, 17);
            this.radioTCP.TabIndex = 5;
            this.radioTCP.TabStop = true;
            this.radioTCP.Text = "TCP";
            this.radioTCP.UseVisualStyleBackColor = true;
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(640, 85);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(93, 15);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Disconnected";
            //
            // btnConnect
            //
            this.btnConnect.Location = new System.Drawing.Point(540, 80);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(90, 23);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            //
            // txtAccountName
            //
            this.txtAccountName.Location = new System.Drawing.Point(370, 82);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(150, 20);
            this.txtAccountName.TabIndex = 4;
            //
            // lblAccountName
            //
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Location = new System.Drawing.Point(280, 85);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(87, 13);
            this.lblAccountName.TabIndex = 7;
            this.lblAccountName.Text = "Account (ACE): ";
            //
            // txtPassword
            //
            this.txtPassword.Location = new System.Drawing.Point(115, 82);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(150, 20);
            this.txtPassword.TabIndex = 3;
            //
            // lblPassword
            //
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(15, 85);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(59, 13);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password: ";
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
            this.lblPort.Size = new System.Drawing.Size(32, 13);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Port: ";
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
            this.lblAddress.Text = "Address: ";
            //
            // groupBoxConsole
            //
            this.groupBoxConsole.Controls.Add(this.txtConsole);
            this.groupBoxConsole.Controls.Add(this.panelCommand);
            this.groupBoxConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxConsole.Location = new System.Drawing.Point(0, 120);
            this.groupBoxConsole.Name = "groupBoxConsole";
            this.groupBoxConsole.Size = new System.Drawing.Size(984, 441);
            this.groupBoxConsole.TabIndex = 1;
            this.groupBoxConsole.TabStop = false;
            this.groupBoxConsole.Text = "Console";
            //
            // txtConsole
            //
            this.txtConsole.BackColor = System.Drawing.Color.Black;
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole.ForeColor = System.Drawing.Color.Lime;
            this.txtConsole.Location = new System.Drawing.Point(3, 16);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(978, 382);
            this.txtConsole.TabIndex = 1;
            //
            // panelCommand
            //
            this.panelCommand.Controls.Add(this.btnSendCommand);
            this.panelCommand.Controls.Add(this.txtCommand);
            this.panelCommand.Controls.Add(this.lblCommand);
            this.panelCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommand.Location = new System.Drawing.Point(3, 398);
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Size = new System.Drawing.Size(978, 40);
            this.panelCommand.TabIndex = 0;
            //
            // btnSendCommand
            //
            this.btnSendCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendCommand.Location = new System.Drawing.Point(890, 8);
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
            this.txtCommand.Size = new System.Drawing.Size(800, 20);
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
            // statusStrip
            //
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 561);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(984, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            //
            // toolStripStatusLabel
            //
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(166, 17);
            this.toolStripStatusLabel.Text = "ACE RCON Desktop - Phase 1";
            //
            // MainWindow
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 583);
            this.Controls.Add(this.groupBoxConsole);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBoxConnection);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACE RCON Desktop";
            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            this.groupBoxConsole.ResumeLayout(false);
            this.groupBoxConsole.PerformLayout();
            this.panelCommand.ResumeLayout(false);
            this.panelCommand.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.RadioButton radioWebSocket;
        private System.Windows.Forms.RadioButton radioTCP;
        private System.Windows.Forms.GroupBox groupBoxConsole;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Panel panelCommand;
        private System.Windows.Forms.Button btnSendCommand;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Label lblCommand;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}
