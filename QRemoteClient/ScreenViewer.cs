using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRemoteClient
{
    public partial class ScreenViewer : Form
    {
        public AsynchronousClient client;
        public ScreenViewer(string serverip, int serverport = 11000, int updateTimeout = 0)
        {
            InitializeComponent();
            client = new AsynchronousClient();
            client.StartClient(screenPictureBox, serverip, serverport, updateTimeout);
        }

        private void DisconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client.StopClient();
            Form1.ScreenViewers.Remove(this);
            Dispose();

        }

        private void ScreenViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectToolStripMenuItem_Click(this, e);
        }

        private void FullScreenStripMenuItem_Click(object sender, EventArgs e)
        {
            if(FormBorderStyle != FormBorderStyle.None)
            {
                TopMost = true;
                this.Update();
                FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Minimized;
                this.WindowState = FormWindowState.Maximized;
                MinimumSize = Screen.PrimaryScreen.Bounds.Size;
                FullScreenStripMenuItem.Text = "Отключить полноэкранный режим";
            }
            else
            {
                TopMost = false;
                this.Update();
                FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Maximized;
                MinimumSize = new Size(0,0);
                FullScreenStripMenuItem.Text = "Полный экран";
            }

        }
    }
}
