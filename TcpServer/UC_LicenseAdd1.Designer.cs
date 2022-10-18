
namespace TcpServer
{
    partial class UC_LicenseAdd1
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
            this.comboLicenseId = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtVerKey = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateExp = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dateSince = new System.Windows.Forms.DateTimePicker();
            this.txtClientIp = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnActivate = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.txtPublicKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddBackToM = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboLicenseId
            // 
            this.comboLicenseId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLicenseId.FormattingEnabled = true;
            this.comboLicenseId.Location = new System.Drawing.Point(133, 64);
            this.comboLicenseId.Name = "comboLicenseId";
            this.comboLicenseId.Size = new System.Drawing.Size(121, 24);
            this.comboLicenseId.TabIndex = 39;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(18, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(109, 17);
            this.label15.TabIndex = 38;
            this.label15.Text = "Serial number";
            // 
            // txtVerKey
            // 
            this.txtVerKey.Location = new System.Drawing.Point(21, 197);
            this.txtVerKey.Name = "txtVerKey";
            this.txtVerKey.Size = new System.Drawing.Size(464, 77);
            this.txtVerKey.TabIndex = 37;
            this.txtVerKey.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(313, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 17);
            this.label9.TabIndex = 36;
            this.label9.Text = "Expire";
            // 
            // dateExp
            // 
            this.dateExp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateExp.Location = new System.Drawing.Point(373, 67);
            this.dateExp.Name = "dateExp";
            this.dateExp.Size = new System.Drawing.Size(111, 22);
            this.dateExp.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(317, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 17);
            this.label8.TabIndex = 34;
            this.label8.Text = "Since";
            // 
            // dateSince
            // 
            this.dateSince.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateSince.Location = new System.Drawing.Point(373, 25);
            this.dateSince.Name = "dateSince";
            this.dateSince.Size = new System.Drawing.Size(111, 22);
            this.dateSince.TabIndex = 33;
            // 
            // txtClientIp
            // 
            this.txtClientIp.AutoSize = true;
            this.txtClientIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtClientIp.Location = new System.Drawing.Point(97, 25);
            this.txtClientIp.Name = "txtClientIp";
            this.txtClientIp.Size = new System.Drawing.Size(82, 17);
            this.txtClientIp.TabIndex = 32;
            this.txtClientIp.Text = "[ip address]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(19, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 31;
            this.label4.Text = "Client Ip:";
            // 
            // btnActivate
            // 
            this.btnActivate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnActivate.Location = new System.Drawing.Point(376, 308);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(108, 53);
            this.btnActivate.TabIndex = 30;
            this.btnActivate.Text = "Activate License";
            this.btnActivate.UseVisualStyleBackColor = true;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEncrypt.Location = new System.Drawing.Point(387, 154);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(97, 30);
            this.btnEncrypt.TabIndex = 29;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtPublicKey.Location = new System.Drawing.Point(22, 126);
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.Size = new System.Drawing.Size(462, 22);
            this.txtPublicKey.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(20, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Verification Key";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(18, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "Registration Key";
            // 
            // btnAddBackToM
            // 
            this.btnAddBackToM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddBackToM.Location = new System.Drawing.Point(16, 330);
            this.btnAddBackToM.Name = "btnAddBackToM";
            this.btnAddBackToM.Size = new System.Drawing.Size(75, 31);
            this.btnAddBackToM.TabIndex = 41;
            this.btnAddBackToM.Text = "Close";
            this.btnAddBackToM.UseVisualStyleBackColor = true;
            this.btnAddBackToM.Click += new System.EventHandler(this.btnViewBackToM_Click);
            // 
            // UC_LicenseAdd1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddBackToM);
            this.Controls.Add(this.comboLicenseId);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtVerKey);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dateExp);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateSince);
            this.Controls.Add(this.txtClientIp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtPublicKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Name = "UC_LicenseAdd1";
            this.Size = new System.Drawing.Size(521, 375);
            this.Load += new System.EventHandler(this.UC_LicenseAdd1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox comboLicenseId;
        public System.Windows.Forms.RichTextBox txtVerKey;
        public System.Windows.Forms.DateTimePicker dateExp;
        public System.Windows.Forms.DateTimePicker dateSince;
        public System.Windows.Forms.Label txtClientIp;
        public System.Windows.Forms.Button btnEncrypt;
        public System.Windows.Forms.TextBox txtPublicKey;
        private System.Windows.Forms.Button btnAddBackToM;
    }
}
