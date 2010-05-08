#region Information and licence agreements
/*
 * SharpWiredForm.Designer.cs 
 * Created by Ola Lindberg, 2006-07-23
 * 
 * SharpWired - a Wired client.
 * See: http://www.zankasoftware.com/wired/ for more infromation about Wired
 * 
 * Copyright (C) Ola Lindberg (http://olalindberg.com)
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301 USA
 */
#endregion

using SharpWired.Gui.Chat;
namespace SharpWired.Gui
{
    partial class SharpWiredForm
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Clean up any resources being used.</summary>
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
            this.components = new System.ComponentModel.Container();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookmarksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageBookmarksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mLoadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSharpWiredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainIconMenu = new System.Windows.Forms.ToolStrip();
            this.publicChatToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.newsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.filesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.transfersToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ExitToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_ServerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.mBookmarkLoadingTimer = new System.Windows.Forms.Timer(this.components);
            this.chatUserContainer = new SharpWired.Gui.Chat.ChatUserContainer();
            this.filesContainer = new SharpWired.Gui.Files.FilesContainer();
            this.newsContainer = new SharpWired.Gui.News.NewsContainer();
            this.transferContainer = new SharpWired.Gui.Transfers.TransferContainer();
            this.mainMenu.SuspendLayout();
            this.mainIconMenu.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.bookmarksToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mainMenu.Size = new System.Drawing.Size(617, 24);
            this.mainMenu.TabIndex = 3;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disconnectToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Enabled = false;
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // bookmarksToolStripMenuItem
            // 
            this.bookmarksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageBookmarksToolStripMenuItem,
            this.toolStripSeparator2,
            this.mLoadingToolStripMenuItem});
            this.bookmarksToolStripMenuItem.Name = "bookmarksToolStripMenuItem";
            this.bookmarksToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.bookmarksToolStripMenuItem.Text = "Bookmarks";
            this.bookmarksToolStripMenuItem.DropDownOpening += new System.EventHandler(this.bookmarksToolStripMenuItem_DropDownOpening);
            // 
            // manageBookmarksToolStripMenuItem
            // 
            this.manageBookmarksToolStripMenuItem.Name = "manageBookmarksToolStripMenuItem";
            this.manageBookmarksToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+M";
            this.manageBookmarksToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.manageBookmarksToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.manageBookmarksToolStripMenuItem.Text = "Manage Bookmarks...";
            this.manageBookmarksToolStripMenuItem.Click += new System.EventHandler(this.manageBookmarksToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(230, 6);
            // 
            // mLoadingToolStripMenuItem
            // 
            this.mLoadingToolStripMenuItem.Name = "mLoadingToolStripMenuItem";
            this.mLoadingToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.mLoadingToolStripMenuItem.Text = "(Loading...)";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutSharpWiredToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutSharpWiredToolStripMenuItem
            // 
            this.aboutSharpWiredToolStripMenuItem.Name = "aboutSharpWiredToolStripMenuItem";
            this.aboutSharpWiredToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutSharpWiredToolStripMenuItem.Text = "About SharpWired...";
            this.aboutSharpWiredToolStripMenuItem.Click += new System.EventHandler(this.aboutSharpWiredToolStripMenuItem_Click);
            // 
            // mainIconMenu
            // 
            this.mainIconMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainIconMenu.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.mainIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.publicChatToolStripButton,
            this.newsToolStripButton,
            this.filesToolStripButton,
            this.transfersToolStripButton,
            this.ExitToolStripButton});
            this.mainIconMenu.Location = new System.Drawing.Point(0, 24);
            this.mainIconMenu.Name = "mainIconMenu";
            this.mainIconMenu.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.mainIconMenu.Size = new System.Drawing.Size(617, 29);
            this.mainIconMenu.TabIndex = 6;
            this.mainIconMenu.Text = "Icon Menu";
            // 
            // publicChatToolStripButton
            // 
            this.publicChatToolStripButton.Image = global::SharpWired.Properties.Resources.internet_group_chat;
            this.publicChatToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.publicChatToolStripButton.Name = "publicChatToolStripButton";
            this.publicChatToolStripButton.Size = new System.Drawing.Size(58, 26);
            this.publicChatToolStripButton.Text = "Chat";
            this.publicChatToolStripButton.Click += new System.EventHandler(this.publicChatToolStripButton_Click);
            // 
            // newsToolStripButton
            // 
            this.newsToolStripButton.Image = global::SharpWired.Properties.Resources.format_justify_left;
            this.newsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newsToolStripButton.Name = "newsToolStripButton";
            this.newsToolStripButton.Size = new System.Drawing.Size(62, 26);
            this.newsToolStripButton.Text = "News";
            this.newsToolStripButton.Click += new System.EventHandler(this.newsToolStripButton_Click);
            // 
            // filesToolStripButton
            // 
            this.filesToolStripButton.Image = global::SharpWired.Properties.Resources.folder;
            this.filesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.filesToolStripButton.Name = "filesToolStripButton";
            this.filesToolStripButton.Size = new System.Drawing.Size(56, 26);
            this.filesToolStripButton.Text = "Files";
            this.filesToolStripButton.Click += new System.EventHandler(this.filesToolStripButton_Click);
            // 
            // transfersToolStripButton
            // 
            this.transfersToolStripButton.Image = global::SharpWired.Properties.Resources.mail_send_receive;
            this.transfersToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.transfersToolStripButton.Name = "transfersToolStripButton";
            this.transfersToolStripButton.Size = new System.Drawing.Size(81, 26);
            this.transfersToolStripButton.Text = "Transfers";
            this.transfersToolStripButton.Click += new System.EventHandler(this.transfersToolStripButton_Click);
            // 
            // ExitToolStripButton
            // 
            this.ExitToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ExitToolStripButton.Image = global::SharpWired.Properties.Resources.system_log_out;
            this.ExitToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExitToolStripButton.Name = "ExitToolStripButton";
            this.ExitToolStripButton.Size = new System.Drawing.Size(51, 26);
            this.ExitToolStripButton.Text = "Exit";
            this.ExitToolStripButton.Click += new System.EventHandler(this.ExitToolStripButton_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_ServerStatus});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 474);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(617, 22);
            this.mainStatusStrip.TabIndex = 7;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_ServerStatus
            // 
            this.toolStripStatusLabel_ServerStatus.Name = "toolStripStatusLabel_ServerStatus";
            this.toolStripStatusLabel_ServerStatus.Size = new System.Drawing.Size(79, 17);
            this.toolStripStatusLabel_ServerStatus.Text = "Disconnected";
            // 
            // mBookmarkLoadingTimer
            // 
            this.mBookmarkLoadingTimer.Tick += new System.EventHandler(this.mBookmarkLoadingTimer_Tick);
            // 
            // chatUserContainer
            // 
            this.chatUserContainer.Location = new System.Drawing.Point(12, 56);
            this.chatUserContainer.Name = "chatUserContainer";
            this.chatUserContainer.Padding = new System.Windows.Forms.Padding(5);
            this.chatUserContainer.Size = new System.Drawing.Size(288, 176);
            this.chatUserContainer.TabIndex = 8;
            // 
            // filesContainer
            // 
            this.filesContainer.Location = new System.Drawing.Point(306, 56);
            this.filesContainer.Name = "filesUserControl1";
            this.filesContainer.Padding = new System.Windows.Forms.Padding(5);
            this.filesContainer.Size = new System.Drawing.Size(299, 176);
            this.filesContainer.TabIndex = 11;
            // 
            // newsContainer
            // 
            this.newsContainer.Location = new System.Drawing.Point(12, 238);
            this.newsContainer.Name = "newsContainer";
            this.newsContainer.Padding = new System.Windows.Forms.Padding(5);
            this.newsContainer.Size = new System.Drawing.Size(288, 233);
            this.newsContainer.TabIndex = 9;
            this.newsContainer.Visible = false;
            // 
            // transferContainer
            // 
            this.transferContainer.Location = new System.Drawing.Point(306, 238);
            this.transferContainer.Name = "transferList1";
            this.transferContainer.Size = new System.Drawing.Size(299, 233);
            this.transferContainer.TabIndex = 12;
            // 
            // SharpWiredForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 496);
            this.Controls.Add(this.transferContainer);
            this.Controls.Add(this.chatUserContainer);
            this.Controls.Add(this.filesContainer);
            this.Controls.Add(this.newsContainer);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainIconMenu);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(412, 300);
            this.Name = "SharpWiredForm";
            this.Text = "SharpWired - Chat";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.mainIconMenu.ResumeLayout(false);
            this.mainIconMenu.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookmarksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageBookmarksToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSharpWiredToolStripMenuItem;
        private System.Windows.Forms.ToolStrip mainIconMenu;
        private System.Windows.Forms.ToolStripButton publicChatToolStripButton;
        private System.Windows.Forms.ToolStripButton newsToolStripButton;
        private System.Windows.Forms.ToolStripButton filesToolStripButton;
        private System.Windows.Forms.ToolStripButton transfersToolStripButton;
        private System.Windows.Forms.ToolStripButton ExitToolStripButton;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ServerStatus;
		private System.Windows.Forms.ToolStripMenuItem mLoadingToolStripMenuItem;
        private System.Windows.Forms.Timer mBookmarkLoadingTimer;
        private ChatUserContainer chatUserContainer;
        private SharpWired.Gui.News.NewsContainer newsContainer;
        private SharpWired.Gui.Files.FilesContainer filesContainer;
        private SharpWired.Gui.Transfers.TransferContainer transferContainer;
    }
}

