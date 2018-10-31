using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CryptChatAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void GettingLocalIps()
        {
            lbStatusWaiting.ForeColor = Color.Orange;
            lbStatusWaiting.Text = "Getting ip's list...";
            lbStatusWaiting.Visible = true;
            cbWaitConnection.Items.Clear();
            IPAddress[] myIps = await Dns.GetHostAddressesAsync(Dns.GetHostName());
            foreach (IPAddress ip in myIps)
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    cbWaitConnection.Items.Add(ip.ToString());

            if (cbWaitConnection.Items.Count > 0)
            {
                cbWaitConnection.SelectedIndex = 0;
                bWaitConnection.Enabled = true;
                lbStatusWaiting.ForeColor = Color.Green;
                lbStatusWaiting.Text = "Choise your ip and click \"Wait connection\"";
            }
            else if (cbWaitConnection.Items.Count == 0)
            {
                lbStatusWaiting.ForeColor = Color.Red;
                lbStatusWaiting.Text = "No IP's found!";
            }
        }

        private async void bConnect_Click(object sender, EventArgs e)
        {
            bConnect.Enabled = false;
            KeyExchange kex = new KeyExchange();
            FormMessages fm = new FormMessages();
            Thread t;

            bool isConnect = await kex.ConnectAsync(cbIpsConnect.Text);
            if (isConnect)
            {
                lbStatusConnection.ForeColor = Color.Green;
                lbStatusConnection.Text = "Connection success!";
                t = new Thread(() => fm.ShowDialog());
                t.Start();
                this.Visible = false;
            }
            else
            {
                lbStatusConnection.ForeColor = Color.Red;
                lbStatusConnection.Text = "Connection FAILED!";
            }
            bConnect.Enabled = true;
        }

        private async void bWaitConnection_Click(object sender, EventArgs e)
        {
            bWaitConnection.Enabled = false;
            lbStatusWaiting.ForeColor = Color.Orange;
            lbStatusWaiting.Text = "Waiting for client...";
            FormMessages fm = new FormMessages();
            Thread t;

            KeyExchange kex = new KeyExchange();
            bool wait = await kex.WaitForKeyAsync(cbWaitConnection.Text);
            if (wait)
            {
                lbStatusWaiting.ForeColor = Color.Green;
                lbStatusWaiting.Text = "Connection success!";
                t = new Thread(() => fm.ShowDialog());
                t.Start();
                this.Visible = false;
            }
            else 
            {
                lbStatusWaiting.ForeColor = Color.Red;
                lbStatusWaiting.Text = "Connection FAILED!";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Properties.Resources.Title;
            GettingLocalIps();
            lbStatusConnection.Visible = true;
            lbStatusConnection.ForeColor = Color.Green;
            lbStatusConnection.Text = "Input ip for connection and click \"Connect\"";
        }
    }
}
