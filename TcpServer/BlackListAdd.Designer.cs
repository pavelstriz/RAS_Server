
namespace TcpServer
{
    partial class BlackListAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBLName1 = new System.Windows.Forms.TextBox();
            this.txtBLipAddress1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBLmac1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd1 = new System.Windows.Forms.Button();
            this.btnStorno1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // txtBLName1
            // 
            this.txtBLName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtBLName1.Location = new System.Drawing.Point(16, 32);
            this.txtBLName1.Name = "txtBLName1";
            this.txtBLName1.Size = new System.Drawing.Size(209, 27);
            this.txtBLName1.TabIndex = 3;
            // 
            // txtBLipAddress1
            // 
            this.txtBLipAddress1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtBLipAddress1.Location = new System.Drawing.Point(16, 85);
            this.txtBLipAddress1.Name = "txtBLipAddress1";
            this.txtBLipAddress1.Size = new System.Drawing.Size(209, 27);
            this.txtBLipAddress1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ip Address";
            // 
            // txtBLmac1
            // 
            this.txtBLmac1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtBLmac1.Location = new System.Drawing.Point(16, 138);
            this.txtBLmac1.Name = "txtBLmac1";
            this.txtBLmac1.Size = new System.Drawing.Size(209, 27);
            this.txtBLmac1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "MAC";
            // 
            // btnAdd1
            // 
            this.btnAdd1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAdd1.Location = new System.Drawing.Point(126, 176);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(99, 35);
            this.btnAdd1.TabIndex = 8;
            this.btnAdd1.Text = "Ok";
            this.btnAdd1.UseVisualStyleBackColor = true;
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // btnStorno1
            // 
            this.btnStorno1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStorno1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnStorno1.Location = new System.Drawing.Point(16, 176);
            this.btnStorno1.Name = "btnStorno1";
            this.btnStorno1.Size = new System.Drawing.Size(99, 35);
            this.btnStorno1.TabIndex = 9;
            this.btnStorno1.Text = "Storno";
            this.btnStorno1.UseVisualStyleBackColor = true;
            this.btnStorno1.Click += new System.EventHandler(this.btnStorno1_Click);
            // 
            // BlackListAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 219);
            this.Controls.Add(this.btnStorno1);
            this.Controls.Add(this.btnAdd1);
            this.Controls.Add(this.txtBLmac1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBLipAddress1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBLName1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BlackListAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd1;
        private System.Windows.Forms.Button btnStorno1;
        public System.Windows.Forms.TextBox txtBLName1;
        public System.Windows.Forms.TextBox txtBLipAddress1;
        public System.Windows.Forms.TextBox txtBLmac1;
    }
}