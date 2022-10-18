namespace TcpServer
{
    partial class UC_RemoteCommand1
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnShowCommands = new System.Windows.Forms.Button();
            this.txtRemoteCommandConsole = new System.Windows.Forms.RichTextBox();
            this.btnExecuteCommand = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCommandToSend = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(16, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Client:";
            // 
            // btnShowCommands
            // 
            this.btnShowCommands.Location = new System.Drawing.Point(321, 68);
            this.btnShowCommands.Name = "btnShowCommands";
            this.btnShowCommands.Size = new System.Drawing.Size(89, 27);
            this.btnShowCommands.TabIndex = 10;
            this.btnShowCommands.Text = "Commands";
            this.btnShowCommands.UseVisualStyleBackColor = true;
            this.btnShowCommands.Click += new System.EventHandler(this.btnShowCommands_Click);
            // 
            // txtRemoteCommandConsole
            // 
            this.txtRemoteCommandConsole.Location = new System.Drawing.Point(19, 112);
            this.txtRemoteCommandConsole.Name = "txtRemoteCommandConsole";
            this.txtRemoteCommandConsole.Size = new System.Drawing.Size(478, 240);
            this.txtRemoteCommandConsole.TabIndex = 9;
            this.txtRemoteCommandConsole.Text = "";
            // 
            // btnExecuteCommand
            // 
            this.btnExecuteCommand.Location = new System.Drawing.Point(416, 68);
            this.btnExecuteCommand.Name = "btnExecuteCommand";
            this.btnExecuteCommand.Size = new System.Drawing.Size(81, 27);
            this.btnExecuteCommand.TabIndex = 8;
            this.btnExecuteCommand.Text = "Execute";
            this.btnExecuteCommand.UseVisualStyleBackColor = true;
            this.btnExecuteCommand.Click += new System.EventHandler(this.btnExecuteCommand_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Enter command";
            // 
            // txtCommandToSend
            // 
            this.txtCommandToSend.Location = new System.Drawing.Point(19, 40);
            this.txtCommandToSend.Name = "txtCommandToSend";
            this.txtCommandToSend.Size = new System.Drawing.Size(478, 22);
            this.txtCommandToSend.TabIndex = 6;
            // 
            // UC_RemoteCommand1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnShowCommands);
            this.Controls.Add(this.txtRemoteCommandConsole);
            this.Controls.Add(this.btnExecuteCommand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCommandToSend);
            this.Name = "UC_RemoteCommand1";
            this.Size = new System.Drawing.Size(521, 375);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnShowCommands;
        public System.Windows.Forms.RichTextBox txtRemoteCommandConsole;
        private System.Windows.Forms.Button btnExecuteCommand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCommandToSend;
    }
}
