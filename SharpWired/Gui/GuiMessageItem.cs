#region Information and licence agreements

/*
 * StandardHTMLMessage.cs
 * Created by Ola Lindberg, 2008-03-05
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
using System.Text;
using SharpWired.Connection.Bookmarks;
using SharpWired.MessageEvents;
using SharpWired.Model.Messaging;
using SharpWired.Model.News;
using SharpWired.Model.PrivateMessages;

namespace SharpWired.Gui {
    /// <summary>
    /// An object that takes ChatEvents or TopicsEvents and provides
    /// common get methods for printing to GUI
    /// </summary>
    [Obsolete]
    public class GuiMessageItem : SharpWiredGuiBase {
        // General
        private readonly DateTime timeStamp;
        

        //For chat and topic messages
        private readonly string nickName = "";
        private readonly string message;

        //For error messages
        private bool isErrorMessage;
        private string errorDescription;
        private string solutionIdea;
        private Bookmark bookmark;

        /// <summary>Request the timestamp for this message</summary>
        public DateTime TimeStamp { get { return timeStamp; } }

        /// <summary>Request the nick for this message</summary>
        public string Nick { get { return nickName; } }

        /// <summary>Request the message string for this message</summary>
        public string Message { get { return message; } }

        /// <summary>
        /// Request the HTML for this object.
        /// NOTE! All fields are HTML encoded
        /// </summary>
        public string HTML {
            get {
                if (isEmptyMessage) {
                    return "";
                }

                var divClass = "";
                if (isErrorMessage == false) {
                    if (Nick == Model.Server.User.Nick) {
                        divClass = " class=\"me\"";
                    }
                }

                return
                    @"<div" + divClass + @">
	<span class=""time"">" + TimeStamp.ToShortTimeString() + @"</span>
	<span class=""user"">" + Nick + @"</span>
	<span class=""text"">
		<p>
			" + Message.Replace("\n", "<br/>\n") + @"
		</p>
	</span>
</div>
";
            }
        }

        /// <summary>Creates a HTML writable object from a ChatTopicItem</summary>
        /// <param name="messageArgs"></param>
        public GuiMessageItem(MessageEventArgs_341 messageArgs) {
            timeStamp = messageArgs.Time;
            nickName = messageArgs.Nick;
            message = messageArgs.Topic;
        }

        /// <summary>Creates a HTML writable object from a ChatMessageItem</summary>
        /// <param name="item"></param>
        public GuiMessageItem(ChatMessageItem item) {
            timeStamp = item.Time;
            nickName = item.FromUser.Nick;
            message = item.ChatMessage;
        }

        /// <summary>Constructor for error messages</summary>
        /// <param name="errorDescription"></param>
        /// <param name="solutionIdea"></param>
        /// <param name="bookmark"></param>
        public GuiMessageItem(string errorDescription, string solutionIdea,
                              Bookmark bookmark) {
            isErrorMessage = true;
            timeStamp = DateTime.Now;
            this.message = errorDescription;
            this.errorDescription = errorDescription;
            this.solutionIdea = solutionIdea;
            this.bookmark = bookmark;
        }

        /// <summary>Constructor for private messages</summary>
        /// <param name="item"></param>
        public GuiMessageItem(PrivateMessageItem item) {
            timeStamp = item.TimeStamp;
            nickName = item.UserItem.Nick;
            message = item.Message;
        }

        /// <summary>Constructor for news post</summary>
        /// <param name="newPost"></param>
        public GuiMessageItem(NewsMessageItem newPost) {
            timeStamp = newPost.Time;
            nickName = newPost.Nick;
            message = newPost.Post;
        }

        /// <summary>Constructor for Client Information</summary>
        /// <param name="e"></param>
        public GuiMessageItem(MessageEventArgs_308 e) {
            nickName = "";
            timeStamp = DateTime.Now;
            var s = new StringBuilder();
            s.Append("User Information" + "\\r\\n\\r\\n");
            s.Append("Nick: " + e.Nick + "\\r\\n");
            s.Append("Login: " + e.Login + "\\r\\n");
            s.Append("UserId: " + e.UserId + "\\r\\n");
            s.Append("Idle: " + e.Idle + "\\r\\n");
            s.Append("IdleTime: " + e.IdleTime + "\\r\\n");
            s.Append("LoginTime: " + e.LoginTime + "\\r\\n");
            s.Append("Status: " + e.Status + "\\r\\n");
            s.Append("Admin: " + e.Admin + "\\r\\n");
            s.Append("Host: " + e.Host + "\\r\\n");
            s.Append("Ip:  " + e.Ip + "\\r\\n");
            s.Append("ClientVersion: " + e.ClientVersion + "\\r\\n");
            s.Append("Downloads: " + e.Downloads + "\\r\\n");
            s.Append("Path: " + e.Path + "\\r\\n");
            s.Append("Size: " + e.Size + "\\r\\n");
            s.Append("Speed: " + e.Speed + "\\r\\n");
            s.Append("Transfer: " + e.Transfer + "\\r\\n");
            s.Append("Transferred: " + e.Transferred + "\\r\\n");
            s.Append("Uploads: " + e.Uploads + "\\r\\n");
            s.Append("CipherBits: " + e.CipherBits + "\\r\\n");
            s.Append("CipherName: " + e.CipherName + "\\r\\n");
            //s.Append("Icon" + e.Icon + "\\r\\n");
            //s.Append("Image" + e.Image + "\\r\\n");

            message = s.ToString();
        }

        /// <summary>Empty constructor</summary>
        public GuiMessageItem() {
            isEmptyMessage = true;
        }

        private readonly bool isEmptyMessage;
    }
}