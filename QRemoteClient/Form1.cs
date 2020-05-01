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
            headerPB.Top = 0;
            headerPB.BackColor = Color.FromArgb(39, 150, 214);

            // Получение информации из конфига
            cfg = ConfigManager.GetConfigData();

            // Запись серверов в комбобокс
            localIPCoboBox.Items.Clear();
            localIPCoboBox.Items.AddRange(cfg.Servers.ToArray());
            if (localIPCoboBox.Items.Count > 0)
                localIPCoboBox.Text = localIPCoboBox.Items[localIPCoboBox.Items.Count - 1].ToString();

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            // Работа со списком серверов
            string tmp = localIPCoboBox.Text;
            localIPCoboBox.Items.Remove(tmp);
            localIPCoboBox.Items.Add(tmp);
            cfg.Servers.Remove(tmp);
            cfg.Servers.Add(tmp);
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
            // Разворачивание формы при клике на иконку в трее
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
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
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Закрытие всех соединений при закрытии программы
            foreach (var ScreenView in ScreenViewers)
                if(!ScreenView.IsDisposed)
                    ScreenView.client.StopClient();
        }

        private void LinkLabel1_Click(object sender, EventArgs e)
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
    }
}
