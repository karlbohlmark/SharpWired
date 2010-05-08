#region Information and licence agreements

/*
 * Chat.cs 
 * Created by Ola Lindberg, 2006-09-28
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

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SharpWired.Connection.Bookmarks;
using SharpWired.MessageEvents;
using SharpWired.Model.Messaging;
using SharpWired.Gui.Messages;

namespace SharpWired.Gui.Chat {
    public partial class Chat : WebBrowserGuiBase {
        private delegate void ChangeTopicCallback(GuiMessageItem guiMessage);

        public Chat() {
            InitializeComponent();

            ResetWebBrowser(chatWebBrowser);
            Model.Errors.LoginFailed += OnLoginFailed;
        }

        protected override void OnOnline() {
            Model.Server.PublicChat.ChatMessageReceivedEvent += OnChatMessageArrived;
            Model.Server.PublicChat.ChatTopicChangedEvent += OnChatTopicChanged;

            ToggleWindowsFormControl(chatInputTextBox);
            ToggleWindowsFormControl(sendChatButton);
            ToggleWindowsFormControl(topicDisplayLabel);
            ToggleWindowsFormControl(setByLabel);

            ResetWebBrowser(chatWebBrowser);
        }

        protected override void OnOffline() {
            Model.Server.Offline -= OnOffline;
            Model.Server.PublicChat.ChatMessageReceivedEvent -= OnChatMessageArrived;
            Model.Server.PublicChat.ChatTopicChangedEvent -= OnChatTopicChanged;

            ToggleWindowsFormControl(chatInputTextBox);
            ToggleWindowsFormControl(sendChatButton);
            ToggleWindowsFormControl(topicDisplayLabel);
            ToggleWindowsFormControl(setByLabel);

            ResetWebBrowser(chatWebBrowser);
        }

        /// <summary>Formats and writes the text on an Chat Event to the GUI</summary>
        /// <param name="message"></param>
        public void OnChatTopicChanged(MessageEventArgs_341 message) {
            var guiMessage = new GuiMessageItem(message);
            ChangeTopic(guiMessage);
        }

        /// <summary>Formats and writes the text on a Chat Event to the GUI</summary>
        /// <param name="chatMessageItem">The chat message item that was received</param>
        public void OnChatMessageArrived(ChatMessageItem chatMessageItem) {
            var chatMessage = new ChatMessage(chatMessageItem);
            AppendHTMLToWebBrowser(chatWebBrowser, chatMessage);
        }

        /// <summary>Call this method to report an error that should be printed to chat window</summary>
        /// <param name="errorDescription"></param>
        /// <param name="solutionIdea"></param>
        /// <param name="bookmark"></param>
        public void OnLoginFailed(string errorDescription, string solutionIdea, Bookmark bookmark) {
            var message = new ErrorMessage(errorDescription, solutionIdea, bookmark);
            AppendHTMLToWebBrowser(chatWebBrowser, message);
        }

        public override void Init() {
            base.Init();
        }

        private void ChangeTopic(GuiMessageItem guiMessage) {
            if (InvokeRequired) {
                ChangeTopicCallback changeTopicCallback = ChangeTopic;
                Invoke(changeTopicCallback, new object[] {guiMessage});
            } else {
                topicDisplayLabel.Text = guiMessage.Message;
                var sb = new StringBuilder();
                sb.Append(guiMessage.Nick);
                sb.Append(" - ");
                sb.Append(guiMessage.TimeStamp);
                setByLabel.Text = sb.ToString();
            }
        }

        private void sendChatButton_MouseUp(object sender, MouseEventArgs e) {
            Controller.ChatController.SendChatMessage(chatInputTextBox.Text);
            chatInputTextBox.Clear();
        }

        private void chatInputTextBox_KeyUp(object sender, KeyEventArgs e) {
            if (!e.Shift && e.KeyCode == Keys.Enter) {
                Controller.ChatController.SendChatMessage(chatInputTextBox.Text);
                chatInputTextBox.Clear();
            }
            if (e.KeyCode == Keys.Escape) {
                chatInputTextBox.Clear();
            }
        }

        #region Edit topic

        //TODO: Only enable topic changing if we are online
        //TODO: Only enable topic changing if the user has permissions to change it
        private void topicTextBox_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                enableTopicEditing(false);

                Controller.ChatController.ChangeTopic(topicTextBox.Text);

                topicDisplayLabel.Text = "Updating topic on server.";
                setByLabel.Text = "";
            } else if (e.KeyCode == Keys.Escape) {
                enableTopicEditing(false);
            }
        }

        private void topicDisplayLabel_MouseUp(object sender, MouseEventArgs e) {
            if (Model.Server != null && Model.Server.PublicChat != null) {
                topicTextBox.Text = topicDisplayLabel.Text;
                enableTopicEditing(true);
            }
        }

        private void topicDisplayLabel_MouseLeave(object sender, EventArgs e) {
            topicDisplayLabel.Cursor = Cursors.Default;
        }

        private void topicDisplayLabel_MouseEnter(object sender, EventArgs e) {
            if (Model.Server != null && Model.Server.PublicChat != null) {
                topicDisplayLabel.Cursor = Cursors.Hand;
            }
        }

        private void topicTextBox_Leave(object sender, EventArgs e) {
            enableTopicEditing(false);
        }

        private void enableTopicEditing(bool editable) {
            if (editable) {
                topicDisplayLabel.Visible = false;
                topicTextBox.Visible = true;
                topicTextBox.BackColor = Color.White;
                topicTextBox.Focus();
            } else {
                topicDisplayLabel.Visible = true;
                topicTextBox.Visible = false;
            }
        }

        #endregion
    }
}