namespace Clinet_UI
{
    partial class ChatClient
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
            this.richTextChat = new System.Windows.Forms.RichTextBox();
            this.messagBox = new System.Windows.Forms.RichTextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.choiceImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.checkPrivateList = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextChat
            // 
            this.richTextChat.Location = new System.Drawing.Point(12, 26);
            this.richTextChat.Name = "richTextChat";
            this.richTextChat.ReadOnly = true;
            this.richTextChat.Size = new System.Drawing.Size(495, 312);
            this.richTextChat.TabIndex = 4;
            this.richTextChat.Text = "";
            // 
            // messagBox
            // 
            this.messagBox.Location = new System.Drawing.Point(12, 351);
            this.messagBox.Name = "messagBox";
            this.messagBox.Size = new System.Drawing.Size(390, 42);
            this.messagBox.TabIndex = 1;
            this.messagBox.Text = "";
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.SendButton.Location = new System.Drawing.Point(418, 351);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(89, 42);
            this.SendButton.TabIndex = 0;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = false;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newChatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(698, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "Menu";
            // 
            // newChatToolStripMenuItem
            // 
            this.newChatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singleChatToolStripMenuItem,
            this.choiceImagesToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.newChatToolStripMenuItem.Name = "newChatToolStripMenuItem";
            this.newChatToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.newChatToolStripMenuItem.Text = " Menu";
            // 
            // singleChatToolStripMenuItem
            // 
            this.singleChatToolStripMenuItem.Name = "singleChatToolStripMenuItem";
            this.singleChatToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.singleChatToolStripMenuItem.Text = "Join to Chat";
            this.singleChatToolStripMenuItem.Click += new System.EventHandler(this.singleChatToolStripMenuItem_Click);
            // 
            // choiceImagesToolStripMenuItem
            // 
            this.choiceImagesToolStripMenuItem.Name = "choiceImagesToolStripMenuItem";
            this.choiceImagesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.choiceImagesToolStripMenuItem.Text = "Choice Images";
            this.choiceImagesToolStripMenuItem.Click += new System.EventHandler(this.choiceImagesToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // checkPrivateList
            // 
            this.checkPrivateList.AutoSize = true;
            this.checkPrivateList.Location = new System.Drawing.Point(418, 402);
            this.checkPrivateList.Name = "checkPrivateList";
            this.checkPrivateList.Size = new System.Drawing.Size(95, 17);
            this.checkPrivateList.TabIndex = 2;
            this.checkPrivateList.Text = "Sent to private";
            this.checkPrivateList.UseVisualStyleBackColor = true;
            this.checkPrivateList.CheckedChanged += new System.EventHandler(this.checkPrivateList_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(6, 19);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(164, 198);
            this.pictureBox.TabIndex = 6;
            this.pictureBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox);
            this.groupBox1.Location = new System.Drawing.Point(513, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 229);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Last Picture";
            // 
            // ChatClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(698, 427);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkPrivateList);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.messagBox);
            this.Controls.Add(this.richTextChat);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ChatClient";
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.ChatClient_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextChat;
        private System.Windows.Forms.RichTextBox messagBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singleChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem choiceImagesToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkPrivateList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
    }
}

