
namespace TcpServer
{
    partial class UC_TaskScheduler1
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
            this.chbEndsAt = new System.Windows.Forms.CheckBox();
            this.btnExecuteTaskScheduler = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTaskArgs = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTaskProgScript = new System.Windows.Forms.TextBox();
            this.cbRepeatsNumber1 = new System.Windows.Forms.ComboBox();
            this.cbRepeatOption1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtTaskDesc = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chbEndsAt
            // 
            this.chbEndsAt.AutoSize = true;
            this.chbEndsAt.Location = new System.Drawing.Point(28, 298);
            this.chbEndsAt.Name = "chbEndsAt";
            this.chbEndsAt.Size = new System.Drawing.Size(82, 21);
            this.chbEndsAt.TabIndex = 66;
            this.chbEndsAt.Text = "Ends at:";
            this.chbEndsAt.UseVisualStyleBackColor = true;
            this.chbEndsAt.CheckedChanged += new System.EventHandler(this.chbEndsAt_CheckedChanged);
            // 
            // btnExecuteTaskScheduler
            // 
            this.btnExecuteTaskScheduler.Location = new System.Drawing.Point(377, 311);
            this.btnExecuteTaskScheduler.Name = "btnExecuteTaskScheduler";
            this.btnExecuteTaskScheduler.Size = new System.Drawing.Size(120, 48);
            this.btnExecuteTaskScheduler.TabIndex = 65;
            this.btnExecuteTaskScheduler.Text = "Execute";
            this.btnExecuteTaskScheduler.UseVisualStyleBackColor = true;
            this.btnExecuteTaskScheduler.Click += new System.EventHandler(this.btnExecuteTaskScheduler_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 64;
            this.label7.Text = "Arguments:";
            // 
            // txtTaskArgs
            // 
            this.txtTaskArgs.Location = new System.Drawing.Point(29, 202);
            this.txtTaskArgs.Name = "txtTaskArgs";
            this.txtTaskArgs.Size = new System.Drawing.Size(468, 22);
            this.txtTaskArgs.TabIndex = 63;
            this.txtTaskArgs.Text = "/c shutdown -s";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 17);
            this.label6.TabIndex = 62;
            this.label6.Text = "Run program or script:";
            // 
            // txtTaskProgScript
            // 
            this.txtTaskProgScript.Location = new System.Drawing.Point(29, 154);
            this.txtTaskProgScript.Name = "txtTaskProgScript";
            this.txtTaskProgScript.Size = new System.Drawing.Size(468, 22);
            this.txtTaskProgScript.TabIndex = 61;
            this.txtTaskProgScript.Text = "cmd.exe";
            // 
            // cbRepeatsNumber1
            // 
            this.cbRepeatsNumber1.FormattingEnabled = true;
            this.cbRepeatsNumber1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.cbRepeatsNumber1.Location = new System.Drawing.Point(264, 264);
            this.cbRepeatsNumber1.Name = "cbRepeatsNumber1";
            this.cbRepeatsNumber1.Size = new System.Drawing.Size(48, 24);
            this.cbRepeatsNumber1.TabIndex = 60;
            this.cbRepeatsNumber1.Text = "1";
            // 
            // cbRepeatOption1
            // 
            this.cbRepeatOption1.FormattingEnabled = true;
            this.cbRepeatOption1.Items.AddRange(new object[] {
            "Days",
            "Weeks",
            "Months",
            "Years"});
            this.cbRepeatOption1.Location = new System.Drawing.Point(318, 264);
            this.cbRepeatOption1.Name = "cbRepeatOption1";
            this.cbRepeatOption1.Size = new System.Drawing.Size(83, 24);
            this.cbRepeatOption1.TabIndex = 59;
            this.cbRepeatOption1.Text = "Days";
            this.cbRepeatOption1.SelectedIndexChanged += new System.EventHandler(this.cbRepeatsDate1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 58;
            this.label5.Text = "Repeat every:";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Enabled = false;
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(146, 322);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(86, 22);
            this.dtpEndTime.TabIndex = 57;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(146, 266);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(86, 22);
            this.dtpStartTime.TabIndex = 56;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(29, 322);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(111, 22);
            this.dtpEndDate.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 54;
            this.label3.Text = "Starts at:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(29, 266);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(111, 22);
            this.dtpStartDate.TabIndex = 53;
            // 
            // txtTaskDesc
            // 
            this.txtTaskDesc.Location = new System.Drawing.Point(29, 86);
            this.txtTaskDesc.Name = "txtTaskDesc";
            this.txtTaskDesc.Size = new System.Drawing.Size(468, 45);
            this.txtTaskDesc.TabIndex = 52;
            this.txtTaskDesc.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 51;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 50;
            this.label1.Text = "Task name";
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(28, 36);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(215, 22);
            this.txtTaskName.TabIndex = 49;
            // 
            // UC_TaskScheduler1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chbEndsAt);
            this.Controls.Add(this.btnExecuteTaskScheduler);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTaskArgs);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTaskProgScript);
            this.Controls.Add(this.cbRepeatsNumber1);
            this.Controls.Add(this.cbRepeatOption1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.txtTaskDesc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTaskName);
            this.Name = "UC_TaskScheduler1";
            this.Size = new System.Drawing.Size(521, 375);
            this.Load += new System.EventHandler(this.UC_TaskScheduler1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbEndsAt;
        private System.Windows.Forms.Button btnExecuteTaskScheduler;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTaskArgs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTaskProgScript;
        private System.Windows.Forms.ComboBox cbRepeatsNumber1;
        private System.Windows.Forms.ComboBox cbRepeatOption1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DateTimePicker dtpEndTime;
        public System.Windows.Forms.DateTimePicker dtpStartTime;
        public System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.RichTextBox txtTaskDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTaskName;
    }
}
