namespace CryptChatAsync
{
    partial class Form1
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
            this.bConnect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbIpsConnect = new System.Windows.Forms.ComboBox();
            this.lbStatusConnection = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbWaitConnection = new System.Windows.Forms.ComboBox();
            this.bWaitConnection = new System.Windows.Forms.Button();
            this.lbStatusWaiting = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bConnect
            // 
            this.bConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bConnect.Location = new System.Drawing.Point(82, 47);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(205, 66);
            this.bConnect.TabIndex = 0;
            this.bConnect.Text = "Connect";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbStatusConnection);
            this.groupBox1.Controls.Add(this.cbIpsConnect);
            this.groupBox1.Controls.Add(this.bConnect);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 169);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection properties";
            // 
            // cbIpsConnect
            // 
            this.cbIpsConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbIpsConnect.FormattingEnabled = true;
            this.cbIpsConnect.Location = new System.Drawing.Point(82, 17);
            this.cbIpsConnect.Name = "cbIpsConnect";
            this.cbIpsConnect.Size = new System.Drawing.Size(205, 24);
            this.cbIpsConnect.TabIndex = 2;
            // 
            // lbStatusConnection
            // 
            this.lbStatusConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStatusConnection.Location = new System.Drawing.Point(79, 116);
            this.lbStatusConnection.Name = "lbStatusConnection";
            this.lbStatusConnection.Size = new System.Drawing.Size(208, 37);
            this.lbStatusConnection.TabIndex = 3;
            this.lbStatusConnection.Text = "label1";
            this.lbStatusConnection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbStatusConnection.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbStatusWaiting);
            this.groupBox2.Controls.Add(this.bWaitConnection);
            this.groupBox2.Controls.Add(this.cbWaitConnection);
            this.groupBox2.Location = new System.Drawing.Point(12, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(359, 198);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Waiting for client";
            // 
            // cbWaitConnection
            // 
            this.cbWaitConnection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWaitConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbWaitConnection.FormattingEnabled = true;
            this.cbWaitConnection.Location = new System.Drawing.Point(82, 38);
            this.cbWaitConnection.Name = "cbWaitConnection";
            this.cbWaitConnection.Size = new System.Drawing.Size(205, 24);
            this.cbWaitConnection.TabIndex = 2;
            // 
            // bWaitConnection
            // 
            this.bWaitConnection.Enabled = false;
            this.bWaitConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.bWaitConnection.Location = new System.Drawing.Point(82, 68);
            this.bWaitConnection.Name = "bWaitConnection";
            this.bWaitConnection.Size = new System.Drawing.Size(205, 66);
            this.bWaitConnection.TabIndex = 3;
            this.bWaitConnection.Text = "Wait connection";
            this.bWaitConnection.UseVisualStyleBackColor = true;
            this.bWaitConnection.Click += new System.EventHandler(this.bWaitConnection_Click);
            // 
            // lbStatusWaiting
            // 
            this.lbStatusWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStatusWaiting.Location = new System.Drawing.Point(79, 137);
            this.lbStatusWaiting.Name = "lbStatusWaiting";
            this.lbStatusWaiting.Size = new System.Drawing.Size(208, 48);
            this.lbStatusWaiting.TabIndex = 3;
            this.lbStatusWaiting.Text = "label1";
            this.lbStatusWaiting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbStatusWaiting.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 395);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(399, 434);
            this.MinimumSize = new System.Drawing.Size(399, 434);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Title";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbIpsConnect;
        private System.Windows.Forms.Label lbStatusConnection;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bWaitConnection;
        private System.Windows.Forms.ComboBox cbWaitConnection;
        private System.Windows.Forms.Label lbStatusWaiting;
    }
}

