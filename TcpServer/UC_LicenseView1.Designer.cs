namespace TcpServer
{
    partial class UC_LicenseView1
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

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLicenses1 = new System.Windows.Forms.DataGridView();
            this.btnDeactivateLicense = new System.Windows.Forms.Button();
            this.btnEditExpiration = new System.Windows.Forms.Button();
            this.btnDeleteLicense = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGenDate = new System.Windows.Forms.Label();
            this.txtExpDate = new System.Windows.Forms.Label();
            this.txtActDate = new System.Windows.Forms.Label();
            this.txtLicStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLinkLicense = new System.Windows.Forms.Button();
            this.btnViewBackToM = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicenses1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLicenses1
            // 
            this.dgvLicenses1.AllowUserToAddRows = false;
            this.dgvLicenses1.AllowUserToDeleteRows = false;
            this.dgvLicenses1.AllowUserToResizeColumns = false;
            this.dgvLicenses1.AllowUserToResizeRows = false;
            this.dgvLicenses1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLicenses1.BackgroundColor = System.Drawing.Color.White;
            this.dgvLicenses1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLicenses1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvLicenses1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLicenses1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvLicenses1.GridColor = System.Drawing.SystemColors.WindowFrame;
            this.dgvLicenses1.Location = new System.Drawing.Point(3, 43);
            this.dgvLicenses1.MultiSelect = false;
            this.dgvLicenses1.Name = "dgvLicenses1";
            this.dgvLicenses1.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLicenses1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvLicenses1.RowHeadersVisible = false;
            this.dgvLicenses1.RowHeadersWidth = 51;
            this.dgvLicenses1.RowTemplate.Height = 24;
            this.dgvLicenses1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvLicenses1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLicenses1.Size = new System.Drawing.Size(413, 151);
            this.dgvLicenses1.TabIndex = 0;
            this.dgvLicenses1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLicenses1_CellClick);
            this.dgvLicenses1.SelectionChanged += new System.EventHandler(this.dgvLicenses1_SelectionChanged);
            // 
            // btnDeactivateLicense
            // 
            this.btnDeactivateLicense.Location = new System.Drawing.Point(422, 90);
            this.btnDeactivateLicense.Name = "btnDeactivateLicense";
            this.btnDeactivateLicense.Size = new System.Drawing.Size(90, 28);
            this.btnDeactivateLicense.TabIndex = 2;
            this.btnDeactivateLicense.Text = "Deactivate";
            this.btnDeactivateLicense.UseVisualStyleBackColor = true;
            this.btnDeactivateLicense.Click += new System.EventHandler(this.btnDeactivateLicense_Click);
            // 
            // btnEditExpiration
            // 
            this.btnEditExpiration.Location = new System.Drawing.Point(422, 124);
            this.btnEditExpiration.Name = "btnEditExpiration";
            this.btnEditExpiration.Size = new System.Drawing.Size(90, 28);
            this.btnEditExpiration.TabIndex = 3;
            this.btnEditExpiration.Text = "Expiration";
            this.btnEditExpiration.UseVisualStyleBackColor = true;
            this.btnEditExpiration.Click += new System.EventHandler(this.btnEditExpiration_Click);
            // 
            // btnDeleteLicense
            // 
            this.btnDeleteLicense.Location = new System.Drawing.Point(422, 166);
            this.btnDeleteLicense.Name = "btnDeleteLicense";
            this.btnDeleteLicense.Size = new System.Drawing.Size(90, 28);
            this.btnDeleteLicense.TabIndex = 5;
            this.btnDeleteLicense.Text = "Delete";
            this.btnDeleteLicense.UseVisualStyleBackColor = true;
            this.btnDeleteLicense.Click += new System.EventHandler(this.btnDeleteLicense_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Generated date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Expiration date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Activation date:";
            // 
            // txtGenDate
            // 
            this.txtGenDate.AutoSize = true;
            this.txtGenDate.Location = new System.Drawing.Point(125, 213);
            this.txtGenDate.Name = "txtGenDate";
            this.txtGenDate.Size = new System.Drawing.Size(79, 17);
            this.txtGenDate.TabIndex = 9;
            this.txtGenDate.Text = "txtGenDate";
            // 
            // txtExpDate
            // 
            this.txtExpDate.AutoSize = true;
            this.txtExpDate.Location = new System.Drawing.Point(125, 241);
            this.txtExpDate.Name = "txtExpDate";
            this.txtExpDate.Size = new System.Drawing.Size(75, 17);
            this.txtExpDate.TabIndex = 10;
            this.txtExpDate.Text = "txtExpDate";
            // 
            // txtActDate
            // 
            this.txtActDate.AutoSize = true;
            this.txtActDate.Location = new System.Drawing.Point(125, 269);
            this.txtActDate.Name = "txtActDate";
            this.txtActDate.Size = new System.Drawing.Size(72, 17);
            this.txtActDate.TabIndex = 11;
            this.txtActDate.Text = "txtActDate";
            // 
            // txtLicStatus
            // 
            this.txtLicStatus.AutoSize = true;
            this.txtLicStatus.Location = new System.Drawing.Point(420, 269);
            this.txtLicStatus.Name = "txtLicStatus";
            this.txtLicStatus.Size = new System.Drawing.Size(80, 17);
            this.txtLicStatus.TabIndex = 28;
            this.txtLicStatus.Text = "txtLicStatus";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(364, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "Status:";
            // 
            // btnLinkLicense
            // 
            this.btnLinkLicense.Location = new System.Drawing.Point(422, 56);
            this.btnLinkLicense.Name = "btnLinkLicense";
            this.btnLinkLicense.Size = new System.Drawing.Size(90, 28);
            this.btnLinkLicense.TabIndex = 30;
            this.btnLinkLicense.Text = "Link";
            this.btnLinkLicense.UseVisualStyleBackColor = true;
            this.btnLinkLicense.Click += new System.EventHandler(this.btnLinkLicense_Click);
            // 
            // btnViewBackToM
            // 
            this.btnViewBackToM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnViewBackToM.Location = new System.Drawing.Point(16, 330);
            this.btnViewBackToM.Name = "btnViewBackToM";
            this.btnViewBackToM.Size = new System.Drawing.Size(75, 31);
            this.btnViewBackToM.TabIndex = 31;
            this.btnViewBackToM.Text = "Close";
            this.btnViewBackToM.UseVisualStyleBackColor = true;
            this.btnViewBackToM.Click += new System.EventHandler(this.btnViewBackToM_Click);
            // 
            // UC_LicenseView1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnViewBackToM);
            this.Controls.Add(this.btnLinkLicense);
            this.Controls.Add(this.txtLicStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtActDate);
            this.Controls.Add(this.txtExpDate);
            this.Controls.Add(this.txtGenDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteLicense);
            this.Controls.Add(this.btnEditExpiration);
            this.Controls.Add(this.btnDeactivateLicense);
            this.Controls.Add(this.dgvLicenses1);
            this.Name = "UC_LicenseView1";
            this.Size = new System.Drawing.Size(521, 375);
            this.Load += new System.EventHandler(this.UC_LicenseView1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicenses1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEditExpiration;
        private System.Windows.Forms.Button btnDeleteLicense;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView dgvLicenses1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label txtLicStatus;
        public System.Windows.Forms.Button btnLinkLicense;
        public System.Windows.Forms.Button btnDeactivateLicense;
        private System.Windows.Forms.Button btnViewBackToM;
        public System.Windows.Forms.Label txtGenDate;
        public System.Windows.Forms.Label txtExpDate;
        public System.Windows.Forms.Label txtActDate;
    }
}
