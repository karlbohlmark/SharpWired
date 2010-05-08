#region Information and licence agreements
/*
 * ChatUserControl.Designer.cs
 * Created by Ola Lindberg, 2006-10-12
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

namespace SharpWired.Gui.Chat
{
    partial class ChatUserContainer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chatSplitContainer = new System.Windows.Forms.SplitContainer();
            this.chat = new SharpWired.Gui.Chat.Chat();
            this.userList = new SharpWired.Gui.Chat.UserList();
            this.chatSplitContainer.Panel1.SuspendLayout();
            this.chatSplitContainer.Panel2.SuspendLayout();
            this.chatSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // chatSplitContainer
            // 
            this.chatSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chatSplitContainer.Location = new System.Drawing.Point(5, 5);
            this.chatSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.chatSplitContainer.Name = "chatSplitContainer";
            // 
            // chatSplitContainer.Panel1
            // 
            this.chatSplitContainer.Panel1.Controls.Add(this.chat);
            // 
            // chatSplitContainer.Panel2
            // 
            this.chatSplitContainer.Panel2.Controls.Add(this.userList);
            this.chatSplitContainer.Size = new System.Drawing.Size(507, 343);
            this.chatSplitContainer.SplitterDistance = 375;
            this.chatSplitContainer.TabIndex = 8;
            // 
            // chat
            // 
            this.chat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chat.Location = new System.Drawing.Point(0, 0);
            this.chat.Margin = new System.Windows.Forms.Padding(0);
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(375, 343);
            this.chat.TabIndex = 0;
            // 
            // userList
            // 
            this.userList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.userList.Location = new System.Drawing.Point(2, 0);
            this.userList.Margin = new System.Windows.Forms.Padding(0);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(126, 343);
            this.userList.TabIndex = 0;
            // 
            // ChatUserContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chatSplitContainer);
            this.Name = "ChatUserContainer";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(517, 353);
            this.chatSplitContainer.Panel1.ResumeLayout(false);
            this.chatSplitContainer.Panel2.ResumeLayout(false);
            this.chatSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer chatSplitContainer;
        private UserList userList;
        private Chat chat;
    }
}
