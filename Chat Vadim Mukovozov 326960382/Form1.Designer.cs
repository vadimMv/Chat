namespace Chat_Vadim_Mukovozov_326960382
{
    partial class Server
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
            this.CurrentTab = new System.Windows.Forms.TabControl();
            this.CurrentUsers = new System.Windows.Forms.TabPage();
            this.EventLogList = new System.Windows.Forms.ListView();
            this.NickName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HistoryPage = new System.Windows.Forms.TabPage();
            this.HistoryListView = new System.Windows.Forms.ListView();
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FinishTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CurrentTab.SuspendLayout();
            this.CurrentUsers.SuspendLayout();
            this.HistoryPage.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CurrentTab
            // 
            this.CurrentTab.Controls.Add(this.CurrentUsers);
            this.CurrentTab.Controls.Add(this.HistoryPage);
            this.CurrentTab.Location = new System.Drawing.Point(12, 43);
            this.CurrentTab.Name = "CurrentTab";
            this.CurrentTab.SelectedIndex = 0;
            this.CurrentTab.Size = new System.Drawing.Size(368, 236);
            this.CurrentTab.TabIndex = 0;
            // 
            // CurrentUsers
            // 
            this.CurrentUsers.Controls.Add(this.EventLogList);
            this.CurrentUsers.Location = new System.Drawing.Point(4, 22);
            this.CurrentUsers.Name = "CurrentUsers";
            this.CurrentUsers.Padding = new System.Windows.Forms.Padding(3);
            this.CurrentUsers.Size = new System.Drawing.Size(360, 210);
            this.CurrentUsers.TabIndex = 0;
            this.CurrentUsers.Text = "Current Users";
            this.CurrentUsers.UseVisualStyleBackColor = true;
            // 
            // EventLogList
            // 
            this.EventLogList.BackColor = System.Drawing.SystemColors.Window;
            this.EventLogList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NickName,
            this.Status,
            this.Time});
            this.EventLogList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventLogList.Location = new System.Drawing.Point(3, 3);
            this.EventLogList.Name = "EventLogList";
            this.EventLogList.ShowItemToolTips = true;
            this.EventLogList.Size = new System.Drawing.Size(354, 204);
            this.EventLogList.TabIndex = 0;
            this.EventLogList.UseCompatibleStateImageBehavior = false;
            this.EventLogList.View = System.Windows.Forms.View.Details;
            // 
            // NickName
            // 
            this.NickName.Text = "Nick Name";
            this.NickName.Width = 97;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 89;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 105;
            // 
            // HistoryPage
            // 
            this.HistoryPage.Controls.Add(this.HistoryListView);
            this.HistoryPage.Location = new System.Drawing.Point(4, 22);
            this.HistoryPage.Name = "HistoryPage";
            this.HistoryPage.Padding = new System.Windows.Forms.Padding(3);
            this.HistoryPage.Size = new System.Drawing.Size(360, 210);
            this.HistoryPage.TabIndex = 1;
            this.HistoryPage.Text = "History";
            this.HistoryPage.UseVisualStyleBackColor = true;
            // 
            // HistoryListView
            // 
            this.HistoryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name,
            this.StartTime,
            this.FinishTime});
            this.HistoryListView.Location = new System.Drawing.Point(0, 6);
            this.HistoryListView.Name = "HistoryListView";
            this.HistoryListView.Size = new System.Drawing.Size(348, 198);
            this.HistoryListView.TabIndex = 0;
            this.HistoryListView.UseCompatibleStateImageBehavior = false;
            this.HistoryListView.View = System.Windows.Forms.View.Details;
            // 
            // Name
            // 
            this.Name.Text = "User Name";
            this.Name.Width = 93;
            // 
            // StartTime
            // 
            this.StartTime.Text = "Strart Chat";
            this.StartTime.Width = 103;
            // 
            // FinishTime
            // 
            this.FinishTime.Text = "Finish Time";
            this.FinishTime.Width = 100;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(392, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.toolStripMenuItem1.Text = "Menu";
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.SettingsToolStripMenuItem.Text = "Settings";
            this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 413);
            this.Controls.Add(this.CurrentTab);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Server_Load);
            this.CurrentTab.ResumeLayout(false);
            this.CurrentUsers.ResumeLayout(false);
            this.HistoryPage.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl CurrentTab;
        private System.Windows.Forms.TabPage CurrentUsers;
        private System.Windows.Forms.TabPage HistoryPage;
        private System.Windows.Forms.ListView EventLogList;
        private System.Windows.Forms.ColumnHeader NickName;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ListView HistoryListView;
       private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader StartTime;
        private System.Windows.Forms.ColumnHeader FinishTime;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
    }
}

