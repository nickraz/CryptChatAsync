namespace CryptChatAsync
{
    partial class FormMessages
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
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.bSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbLog
            // 
            this.rtbLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbLog.Location = new System.Drawing.Point(12, 12);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbLog.Size = new System.Drawing.Size(556, 167);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // tbMessage
            // 
            this.tbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMessage.Location = new System.Drawing.Point(12, 185);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMessage.Size = new System.Drawing.Size(556, 119);
            this.tbMessage.TabIndex = 1;
            this.tbMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMessage_KeyDown);
            // 
            // bSend
            // 
            this.bSend.Location = new System.Drawing.Point(493, 323);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(75, 23);
            this.bSend.TabIndex = 2;
            this.bSend.Text = "Send";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // FormMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 358);
            this.Controls.Add(this.bSend);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.rtbLog);
            this.Name = "FormMessages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMessages_FormClosing);
            this.Load += new System.EventHandler(this.FormMessages_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button bSend;
    }
}