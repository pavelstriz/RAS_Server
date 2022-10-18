
namespace TcpServer
{
    partial class Blacklist
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvBanlist1 = new System.Windows.Forms.DataGridView();
            this.btnEditBlacklist = new System.Windows.Forms.Button();
            this.btnAddToBlacklist = new System.Windows.Forms.Button();
            this.btnRemove1 = new System.Windows.Forms.Button();
            this.btnClose1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanlist1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBanlist1
            // 
            this.dgvBanlist1.AllowUserToAddRows = false;
            this.dgvBanlist1.AllowUserToDeleteRows = false;
            this.dgvBanlist1.AllowUserToResizeColumns = false;
            this.dgvBanlist1.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightGray;
            this.dgvBanlist1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBanlist1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBanlist1.BackgroundColor = System.Drawing.Color.White;
            this.dgvBanlist1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBanlist1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBanlist1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBanlist1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBanlist1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBanlist1.GridColor = System.Drawing.SystemColors.ScrollBar;
            this.dgvBanlist1.Location = new System.Drawing.Point(-8, 0);
            this.dgvBanlist1.Margin = new System.Windows.Forms.Padding(0);
            this.dgvBanlist1.MultiSelect = false;
            this.dgvBanlist1.Name = "dgvBanlist1";
            this.dgvBanlist1.ReadOnly = true;
            this.dgvBanlist1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBanlist1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBanlist1.RowHeadersVisible = false;
            this.dgvBanlist1.RowHeadersWidth = 51;
            this.dgvBanlist1.RowTemplate.Height = 24;
            this.dgvBanlist1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBanlist1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBanlist1.Size = new System.Drawing.Size(471, 191);
            this.dgvBanlist1.TabIndex = 1;
            // 
            // btnEditBlacklist
            // 
            this.btnEditBlacklist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditBlacklist.Location = new System.Drawing.Point(294, 197);
            this.btnEditBlacklist.Name = "btnEditBlacklist";
            this.btnEditBlacklist.Size = new System.Drawing.Size(75, 31);
            this.btnEditBlacklist.TabIndex = 6;
            this.btnEditBlacklist.Text = "Edit";
            this.btnEditBlacklist.UseVisualStyleBackColor = true;
            this.btnEditBlacklist.Click += new System.EventHandler(this.btnEditBlacklist_Click);
            // 
            // btnAddToBlacklist
            // 
            this.btnAddToBlacklist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToBlacklist.Location = new System.Drawing.Point(213, 197);
            this.btnAddToBlacklist.Name = "btnAddToBlacklist";
            this.btnAddToBlacklist.Size = new System.Drawing.Size(75, 31);
            this.btnAddToBlacklist.TabIndex = 7;
            this.btnAddToBlacklist.Text = "Add";
            this.btnAddToBlacklist.UseVisualStyleBackColor = true;
            this.btnAddToBlacklist.Click += new System.EventHandler(this.btnAddToBlacklist_Click);
            // 
            // btnRemove1
            // 
            this.btnRemove1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove1.Location = new System.Drawing.Point(375, 197);
            this.btnRemove1.Name = "btnRemove1";
            this.btnRemove1.Size = new System.Drawing.Size(75, 31);
            this.btnRemove1.TabIndex = 8;
            this.btnRemove1.Text = "Remove";
            this.btnRemove1.UseVisualStyleBackColor = true;
            this.btnRemove1.Click += new System.EventHandler(this.btnRemove1_Click);
            // 
            // btnClose1
            // 
            this.btnClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose1.Location = new System.Drawing.Point(6, 197);
            this.btnClose1.Name = "btnClose1";
            this.btnClose1.Size = new System.Drawing.Size(75, 31);
            this.btnClose1.TabIndex = 9;
            this.btnClose1.Text = "Close";
            this.btnClose1.UseVisualStyleBackColor = true;
            this.btnClose1.Click += new System.EventHandler(this.btnClose1_Click);
            // 
            // Blacklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 233);
            this.Controls.Add(this.btnClose1);
            this.Controls.Add(this.btnRemove1);
            this.Controls.Add(this.btnAddToBlacklist);
            this.Controls.Add(this.btnEditBlacklist);
            this.Controls.Add(this.dgvBanlist1);
            this.Name = "Blacklist";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blacklist";
            this.Load += new System.EventHandler(this.Banlist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanlist1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnEditBlacklist;
        private System.Windows.Forms.Button btnAddToBlacklist;
        private System.Windows.Forms.Button btnRemove1;
        private System.Windows.Forms.Button btnClose1;
        private System.Windows.Forms.DataGridView dgvBanlist1;
    }
}