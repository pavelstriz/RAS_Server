
namespace TcpServer
{
    partial class EditExpiration
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
            this.label9 = new System.Windows.Forms.Label();
            this.dateExp = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dateSince = new System.Windows.Forms.DateTimePicker();
            this.btnSaveExpiration = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(19, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 17);
            this.label9.TabIndex = 40;
            this.label9.Text = "Expire";
            // 
            // dateExp
            // 
            this.dateExp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateExp.Location = new System.Drawing.Point(79, 66);
            this.dateExp.Name = "dateExp";
            this.dateExp.Size = new System.Drawing.Size(111, 22);
            this.dateExp.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(23, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 17);
            this.label8.TabIndex = 38;
            this.label8.Text = "Since";
            // 
            // dateSince
            // 
            this.dateSince.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateSince.Location = new System.Drawing.Point(79, 24);
            this.dateSince.Name = "dateSince";
            this.dateSince.Size = new System.Drawing.Size(111, 22);
            this.dateSince.TabIndex = 37;
            // 
            // btnSaveExpiration
            // 
            this.btnSaveExpiration.Location = new System.Drawing.Point(198, 37);
            this.btnSaveExpiration.Name = "btnSaveExpiration";
            this.btnSaveExpiration.Size = new System.Drawing.Size(113, 39);
            this.btnSaveExpiration.TabIndex = 41;
            this.btnSaveExpiration.Text = "Save";
            this.btnSaveExpiration.UseVisualStyleBackColor = true;
            this.btnSaveExpiration.Click += new System.EventHandler(this.btnSaveExpiration_Click);
            // 
            // EditExpiration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 105);
            this.Controls.Add(this.btnSaveExpiration);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dateExp);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateSince);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EditExpiration";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expiration";
            this.Load += new System.EventHandler(this.EditExpiration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.DateTimePicker dateExp;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.DateTimePicker dateSince;
        private System.Windows.Forms.Button btnSaveExpiration;
    }
}