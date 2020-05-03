namespace QRemoteClient
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.headerPB = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.startButton1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.qualityVal = new System.Windows.Forms.NumericUpDown();
            this.timeoutTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.localIPCoboBox = new System.Windows.Forms.ComboBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripRestoreButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripExitButton1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateServersStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.SetNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerNameTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.RemoveIPStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.headerPB)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qualityVal)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPB
            // 
            this.headerPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerPB.BackColor = System.Drawing.SystemColors.Window;
            this.headerPB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("headerPB.BackgroundImage")));
            this.headerPB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.headerPB.Location = new System.Drawing.Point(0, 26);
            this.headerPB.Name = "headerPB";
            this.headerPB.Size = new System.Drawing.Size(446, 85);
            this.headerPB.TabIndex = 2;
            this.headerPB.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.startButton1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.qualityVal);
            this.groupBox1.Controls.Add(this.timeoutTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.localIPCoboBox);
            this.groupBox1.Location = new System.Drawing.Point(1, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 108);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // startButton1
            // 
            this.startButton1.Image = ((System.Drawing.Image)(resources.GetObject("startButton1.Image")));
            this.startButton1.Location = new System.Drawing.Point(336, 8);
            this.startButton1.Name = "startButton1";
            this.startButton1.Size = new System.Drawing.Size(96, 96);
            this.startButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.startButton1.TabIndex = 9;
            this.startButton1.TabStop = false;
            this.startButton1.Click += new System.EventHandler(this.StartButton_Click);
            this.startButton1.MouseEnter += new System.EventHandler(this.StartButton1_MouseEnter);
            this.startButton1.MouseLeave += new System.EventHandler(this.StartButton1_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Качество (0-100):";
            // 
            // qualityVal
            // 
            this.qualityVal.Location = new System.Drawing.Point(135, 76);
            this.qualityVal.Name = "qualityVal";
            this.qualityVal.Size = new System.Drawing.Size(175, 20);
            this.qualityVal.TabIndex = 7;
            this.qualityVal.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // timeoutTextBox
            // 
            this.timeoutTextBox.Location = new System.Drawing.Point(135, 50);
            this.timeoutTextBox.Name = "timeoutTextBox";
            this.timeoutTextBox.Size = new System.Drawing.Size(175, 20);
            this.timeoutTextBox.TabIndex = 5;
            this.timeoutTextBox.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Таймаут (ms):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Локальный IP:Порт:";
            // 
            // localIPCoboBox
            // 
            this.localIPCoboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.localIPCoboBox.FormattingEnabled = true;
            this.localIPCoboBox.Location = new System.Drawing.Point(135, 22);
            this.localIPCoboBox.Name = "localIPCoboBox";
            this.localIPCoboBox.Size = new System.Drawing.Size(175, 21);
            this.localIPCoboBox.TabIndex = 2;
            this.localIPCoboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LocalIPCoboBox_DrawItem);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "QRemoteClient";
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripRestoreButton,
            this.toolStripExitButton1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(136, 48);
            // 
            // toolStripRestoreButton
            // 
            this.toolStripRestoreButton.Name = "toolStripRestoreButton";
            this.toolStripRestoreButton.Size = new System.Drawing.Size(135, 22);
            this.toolStripRestoreButton.Text = "Развернуть";
            this.toolStripRestoreButton.Click += new System.EventHandler(this.ToolStripRestoreButton_Click);
            // 
            // toolStripExitButton1
            // 
            this.toolStripExitButton1.Name = "toolStripExitButton1";
            this.toolStripExitButton1.Size = new System.Drawing.Size(135, 22);
            this.toolStripExitButton1.Text = "Выход";
            this.toolStripExitButton1.Click += new System.EventHandler(this.ToolStripExitButton1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(447, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateServersStripMenuItem,
            this.toolStripMenuItem2});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(68, 20);
            this.toolStripMenuItem1.Text = "Функции";
            this.toolStripMenuItem1.DropDownOpened += new System.EventHandler(this.ToolStripMenuItem1_DropDownOpened);
            // 
            // UpdateServersStripMenuItem
            // 
            this.UpdateServersStripMenuItem.Name = "UpdateServersStripMenuItem";
            this.UpdateServersStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.UpdateServersStripMenuItem.Text = "Проверить список серверов";
            this.UpdateServersStripMenuItem.Click += new System.EventHandler(this.UpdateServersStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetNameToolStripMenuItem,
            this.RemoveIPStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(230, 22);
            this.toolStripMenuItem2.Text = "Выбранный сервер";
            // 
            // SetNameToolStripMenuItem
            // 
            this.SetNameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ServerNameTextBox1});
            this.SetNameToolStripMenuItem.Name = "SetNameToolStripMenuItem";
            this.SetNameToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.SetNameToolStripMenuItem.Text = "Задать имя";
            // 
            // ServerNameTextBox1
            // 
            this.ServerNameTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ServerNameTextBox1.Name = "ServerNameTextBox1";
            this.ServerNameTextBox1.Size = new System.Drawing.Size(100, 23);
            this.ServerNameTextBox1.TextChanged += new System.EventHandler(this.ServerNameTextBox1_TextChanged);
            // 
            // RemoveIPStripMenuItem
            // 
            this.RemoveIPStripMenuItem.Name = "RemoveIPStripMenuItem";
            this.RemoveIPStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.RemoveIPStripMenuItem.Text = "Удалить";
            this.RemoveIPStripMenuItem.Click += new System.EventHandler(this.RemoveIPStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 222);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.headerPB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Просмотр удаленного рабочего стола (клиент)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.headerPB)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qualityVal)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox headerPB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox localIPCoboBox;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox timeoutTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown qualityVal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripRestoreButton;
        private System.Windows.Forms.ToolStripMenuItem toolStripExitButton1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem UpdateServersStripMenuItem;
        private System.Windows.Forms.PictureBox startButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem SetNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox ServerNameTextBox1;
        private System.Windows.Forms.ToolStripMenuItem RemoveIPStripMenuItem;
    }
}

