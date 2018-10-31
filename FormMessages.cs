using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace CryptChatAsync
{
    public partial class FormMessages : Form
    {
        CryptedMessages cryMes = new CryptedMessages();

        public FormMessages()
        {
            InitializeComponent();
        }

        private void FormMessages_Load(object sender, EventArgs e)
        {
            Thread t1 = new Thread(() => cryMes.WaitForMessage(rtbLog));
            t1.IsBackground = true;
            t1.Start();
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            cryMes.SendMessage(tbMessage.Text);
            rtbLog.Text += "Я: " + tbMessage.Text.Trim() + Environment.NewLine;
            tbMessage.Text = "";
        }

        private void FormMessages_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                bSend.PerformClick();
                SendKeys.Send("{BS}");
            }
        }
    }
}
