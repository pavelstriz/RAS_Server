namespace TcpServer
{
    partial class MainForm
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnBlacklist1 = new System.Windows.Forms.Button();
            this.btnDisconnectClient = new System.Windows.Forms.Button();
            this.btnBlockClient = new System.Windows.Forms.Button();
            this.txtUpTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtMAC = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.Label();
            this.txtUserIp = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMachineName = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDaysLeft = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbShowLInfo = new System.Windows.Forms.PictureBox();
            this.txtLStatus = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnServerStart = new System.Windows.Forms.Button();
            this.btnServerStop = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.activeClients = new System.Windows.Forms.ListBox();
            this.ttLicenseInfo = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowLInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 87);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(534, 409);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.txtConsole);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(526, 380);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Console";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(15, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Console:";
            // 
            // txtConsole
            // 
            this.txtConsole.Location = new System.Drawing.Point(18, 41);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(488, 321);
            this.txtConsole.TabIndex = 4;
            this.txtConsole.Text = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(526, 380);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Remote Command";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(526, 380);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "License";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnBlacklist1);
            this.tabPage3.Controls.Add(this.btnDisconnectClient);
            this.tabPage3.Controls.Add(this.btnBlockClient);
            this.tabPage3.Controls.Add(this.txtUpTime);
            this.tabPage3.Controls.Add(this.tableLayoutPanel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(526, 380);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Client Info";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnBlacklist1
            // 
            this.btnBlacklist1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBlacklist1.Location = new System.Drawing.Point(391, 285);
            this.btnBlacklist1.Name = "btnBlacklist1";
            this.btnBlacklist1.Size = new System.Drawing.Size(114, 46);
            this.btnBlacklist1.TabIndex = 38;
            this.btnBlacklist1.Text = "Blacklist";
            this.btnBlacklist1.UseVisualStyleBackColor = true;
            this.btnBlacklist1.Click += new System.EventHandler(this.btnBlacklist1_Click);
            // 
            // btnDisconnectClient
            // 
            this.btnDisconnectClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDisconnectClient.Location = new System.Drawing.Point(391, 196);
            this.btnDisconnectClient.Name = "btnDisconnectClient";
            this.btnDisconnectClient.Size = new System.Drawing.Size(114, 32);
            this.btnDisconnectClient.TabIndex = 37;
            this.btnDisconnectClient.Text = "Disconnect";
            this.btnDisconnectClient.UseVisualStyleBackColor = true;
            this.btnDisconnectClient.Click += new System.EventHandler(this.btnDisconnectClient_Click);
            // 
            // btnBlockClient
            // 
            this.btnBlockClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBlockClient.Location = new System.Drawing.Point(391, 234);
            this.btnBlockClient.Name = "btnBlockClient";
            this.btnBlockClient.Size = new System.Drawing.Size(114, 32);
            this.btnBlockClient.TabIndex = 36;
            this.btnBlockClient.Text = "Block";
            this.btnBlockClient.UseVisualStyleBackColor = true;
            this.btnBlockClient.Click += new System.EventHandler(this.btnBlockClient_Click);
            // 
            // txtUpTime
            // 
            this.txtUpTime.AutoSize = true;
            this.txtUpTime.Location = new System.Drawing.Point(419, 35);
            this.txtUpTime.Name = "txtUpTime";
            this.txtUpTime.Size = new System.Drawing.Size(58, 17);
            this.txtUpTime.TabIndex = 34;
            this.txtUpTime.Text = "[uptime]";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.67442F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.32558F));
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtMAC, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtUserName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtUserIp, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtMachineName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label20, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtDaysLeft, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label18, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 21);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(345, 334);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(4, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "Client ID";
            // 
            // txtId
            // 
            this.txtId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtId.AutoSize = true;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtId.Location = new System.Drawing.Point(168, 11);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(32, 20);
            this.txtId.TabIndex = 32;
            this.txtId.Text = "[id]";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(4, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(133, 20);
            this.label13.TabIndex = 21;
            this.label13.Text = "Machine Name";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.Location = new System.Drawing.Point(4, 93);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(107, 20);
            this.label16.TabIndex = 25;
            this.label16.Text = "Active User";
            // 
            // txtMAC
            // 
            this.txtMAC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMAC.AutoSize = true;
            this.txtMAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtMAC.Location = new System.Drawing.Point(168, 175);
            this.txtMAC.Name = "txtMAC";
            this.txtMAC.Size = new System.Drawing.Size(51, 20);
            this.txtMAC.TabIndex = 24;
            this.txtMAC.Text = "[mac]";
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUserName.AutoSize = true;
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtUserName.Location = new System.Drawing.Point(168, 93);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(98, 20);
            this.txtUserName.TabIndex = 26;
            this.txtUserName.Text = "[user name]";
            // 
            // txtUserIp
            // 
            this.txtUserIp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUserIp.AutoSize = true;
            this.txtUserIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtUserIp.Location = new System.Drawing.Point(168, 134);
            this.txtUserIp.Name = "txtUserIp";
            this.txtUserIp.Size = new System.Drawing.Size(32, 20);
            this.txtUserIp.TabIndex = 20;
            this.txtUserIp.Text = "[ip]";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(4, 134);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 20);
            this.label12.TabIndex = 19;
            this.label12.Text = "Ip Address";
            // 
            // txtMachineName
            // 
            this.txtMachineName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMachineName.AutoSize = true;
            this.txtMachineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtMachineName.Location = new System.Drawing.Point(168, 52);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(82, 20);
            this.txtMachineName.TabIndex = 22;
            this.txtMachineName.Text = "[machine]";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.Location = new System.Drawing.Point(4, 175);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 20);
            this.label14.TabIndex = 23;
            this.label14.Text = "MAC";
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label20.Location = new System.Drawing.Point(4, 300);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 20);
            this.label20.TabIndex = 29;
            this.label20.Text = "Days left";
            // 
            // txtDaysLeft
            // 
            this.txtDaysLeft.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDaysLeft.AutoSize = true;
            this.txtDaysLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtDaysLeft.Location = new System.Drawing.Point(168, 300);
            this.txtDaysLeft.Name = "txtDaysLeft";
            this.txtDaysLeft.Size = new System.Drawing.Size(91, 20);
            this.txtDaysLeft.TabIndex = 30;
            this.txtDaysLeft.Text = "[expiration]";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label18.Location = new System.Drawing.Point(4, 257);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(133, 20);
            this.label18.TabIndex = 27;
            this.label18.Text = "License status";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbShowLInfo);
            this.panel1.Controls.Add(this.txtLStatus);
            this.panel1.Location = new System.Drawing.Point(165, 247);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 40);
            this.panel1.TabIndex = 33;
            // 
            // pbShowLInfo
            // 
            this.pbShowLInfo.BackgroundImage = global::TcpServer.Properties.Resources.eyeLicenseInfo_Show2_2_gray3_hidden;
            this.pbShowLInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbShowLInfo.Location = new System.Drawing.Point(137, 2);
            this.pbShowLInfo.Name = "pbShowLInfo";
            this.pbShowLInfo.Size = new System.Drawing.Size(36, 36);
            this.pbShowLInfo.TabIndex = 36;
            this.pbShowLInfo.TabStop = false;
            this.pbShowLInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbShowLInfo_MouseDown);
            this.pbShowLInfo.MouseEnter += new System.EventHandler(this.pbShowLInfo_MouseEnter);
            this.pbShowLInfo.MouseLeave += new System.EventHandler(this.pbShowLInfo_MouseLeave);
            // 
            // txtLStatus
            // 
            this.txtLStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtLStatus.AutoSize = true;
            this.txtLStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtLStatus.Location = new System.Drawing.Point(3, 10);
            this.txtLStatus.Name = "txtLStatus";
            this.txtLStatus.Size = new System.Drawing.Size(65, 20);
            this.txtLStatus.TabIndex = 28;
            this.txtLStatus.Text = "[status]";
            this.txtLStatus.TextChanged += new System.EventHandler(this.txtLStatus_TextChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(526, 380);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Task Scheduler";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnServerStart
            // 
            this.btnServerStart.Location = new System.Drawing.Point(16, 12);
            this.btnServerStart.Name = "btnServerStart";
            this.btnServerStart.Size = new System.Drawing.Size(64, 59);
            this.btnServerStart.TabIndex = 3;
            this.btnServerStart.Text = "Start";
            this.btnServerStart.UseVisualStyleBackColor = true;
            this.btnServerStart.Click += new System.EventHandler(this.btnServerStart_Click);
            // 
            // btnServerStop
            // 
            this.btnServerStop.Location = new System.Drawing.Point(86, 12);
            this.btnServerStop.Name = "btnServerStop";
            this.btnServerStop.Size = new System.Drawing.Size(64, 59);
            this.btnServerStop.TabIndex = 4;
            this.btnServerStop.Text = "Stop";
            this.btnServerStop.UseVisualStyleBackColor = true;
            this.btnServerStop.Click += new System.EventHandler(this.btnServerStop_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(548, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Clients:";
            // 
            // activeClients
            // 
            this.activeClients.FormattingEnabled = true;
            this.activeClients.ItemHeight = 16;
            this.activeClients.Location = new System.Drawing.Point(552, 50);
            this.activeClients.Name = "activeClients";
            this.activeClients.Size = new System.Drawing.Size(164, 452);
            this.activeClients.TabIndex = 18;
            this.activeClients.SelectedIndexChanged += new System.EventHandler(this.activeClients_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(724, 508);
            this.Controls.Add(this.activeClients);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnServerStop);
            this.Controls.Add(this.btnServerStart);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowLInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnServerStart;
        private System.Windows.Forms.Button btnServerStop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label txtMachineName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label txtUserIp;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label txtDaysLeft;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label txtLStatus;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label txtUserName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label txtMAC;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tabPage4;
        public System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtId;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView lvi;
        private System.Windows.Forms.Label txtUpTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbShowLInfo;
        private System.Windows.Forms.ToolTip ttLicenseInfo;
        private System.Windows.Forms.Button btnBlockClient;
        private System.Windows.Forms.Button btnDisconnectClient;
        public System.Windows.Forms.ListBox activeClients;
        private System.Windows.Forms.TabPage tabPage5;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnBlacklist1;
    }
}

