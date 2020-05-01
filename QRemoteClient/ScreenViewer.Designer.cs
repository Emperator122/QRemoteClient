namespace QRemoteClient
{
    partial class ScreenViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenViewer));
            this.screenContainer = new System.Windows.Forms.GroupBox();
            this.screenPictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FullScreenStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screenContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.screenPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // screenContainer
            // 
            this.screenContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.screenContainer.Controls.Add(this.screenPictureBox);
            this.screenContainer.Location = new System.Drawing.Point(4, 28);
            this.screenContainer.Name = "screenContainer";
            this.screenContainer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.screenContainer.Size = new System.Drawing.Size(793, 423);
            this.screenContainer.TabIndex = 3;
            this.screenContainer.TabStop = false;
            // 
            // screenPictureBox
            // 
            this.screenPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.screenPictureBox.Location = new System.Drawing.Point(6, 12);
            this.screenPictureBox.Name = "screenPictureBox";
            this.screenPictureBox.Size = new System.Drawing.Size(781, 405);
            this.screenPictureBox.TabIndex = 0;
            this.screenPictureBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disconnectToolStripMenuItem,
            this.FullScreenStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.disconnectToolStripMenuItem.Text = "Отключиться";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.DisconnectToolStripMenuItem_Click);
            // 
            // FullScreenStripMenuItem
            // 
            this.FullScreenStripMenuItem.Name = "FullScreenStripMenuItem";
            this.FullScreenStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.FullScreenStripMenuItem.Text = "Полный экран";
            this.FullScreenStripMenuItem.Click += new System.EventHandler(this.FullScreenStripMenuItem_Click);
            // 
            // ScreenViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 454);
            this.Controls.Add(this.screenContainer);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScreenViewer";
            this.Text = "ScreenViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScreenViewer_FormClosing);
            this.screenContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.screenPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox screenContainer;
        public System.Windows.Forms.PictureBox screenPictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FullScreenStripMenuItem;
    }
}