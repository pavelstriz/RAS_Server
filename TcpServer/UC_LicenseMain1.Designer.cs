
namespace TcpServer
{
    partial class UC_LicenseMain1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLicenseView1 = new System.Windows.Forms.Button();
            this.btnAddLicense = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnLicenseView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddLicense, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(521, 375);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnLicenseView1
            // 
            this.btnLicenseView1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLicenseView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLicenseView1.Location = new System.Drawing.Point(280, 119);
            this.btnLicenseView1.Margin = new System.Windows.Forms.Padding(20, 3, 3, 100);
            this.btnLicenseView1.Name = "btnLicenseView1";
            this.btnLicenseView1.Size = new System.Drawing.Size(110, 39);
            this.btnLicenseView1.TabIndex = 30;
            this.btnLicenseView1.Text = "View";
            this.btnLicenseView1.UseVisualStyleBackColor = true;
            this.btnLicenseView1.Click += new System.EventHandler(this.btnLicenseView1_Click);
            // 
            // btnAddLicense
            // 
            this.btnAddLicense.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddLicense.Location = new System.Drawing.Point(130, 119);
            this.btnAddLicense.Margin = new System.Windows.Forms.Padding(3, 3, 20, 100);
            this.btnAddLicense.Name = "btnAddLicense";
            this.btnAddLicense.Size = new System.Drawing.Size(110, 39);
            this.btnAddLicense.TabIndex = 29;
            this.btnAddLicense.Text = "Add";
            this.btnAddLicense.UseVisualStyleBackColor = true;
            this.btnAddLicense.Click += new System.EventHandler(this.btnAddLicense_Click);
            // 
            // UC_LicenseMain1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_LicenseMain1";
            this.Size = new System.Drawing.Size(521, 375);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnLicenseView1;
        private System.Windows.Forms.Button btnAddLicense;
    }
}
