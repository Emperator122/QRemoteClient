using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRemoteClient
{
    public partial class Form1 : Form
    {
        public static List<ScreenViewer> ScreenViewers = new List<ScreenViewer>();

        public Form1()
        {
            InitializeComponent();
            headerPB.Width = this.Width;
            headerPB.Left = 0;
            headerPB.Top = 0;
            headerPB.BackColor = Color.FromArgb(39, 150, 214);

            updateServerList();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ServerListManager.AddServer(localIPCoboBox.Text);
            updateServerList();
            string[] temp = localIPCoboBox.Text.Split(':');
            string ip = temp[0];
            int port = Convert.ToInt32(temp[1]);
            int timeout = Convert.ToInt32(timeoutTextBox.Text);
            ScreenViewers.Add(new ScreenViewer(ip, port, timeout));
            ScreenViewers[ScreenViewers.Count - 1].Show();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void NotifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Form1_Resize(sender, e);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var ScreenView in ScreenViewers)
                if(!ScreenView.IsDisposed)
                    ScreenView.client.StopClient();
        }
        private void updateServerList()
        {
            localIPCoboBox.Items.Clear();
            localIPCoboBox.Items.AddRange(ServerListManager.GetServers().ToArray());
            if (localIPCoboBox.Items.Count > 0)
                localIPCoboBox.Text = localIPCoboBox.Items[localIPCoboBox.Items.Count - 1].ToString();
        }
    }
}
