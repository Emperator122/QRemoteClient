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
        // Конфиг
        public ConfigData cfg;
        // Формы для просмотра экранов
        public static List<ScreenViewer> ScreenViewers = new List<ScreenViewer>();

        public Form1()
        {
            InitializeComponent();
            headerPB.Width = this.Width;
            headerPB.Left = 0;
            headerPB.Top = menuStrip1.Height;
            headerPB.BackColor = Color.FromArgb(39, 150, 214);

            // Получение информации из конфига
            cfg = ConfigManager.GetConfigData();

            // Запись серверов в комбобокс
            localIPCoboBox.Items.Clear();
            foreach (var server in cfg.Servers)
                server.isAvailable = false;
            localIPCoboBox.Items.AddRange(cfg.Servers.ToArray());
            if (localIPCoboBox.Items.Count > 0)
                localIPCoboBox.Text = localIPCoboBox.Items[localIPCoboBox.Items.Count - 1].ToString();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            // Работа со списком серверов
            string tmp = localIPCoboBox.Text;
            int index = cfg.FindIP(tmp);
            ComboBoxRow item = new ComboBoxRow(tmp);
            if(index != -1)
            {
                item = (ComboBoxRow)localIPCoboBox.Items[index];
                localIPCoboBox.Items.RemoveAt(index);
                cfg.Servers.RemoveAt(index);
            }
            localIPCoboBox.Items.Add(item);
            cfg.Servers.Add(item);
            if (localIPCoboBox.Items.Count > 0)
                localIPCoboBox.Text = localIPCoboBox.Items[localIPCoboBox.Items.Count - 1].ToString();
            ConfigManager.SaveConfigData(cfg);
            // Запуск клиента
            string[] temp = localIPCoboBox.Text.Split(':');
            string ip = temp[0];
            int port = Convert.ToInt32(temp[1]);
            int timeout = Convert.ToInt32(timeoutTextBox.Text);
            ScreenViewers.Add(new ScreenViewer((int)qualityVal.Value,ip, port, timeout));
            ScreenViewers[ScreenViewers.Count - 1].Show();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //Сворачивание в трей
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void NotifyIcon1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // Сворачивание формы в трей при старте
            WindowState = FormWindowState.Minimized;
            Form1_Resize(sender, e);

            // Добавление приложения в автозагузку
            if (cfg.AutoRun)
            {
                if (!AutorunManager.isAppOnAutorun() && !AutorunManager.SetAutorunValue(true))
                    MessageBox.Show("Не удалось добавить приложение в автозагрузку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                if (AutorunManager.isAppOnAutorun())
                AutorunManager.SetAutorunValue(false);

            CheckServers();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Закрытие всех соединений при закрытии программы
            foreach (var ScreenView in ScreenViewers)
                if(!ScreenView.IsDisposed)
                    ScreenView.client.StopClient();
            ConfigManager.SaveConfigData(cfg);
        }

        private async void CheckServers()
        {
            UpdateServersStripMenuItem.Enabled = false;
            ComboBoxRow[] rows = new ComboBoxRow[localIPCoboBox.Items.Count];
            localIPCoboBox.Items.CopyTo(rows, 0);
            foreach (ComboBoxRow item in rows)
            { 
                string[] temp = item.ToString().Split(':');
                item.isAvailable = await Task.Factory.StartNew<bool>(
                    () => SynchronousClient.CheckServer(temp[0], Convert.ToInt32(temp[1])), TaskCreationOptions.LongRunning);

            }
            UpdateServersStripMenuItem.Enabled = true;
        }


        private void LocalIPCoboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBoxRow item = (ComboBoxRow)localIPCoboBox.Items[e.Index];
            e.DrawBackground();
            Brush b = Brushes.Black;
            if (item.isAvailable)
                b = Brushes.ForestGreen;
            e.Graphics.DrawString(item.Name != "" ? item.Name + " || " + item.IP 
                : item.IP , e.Font, b, e.Bounds);
        }


        private void ToolStripExitButton1_Click(object sender, EventArgs e)
        {
            Form1_FormClosing(sender, new FormClosingEventArgs(CloseReason.UserClosing, false));
            Application.Exit();
        }

        private void ToolStripRestoreButton_Click(object sender, EventArgs e)
        {
            NotifyIcon1_MouseClick(sender, new MouseEventArgs(MouseButtons.Left,0,0,0,0));
        }

        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            // Разворачивание формы при клике на иконку в трее
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
            }
        }

        private void RemoveIPStripMenuItem_Click(object sender, EventArgs e)
        {
            int ind = localIPCoboBox.SelectedIndex;
            if (ind != -1)
            {
                localIPCoboBox.Items.RemoveAt(ind);
                cfg.Servers.RemoveAt(ind);
                localIPCoboBox.SelectedIndex = -1;
                ConfigManager.SaveConfigData(cfg);
            }
        }

        private void UpdateServersStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckServers();
        }

        private void StartButton1_MouseEnter(object sender, EventArgs e)
        {
            startButton1.Cursor = Cursors.Hand;
        }

        private void StartButton1_MouseLeave(object sender, EventArgs e)
        {
            startButton1.Cursor = Cursors.Default;
        }

        private void ServerNameTextBox1_TextChanged(object sender, EventArgs e)
        {
            int ind = localIPCoboBox.SelectedIndex;
            if (ind != -1)
            {
                ((ComboBoxRow)localIPCoboBox.Items[ind]).Name = ServerNameTextBox1.Text;
                cfg.Servers[ind].Name = ServerNameTextBox1.Text;
            }
        }

        private void LocalIPCoboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (localIPCoboBox.SelectedIndex != -1)
            {
                ServerNameTextBox1.Text = ((ComboBoxRow)localIPCoboBox.SelectedItem).Name;
                ServerNameTextBox1.Enabled = true;
            }
            else
            {
                ServerNameTextBox1.Text = "Серв не в списке";
                ServerNameTextBox1.Enabled = false;
            }
        }
    }

    public class ComboBoxRow
    {
        public string IP;
        public string Name = "";
        public bool isAvailable = false;
        public override string ToString()
        {
            return IP;
        }
        public ComboBoxRow(string ip)
        {
            IP = ip;
        }
        public ComboBoxRow()
        {

        }
    }
}
