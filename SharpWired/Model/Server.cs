#region Information and licence agreements

/*
 * ServerInformation.cs 
 * Created by Ola Lindberg, 2007-12-13
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
using SharpWired.Connection;
using SharpWired.MessageEvents;
using SharpWired.Model.Files;
using SharpWired.Model.Messaging;
using SharpWired.Model.Users;

namespace SharpWired.Model {
    /// <summary>Represents the connected server</summary>
    public class Server : ModelBase {
        private HeartBeatTimer HeartBeat { get; set; }

        /// <summary>Request or set the server app version</summary>
        public string AppVersion { get; set; }

        /// <summary>Request or set the servers file count</summary>
        public int FilesCount { get; set; }

        /// <summary>Request or set the file size on the server</summary>
        public long FileSize { get; set; }

        /// <summary>Request or set the server protocol version</summary>
        public string ProtocolVersion { get; set; }

        /// <summary>Request or set the server description</summary>
        public string ServerDescription { get; set; }

        /// <summary>Request or set the server name</summary>
        public string ServerName { get; set; }

        /// <summary>Request or set the server start time</summary>
        public DateTime StartTime { get; set; }

        /// <summary>Request the public chat for this server</summary>
        public Chat PublicChat { get; private set; }

        /// <summary>Request the news for this server</summary>
        public News.News News { get; private set; }

        /// <summary>Gets the file listing model</summary>
        public FileTree FileRoot { get; private set; }

        public Transfers.Transfers Transfers { get; private set; }

        /// <summary>Sets the user id for this user.</summary>
        public int OwnUserId { get; set; }

        public User User { get { return PublicChat.Users.GetUser(OwnUserId); } }
        
        public delegate void ServerStatus();

        public event ServerStatus Online;
        public event ServerStatus Offline;

        public void SetInfo(MessageEventArgs_200 message) {
            AppVersion = message.AppVersion;
            FilesCount = message.FilesCount;
            FileSize = message.FilesSize;
            ProtocolVersion = message.ProtocolVersion;
            ServerDescription = message.ServerDescription;
            ServerName = message.ServerName;
            StartTime = message.StartTime;

            ConnectionManager.Messages.LoginSucceededEvent += OnLoginSucceeded;
        }

        public void GoOffline() {
            if (Offline != null) {
                Offline();
            }

            PublicChat = null;
            News = null;
            FileRoot.OnOffline();
            FileRoot = null;

            // TODO: Should probably null much more here (HeartBeat etc).
        }

        private void OnLoginSucceeded(object sender, MessageEventArgs_201 message) {
            ConnectionManager.Messages.LoginSucceededEvent -= OnLoginSucceeded;

            OwnUserId = message.UserId;

            ConnectionManager.Commands.Who(1); //1 = Public Chat
            ConnectionManager.Commands.Ping(this);

            //Starts the heart beat pings to the server
            HeartBeat = new HeartBeatTimer(ConnectionManager);
            HeartBeat.StartTimer();

            PublicChat = new Chat(ConnectionManager.Messages, 1); // 1 = chat id for public chat
            News = new News.News(ConnectionManager.Messages);

            FileRoot = new FileTree();
            FileRoot.Reload();

            Transfers = new Transfers.Transfers();

            if (Online != null) {
                Online();
            }
        }
    }
}