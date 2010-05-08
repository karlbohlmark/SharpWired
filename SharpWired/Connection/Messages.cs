#region Information and licence agreements

/*
 * Messages.cs 
 * Created by Ola Lindberg, 2006-06-29
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
using System.Diagnostics;
using System.Drawing;
using System.Net;
using SharpWired.MessageEvents;
using SharpWired.Model.Users;

namespace SharpWired.Connection {
    /// <summary>
    /// Handles all the messages in the Wired 1.1 protocol. See http://www.zankasoftware.com/wired/ for more information.
    ///
    /// Authors:	Ola Lindberg (d02ola@ituniv.se)
    ///				Adam Lindberg (eproxus@gmail.com)
    /// 
    /// NOTE: This class has derived from the Socio Project. See http://socio.sf.net/
    /// </summary>
    public class Messages {
        //
        // All server messages follows
        //

        #region Delegates

        /// 200
        public delegate void ServerInformationEventHandler(MessageEventArgs_200 messageEventArgs);

        /// 201
        public delegate void LoginSucceededEventHandler(object sender, MessageEventArgs_201 messageEventArgs);

        /// 202
        public delegate void PingReplyEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 203
        public delegate void ServerBannerEventHandler(MessageEventArgs_203 messageEventArgs);

        /// 300
        public delegate void ChatEventHandler(object sender, MessageEventArgs_300301 messageEventArgs);

        /// 301
        public delegate void ActionChatEventHandler(object sender, MessageEventArgs_300301 messageEventArgs);

        /// 302
        public delegate void ClientJoinEventHandler(MessageEventArgs_302310 messageEventArgs);

        /// 303
        public delegate void ClientLeaveEventHandler(MessageEventArgs_303331332 messageEventArgs);

        /// 304
        public delegate void StatusChangeEventHandler(MessageEventArgs_304 messageEventArgs);

        /// 305
        public delegate void PrivateMessageEventHandler(object sender, MessageEventArgs_305309 messageEventArgs);

        /// 306
        public delegate void ClientKickedEventHandler(MessageEventArgs_306307 messageEventArgs);

        /// 307
        public delegate void ClientBannedEventHandler(MessageEventArgs_306307 messageEventArgs);

        /// 308
        public delegate void ClientInformationEventHandler(MessageEventArgs_308 messageEventArgs);

        /// 309
        public delegate void BroadcastMessageEventHandler(object sender, MessageEventArgs_305309 messageEventArgs);

        /// 310
        public delegate void UserListEventHandler(MessageEventArgs_302310 messageEventArgs);

        /// 311
        public delegate void UserListDoneEventHandler(object sender, MessageEventArgs_311330 messageEventArgs);

        /// 320
        public delegate void NewsEventHandler(MessageEventArgs_320322 messageEventArgs);

        /// 321
        public delegate void NewsDoneEventHandler(MessageEventArgs_Messages messageEventArgs);

        /// 322
        public delegate void NewsPostedEventHandler(MessageEventArgs_320322 messageEventArgs);

        /// 330
        public delegate void PrivateChatCreatedEventHandler(object sender, MessageEventArgs_311330 messageEventArgs);

        /// 331e
        public delegate void PrivateChatInvitationEventHandler(object sender, MessageEventArgs_303331332 messageEventArgs);

        /// 332
        public delegate void PrivateChatDeclinedEventHandler(object sender, MessageEventArgs_303331332 messageEventArgs);

        /// 340
        public delegate void ClientImageChangedEventHandler(MessageEventArgs_340 messageEventArgs);

        /// 341
        public delegate void ChatTopicEventHandler(MessageEventArgs_341 messageEventArgs);

        /// 400
        public delegate void TransferReadyEventHandler(MessageEventArgs_400 messageEventArgs);

        /// 401
        public delegate void TransferQueuedEventHandler(object sender, MessageEventArgs_401 messageEventArgs);

        /// 402
        public delegate void FileInformationEventHandler(object sender, MessageEventArgs_402 messageEventArgs);

        /// 410
        public delegate void FileListingEventHandler(MessageEventArgs_410420 messageEventArgs);

        /// 411
        public delegate void FileListingDoneEventHandler(MessageEventArgs_411 messageEventArgs);

        /// 420
        public delegate void SearchListingEventHandler(object sender, MessageEventArgs_410420 messageEventArgs);

        /// 421
        public delegate void SearchListingDoneEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 500
        public delegate void CommandFailedEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 501
        public delegate void CommandNotRecognizedEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 502
        public delegate void CommandNotImplementedEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 503
        public delegate void SyntaxErrorEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 510
        public delegate void LoginFailedEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 511
        public delegate void BannedEventHandler(MessageEventArgs_Messages messageEventArgs);

        /// 512
        public delegate void ClientNotFoundEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 513
        public delegate void AccountNotFoundEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 514
        public delegate void AccountExistsEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 515
        public delegate void CannotBeDisconnectedEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 516
        public delegate void PermissionDeniedEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 520
        public delegate void FileOrDirectoryNotFoundEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 521
        public delegate void FileOrDirectoryExistsEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 522
        public delegate void ChecksumMismatchEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 523
        public delegate void QueueLimitExceededEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 600
        public delegate void UserSpecificationEventHandler(object sender, MessageEventArgs_600 messageEventArgs);

        /// 601
        public delegate void GroupSpecificationEventHandler(object sender, MessageEventArgs_601 messageEventArgs);

        /// 602
        public delegate void PrivilegesSpecificationEventHandler(MessageEventArgs_602 messageEventArgs);

        /// 610
        public delegate void UserListingEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 611
        public delegate void UserListingDoneEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 620
        public delegate void GroupListingEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 621
        public delegate void GroupListingDoneEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// Tracker specific events
        /// 710 TrackerCategoryListingEvent	
        public delegate void TrackerCategoryListingEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 711 TrackerCategoryListingDoneEvent
        public delegate void TrackerCategoryListingDoneEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 720 TrackerServerListingEvent
        public delegate void TrackerServerListingEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        /// 721 TrackerServerListingDoneEvent
        public delegate void TrackerServerListingDoneEventHandler(object sender, MessageEventArgs_Messages messageEventArgs);

        #endregion

        #region Events

        /// <summary>Basic information about the server</summary>
        public event ServerInformationEventHandler ServerInformationEvent;

        /// <summary>Login succeded</summary>
        public event LoginSucceededEventHandler LoginSucceededEvent;

        /// <summary>Event to be notified when a response to a ping occured</summary>
        public event PingReplyEventHandler PingReplyEvent;

        /// <summary>Event to be notified when a server banner has changed</summary>
        public event ServerBannerEventHandler ServerBannerEvent;

        /// <summary>Event to be notified when a chat message is received</summary>
        public event ChatEventHandler ChatEvent;

        /// <summary>Event to be notified when an action chat message is received</summary>
        public event ActionChatEventHandler ActionChatEvent;

        /// <summary>Event to be notified when a client has joined</summary>
        public event ClientJoinEventHandler ClientJoinEvent;

        /// <summary>Event to be notified when a client has left</summary>
        public event ClientLeaveEventHandler ClientLeaveEvent;

        /// <summary>Event to be notified when a status has changed</summary>
        public event StatusChangeEventHandler StatusChangeEvent;

        /// <summary>Event to be notified when a private message is received</summary>
        public event PrivateMessageEventHandler PrivateMessageEvent;

        /// <summary>Event to be notified when a client has been kicked</summary>
        public event ClientKickedEventHandler ClientKickedEvent;

        /// <summary>Event to be notified when a client has been banned</summary>
        public event ClientBannedEventHandler ClientBannedEvent;

        /// <summary>Event to be notified when a client information has been received </summary>
        public event ClientInformationEventHandler ClientInformationEvent;

        /// <summary>Event to be notified when a broadcast message has been received</summary>
        public event BroadcastMessageEventHandler BroadcastMessageEvent;

        /// <summary>Event to be notified when a user list message has been received</summary>
        public event UserListEventHandler UserListEvent;

        /// <summary>Event to be notified when a user list done event has been received</summary>
        public event UserListDoneEventHandler UserListDoneEvent;

        /// <summary>Event to be notified when a news post event has been received</summary>
        public event NewsEventHandler NewsEvent;

        /// <summary>Event to be notified when a news post done has been received. In response to comman NEWS.</summary>
        public event NewsDoneEventHandler NewsDoneEvent;

        /// <summary>Event to be notified when a new newspost has been posted (asyncron message).</summary>
        public event NewsPostedEventHandler NewsPostedEvent;

        /// <summary>Event to be notified when a private chat has been created on the server (Wired id 330)</summary>
        public event PrivateChatCreatedEventHandler PrivateChatCreatedEvent;

        /// <summary>Event to be notified when a user has been invited to a private chat</summary>
        public event PrivateChatInvitationEventHandler PrivateChatInvitationEvent;

        /// <summary>Event to be notified when a user has declined a private chat</summary>
        public event PrivateChatDeclinedEventHandler PrivateChatDeclinedEvent;

        /// <summary>Event to be notified when the image has changed for a user</summary>
        public event ClientImageChangedEventHandler ClientImageChangedEvent;

        /// <summary>Event to be notified when a chat topic has been changed</summary>
        public event ChatTopicEventHandler ChatTopicEvent;

        /// <summary>Event to be notified when a transfer is ready for transmission</summary>
        public event TransferReadyEventHandler TransferReadyEvent;

        /// <summary>Event to be notified when a transfer has been queued </summary>
        public event TransferQueuedEventHandler TransferQueuedEvent;

        /// <summary>Event to be notified when a file information event is received</summary>
        public event FileInformationEventHandler FileInformationEvent;

        /// <summary>Event to be notified when file listing has been received</summary>
        public event FileListingEventHandler FileListingEvent;

        /// <summary>Event to be notified when a file listing done event is received</summary>
        public event FileListingDoneEventHandler FileListingDoneEvent;

        /// <summary>Event to be notified when a search listing event has been received</summary>
        public event SearchListingEventHandler SearchListingEvent;

        /// <summary>Event to be notified when a search listing has been completed</summary>
        public event SearchListingDoneEventHandler SearchListingDoneEvent;

        /// <summary>Event to be notified when a command failed</summary>
        public event CommandFailedEventHandler CommandFailedEvent;

        /// <summary>Event to be notified when a command is not reqognized</summary>
        public event CommandNotRecognizedEventHandler CommandNotRecognizedEvent;

        /// <summary>Event to be notified when a command is not implemented</summary>
        public event CommandNotImplementedEventHandler CommandNotImplementedEvent;

        /// <summary>Event to be notified when a syntax error event was received</summary>
        public event SyntaxErrorEventHandler SyntaxErrorEvent;

        /// <summary>Event to be notified when logging in failed</summary>
        public event LoginFailedEventHandler LoginFailedEvent;

        /// <summary>Event to be notified when the login could not be done since the client was banned</summary>
        public event BannedEventHandler BannedEvent;

        /// <summary>Event to be notified when the server could not find the client</summary>
        public event ClientNotFoundEventHandler ClientNotFoundEvent;

        /// <summary>Event to be notified when the server could not find the given account</summary>
        public event AccountNotFoundEventHandler AccountNotFoundEvent;

        /// <summary>Event to be notified when the given account already exists on the server</summary>
        public event AccountExistsEventHandler AccountExistsEvent;

        /// <summary>Event to be notified when a user tried to dissconnect a user that cannot be disconnected</summary>
        public event CannotBeDisconnectedEventHandler CannotBeDisconnectedEvent;

        /// <summary>Event to be notified when a command could not be completed due to permission problems</summary>
        public event PermissionDeniedEventHandler PermissionDeniedEvent;

        /// <summary>Event to be notified when the file or directore reffered to could not be found</summary>
        public event FileOrDirectoryNotFoundEventHandler FileOrDirectoryNotFoundEvent;

        /// <summary>Event to be notified when the file or directory reffered to could not be found</summary>
        public event FileOrDirectoryExistsEventHandler FileOrDirectoryExistsEvent;

        /// <summary>Event to be notified when the two checksums do not match</summary>
        public event ChecksumMismatchEventHandler ChecksumMismatchEvent;

        /// <summary>Event to be notified when the queue limit was exceeded</summary>
        public event QueueLimitExceededEventHandler QueueLimitExceededEvent;

        /// <summary>Event to be notified when specifications for a user was received</summary>
        public event UserSpecificationEventHandler UserSpecificationEvent;

        /// <summary>Event to be notified when specifications for a group was received</summary>
        public event GroupSpecificationEventHandler GroupSpecificationEvent;

        /// <summary>Event to be notified when specification for this user was received</summary>
        public event PrivilegesSpecificationEventHandler PrivilegesSpecificationEvent;

        /// <summary>
        /// Event to be notified when a user account in the user accounts listing was received. 
        /// NOTE! This is for the administration of the server. Not the same as UserListEvent.
        /// </summary>
        public event UserListingEventHandler UserListingEvent;

        /// <summary>
        /// Event to be notified when all user accounts on the server was received.
        /// NOTE! This is for the administration of the server. Not the same as UserListDoneEvent.
        /// </summary>
        public event UserListingDoneEventHandler UserListingDoneEvent;

        /// <summary>
        /// Event to be notified when a group listing was received.
        /// NOTE! This is for the administration of the server.
        /// </summary>
        public event GroupListingEventHandler GroupListingEvent;

        /// <summary>
        /// Event to be notified when group listing was completed.
        /// NOTE! This is for the administration of the server.
        /// </summary>
        public event GroupListingDoneEventHandler GroupListingDoneEvent;

        #endregion

        #region Tracker specific events (doesn'transfer exist in the protocol specification)

        /// <summary>Event to be notified when a tracker categories was received</summary>
        public event TrackerCategoryListingEventHandler TrackerCategoryListingEvent;

        /// <summary>Event to be notified when all tracker categories has been received</summary>
        public event TrackerCategoryListingDoneEventHandler TrackerCategoryListingDoneEvent;

        /// <summary>Event to be notified when a tracker listing was received</summary>
        public event TrackerServerListingEventHandler TrackerServerListingEvent;

        /// <summary>Event to be notified when tracker listing is completed</summary>
        public event TrackerServerListingDoneEventHandler TrackerServerListingDoneEvent;

        #endregion

        #region Event Creators

        /// 
        /// Here follows the Raisers of events
        ///
        // 200
        private void OnServerInformationEvent(object sender, int messageId, string messageName, string message) {
            if (ServerInformationEvent != null) {
                // Parse the server information event
                var words = SplitMessage(message);

                var appVersion = words[0];
                var protocolVersion = words[1];
                var serverName = words[2];
                var serverDescription = words[3];
                DateTime startTime;
                DateTime.TryParse(words[4], out startTime);

                int filesCount = Convert.ToInt16(words[5]);
                var filesSize = long.Parse(words[6]);

                var m = new MessageEventArgs_200(messageId, messageName, appVersion, protocolVersion, serverName, serverDescription, startTime, filesCount, filesSize);

                ServerInformationEvent(m);
            }
        }

        // 201
        private void OnLoginSucceededEvent(object sender, int messageId, string messageName, string message) {
            if (LoginSucceededEvent != null) {
                int userId = Int16.Parse(message);
                var m = new MessageEventArgs_201(messageId, messageName, userId);
                LoginSucceededEvent(this, m);
            }
        }

        // 202
        private void OnPingReplyEvent(object sender, int messageId, string messageName, string message) {
            if (PingReplyEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                PingReplyEvent(this, m);
            }
        }

        // 203
        private void OnServerBannerEvent(object sender, int messageId, string messageName, string message) {
            if (ServerBannerEvent != null) {
                var serverBanner = new Bitmap(Utility.Base64StringToBitmap(message));
                var m = new MessageEventArgs_203(messageId, messageName, serverBanner);
                ServerBannerEvent(m);
            }
        }

        // 300
        private void OnChatEvent(object sender, int messageId, string messageName, string message) {
            if (ChatEvent != null) {
                var words = SplitMessage(message);
                var chatId = int.Parse(words[0]);
                var fromUserId = int.Parse(words[1]);
                var parsedMessage = words[2];

                var m = new MessageEventArgs_300301(messageId, messageName, chatId, fromUserId, parsedMessage);
                ChatEvent(this, m);
            }
        }

        // 301
        private void OnActionChatEvent(object sender, int messageId, string messageName, string message) {
            if (ActionChatEvent != null) {
                var words = SplitMessage(message);
                var chatId = int.Parse(words[0]);
                var fromUserId = int.Parse(words[1]);
                var parsedMessage = words[2];

                var m = new MessageEventArgs_300301(messageId, messageName, chatId, fromUserId, parsedMessage);

                ActionChatEvent(this, m);
            }
        }

        // 302 
        private void OnClientJoinEvent(object sender, int messageId, string messageName, string message) {
            if (ClientJoinEvent != null) {
                var words = SplitMessage(message);

                var chatId = int.Parse(words[0]);
                var userId = int.Parse(words[1]);
                var idle = Utility.ConvertIntToBool(int.Parse(words[2]));
                var admin = Utility.ConvertIntToBool(int.Parse(words[3]));
                var icon = int.Parse(words[4]);
                var nick = words[5];
                var login = words[6];
                var ip = IPAddress.Parse(words[7]);
                var host = words[8];
                var status = words[9];
                var image = Utility.Base64StringToBitmap(words[10]);

                var m = new MessageEventArgs_302310(messageId, messageName, chatId, userId, idle, admin, icon, nick, login, ip, host, status, image);

                ClientJoinEvent(m);
            }
        }

        // 303
        private void OnClientLeaveEvent(object sender, int messageId, string messageName, string message) {
            if (ClientLeaveEvent != null) {
                var words = SplitMessage(message);
                var chatId = int.Parse(words[0]);
                var userId = int.Parse(words[1]);

                var m = new MessageEventArgs_303331332(messageId, messageName, chatId, userId);

                ClientLeaveEvent(m);
            }
        }

        // 304
        private void OnStatusChangeEvent(object sender, int messageId, string messageName, string message) {
            if (StatusChangeEvent != null) {
                var words = SplitMessage(message);

                // If we thing we want to set the variable to -1 instead 
                // of catching exception when something fails we can do it like this.
                // int userId;
                // if(!(int.TryParse(words[0], out userId)))
                //     userId = -1;

                var userId = int.Parse(words[0]);
                var idle = Utility.ConvertIntToBool(int.Parse(words[1]));
                var admin = Utility.ConvertIntToBool(int.Parse(words[2]));
                var icon = int.Parse(words[3]);
                var nick = words[4];
                var status = words[5];

                var m = new MessageEventArgs_304(messageId, messageName, userId, idle, admin, icon, nick, status);

                StatusChangeEvent(m);
            }
        }

        // 305
        private void OnPrivateMessageEvent(object sender, int messageId, string messageName, string message) {
            if (PrivateMessageEvent != null) {
                var words = SplitMessage(message);

                var userId = int.Parse(words[0]);
                var parsedMessage = words[1];

                var m = new MessageEventArgs_305309(messageId, messageName, userId, parsedMessage);

                PrivateMessageEvent(this, m);
            }
        }

        // 306
        private void OnClientKickedEvent(object sender, int messageId, string messageName, string message) {
            if (ClientKickedEvent != null) {
                var words = SplitMessage(message);

                var victimId = int.Parse(words[0]);
                var killerId = int.Parse(words[1]);
                var parsedMessage = words[2];

                var m = new MessageEventArgs_306307(messageId, messageName, parsedMessage, victimId, killerId);

                ClientKickedEvent(m);
            }
        }

        // 307
        private void OnClientBannedEvent(object sender, int messageId, string messageName, string message) {
            if (ClientBannedEvent != null) {
                var words = SplitMessage(message);

                var victimId = int.Parse(words[0]);
                var killerId = int.Parse(words[1]);
                var parsedMessage = words[3];

                var m = new MessageEventArgs_306307(messageId, messageName, parsedMessage, victimId, killerId);

                ClientBannedEvent(m);
            }
        }

        // 308
        private void OnClientInformationEvent(object sender, int messageId, string messageName, string message) {
            if (ClientInformationEvent != null) {
                string[] w;
                string nick, login, host, clientVersion, cipherName, downloads,
                       uploads, status, transfer, path;
                int userId, icon, cipherBits, transferred, size, speed;
                bool idle, admin;
                IPAddress ip;
                DateTime loginTime, idleTime;
                Bitmap image;

                w = SplitMessage(message);
                userId = int.Parse(w[0]);
                idle = Utility.ConvertIntToBool(int.Parse(w[1]));
                admin = Utility.ConvertIntToBool(int.Parse(w[2]));
                icon = int.Parse(w[3]);
                nick = w[4];
                login = w[5];
                ip = IPAddress.Parse(w[6]);
                host = w[7];
                clientVersion = w[8];
                cipherName = w[9];
                cipherBits = int.Parse(w[10]);
                loginTime = DateTime.Parse(w[11]);
                idleTime = DateTime.Parse(w[12]);
                downloads = w[13];
                uploads = w[14];
                status = w[15];
                image = Utility.Base64StringToBitmap(w[16]);
                try {
                    // This try is needed because of a possbile bug in
                    // WiredServer which omitts the last five fields.
                    transfer = w[17];
                    path = w[18];
                    transferred = int.Parse(w[19]);
                    size = int.Parse(w[20]);
                    speed = int.Parse(w[21]);
                } catch (IndexOutOfRangeException e) {
                    transfer = "";
                    path = "";
                    transferred = -1;
                    size = -1;
                    speed = -1;
                    Debug.WriteLine("Messages.cs: Failed to set client information string. Setting default values. Exception: " + e);
                }
                var m = new MessageEventArgs_308(messageId, messageName, userId, image, idle, admin, icon, nick, login, status, ip, host, clientVersion, cipherName, cipherBits, loginTime, idleTime, downloads, uploads, transfer, path, transferred, size, speed);

                ClientInformationEvent(m);
            }
        }

        // 309
        private void OnBroadcastMessageEvent(object sender, int messageId, string messageName, string message) {
            if (BroadcastMessageEvent != null) {
                var w = SplitMessage(message);
                var userId = int.Parse(w[1]);
                var parsedMessage = w[2];

                var m = new MessageEventArgs_305309(messageId, messageName, userId, parsedMessage);

                BroadcastMessageEvent(this, m);
            }
        }

        // 310
        private void OnUserListEvent(object sender, int messageId, string messageName, string message) {
            if (UserListEvent != null) {
                var s = SplitMessage(message);
                int chatId = Convert.ToInt16(s[0]);
                int userId = Convert.ToInt16(s[1]);
                var idle = Convert.ToBoolean(Convert.ToInt16(s[2]));
                var admin = Convert.ToBoolean(Convert.ToInt16(s[3]));
                int icon = Convert.ToInt16(s[4]);
                var nick = s[5];
                var login = s[6];
                var ip = IPAddress.Parse(s[7]);
                var host = s[8];
                var status = s[9];
                var image = Utility.Base64StringToBitmap(s[10]);

                var m = new MessageEventArgs_302310(messageId, messageName, chatId, userId, idle, admin, icon, nick, login, ip, host, status, image);

                UserListEvent(m);
            }
        }

        // 311
        private void OnUserListDoneEvent(object sender, int messageId, string messageName, string message) {
            if (UserListDoneEvent != null) {
                int chatId = Convert.ToInt16(message);
                var m = new MessageEventArgs_311330(messageId, messageName, chatId);
                UserListDoneEvent(this, m);
            }
        }

        // 320
        private void OnNewsEvent(object sender, int messageId, string messageName, string message) {
            if (NewsEvent != null) {
                var w = SplitMessage(message);
                var nick = w[0];
                var postTime = DateTime.Parse(w[1]);
                var post = w[2];

                var m = new MessageEventArgs_320322(messageId, messageName, nick, postTime, post);

                NewsEvent(m);
            }
        }

        // 321
        private void OnNewsDoneEvent(object sender, int messageId, string messageName, string message) {
            if (NewsDoneEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                NewsDoneEvent(m);
            }
        }

        // 322
        private void OnNewsPostedEvent(object sender, int messageId, string messageName, string message) {
            if (NewsPostedEvent != null) {
                var w = SplitMessage(message);
                var nick = w[0];
                var postTime = DateTime.Parse(w[1]);
                var post = w[2];

                var m = new MessageEventArgs_320322(messageId, messageName, nick, postTime, post);

                NewsPostedEvent(m);
            }
        }

        // 330
        private void OnPrivateChatCreatedEvent(object sender, int messageId, string messageName, string message) {
            if (PrivateChatCreatedEvent != null) {
                var chatId = int.Parse(message);
                var m = new MessageEventArgs_311330(messageId, messageName, chatId);
                PrivateChatCreatedEvent(this, m);
            }
        }

        // 331
        private void OnPrivateChatInvitationEvent(object sender, int messageId, string messageName, string message) {
            if (PrivateChatInvitationEvent != null) {
                var w = SplitMessage(message);
                var chatId = int.Parse(w[0]);
                var userId = int.Parse(w[1]);
                var m = new MessageEventArgs_303331332(messageId, messageName, chatId, userId);
                PrivateChatInvitationEvent(this, m);
            }
        }

        // 332
        private void OnPrivateChatDeclinedEvent(object sender, int messageId, string messageName, string message) {
            if (PrivateChatDeclinedEvent != null) {
                var w = SplitMessage(message);
                var chatId = int.Parse(w[0]);
                var userId = int.Parse(w[1]);
                var m = new MessageEventArgs_303331332(messageId, messageName, chatId, userId);
                PrivateChatDeclinedEvent(this, m);
            }
        }

        // 340
        private void OnClientImageChangedEvent(object sender, int messageId, string messageName, string message) {
            if (ClientImageChangedEvent != null) {
                var w = SplitMessage(message);
                var userId = int.Parse(w[0]);
                var image = Utility.Base64StringToBitmap(w[1]);
                var m = new MessageEventArgs_340(messageId, messageName, userId, image);
                ClientImageChangedEvent(m);
            }
        }

        // 341
        private void OnChatTopicEvent(object sender, int messageId, string messageName, string message) {
            if (ChatTopicEvent != null) {
                var words = SplitMessage(message);
                int chatId = Convert.ToInt16(words[0]);
                var nick = words[1];
                var login = words[2];
                var ip = IPAddress.Parse(words[3]);
                var time = DateTime.Parse(words[4]);
                var topic = words[5];

                var m = new MessageEventArgs_341(messageId, messageName, chatId, nick, login, ip, time, topic);

                ChatTopicEvent(m);
            }
        }

        // 400
        private void OnTransferReadyEvent(object sender, int messageId, string messageName, string message) {
            if (TransferReadyEvent != null) {
                var w = SplitMessage(message);
                var path = w[0];
                var offset = int.Parse(w[1]);
                var hash = w[2];
                var m = new MessageEventArgs_400(messageId, messageName, path, offset, hash);
                TransferReadyEvent(m);
            }
        }

        // 401
        private void OnTransferQueuedEvent(object sender, int messageId, string messageName, string message) {
            if (TransferQueuedEvent != null) {
                var w = SplitMessage(message);
                var path = w[0];
                var position = int.Parse(w[1]);
                var m = new MessageEventArgs_401(messageId, messageName, path, position);
                TransferQueuedEvent(this, m);
            }
        }

        // 402
        private void OnFileInformationEvent(object sender, int messageId, string messageName, string message) {
            if (FileInformationEvent != null) {
                var w = SplitMessage(message);
                var path = w[0];
                var fileType = StringToFileType(w[1]);
                var size = int.Parse(w[2]);
                var created = DateTime.Parse(w[3]);
                var modified = DateTime.Parse(w[4]);
                var checksum = w[5];
                var comment = w[6];
                var m = new MessageEventArgs_402(messageId, messageName, path, fileType, size, created, modified, checksum, comment);
                FileInformationEvent(this, m);
            }
        }

        private MessageEventArgs_410420 ParseListingMessage(int messageId, string messageName, string message) {
            var w = SplitMessage(message);
            var path = w[0];
            var fileType = StringToFileType(w[1]);
            var size = long.Parse(w[2]);
            var created = DateTime.Parse(w[3]);
            var modified = DateTime.Parse(w[4]);
            var m = new MessageEventArgs_410420(messageId, messageName, path, fileType, size, created, modified);
            return m;
        }

        private static FileType StringToFileType(string fileTypeString) {
            FileType fileType;
            if (fileTypeString == "0") {
                fileType = FileType.FILE;
            } else if (fileTypeString == "1") {
                fileType = FileType.FOLDER;
            } else if (fileTypeString == "2") {
                fileType = FileType.UPLOADS;
            } else if (fileTypeString == "3") {
                fileType = FileType.DROPBOX;
            } else {
                throw new FormatException("File or Folder type is not of any recognable type.");
            }
            return fileType;
        }

        // 410
        private void OnFileListingEvent(object sender, int messageId, string messageName, string message) {
            if (FileListingEvent != null) {
                var m = ParseListingMessage(messageId, messageName, message);
                FileListingEvent(m);
            }
        }

        // 411
        private void OnFileListingDoneEvent(int messageId, string messageName, string message) {
            if (FileListingDoneEvent != null) {
                var w = SplitMessage(message);
                var path = w[0];
                var free = long.Parse(w[1]);
                var m = new MessageEventArgs_411(messageId, messageName, path, free);
                FileListingDoneEvent(m);
            }
        }

        // 420
        private void OnSearchListingEvent(object sender, int messageId, string messageName, string message) {
            if (SearchListingEvent != null) {
                var m = ParseListingMessage(messageId, messageName, message);
                SearchListingEvent(this, m);
            }
        }

        // 421
        private void OnSearchListingDoneEvent(object sender, int messageId, string messageName, string message) {
            if (SearchListingDoneEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, messageName);
                SearchListingDoneEvent(this, m);
            }
        }

        // 500
        private void OnCommandFailedEvent(object sender, int messageId, string messageName, string message) {
            if (CommandFailedEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                CommandFailedEvent(this, m);
            }
        }

        // 501
        private void OnCommandNotRecognizedEvent(object sender, int messageId, string messageName, string message) {
            if (CommandNotRecognizedEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                CommandNotRecognizedEvent(this, m);
            }
        }

        // 502
        private void OnCommandNotImplementedEvent(object sender, int messageId, string messageName, string message) {
            if (CommandNotImplementedEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                CommandNotImplementedEvent(this, m);
            }
        }

        // 503
        private void OnSyntaxErrorEvent(object sender, int messageId, string messageName, string message) {
            if (SyntaxErrorEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                SyntaxErrorEvent(this, m);
            }
        }

        // 510
        private void OnLoginFailedEvent(object sender, int messageId, string messageName, string message) {
            if (LoginFailedEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                LoginFailedEvent(this, m);
            }
        }

        // 511
        private void OnBannedEvent(object sender, int messageId, string messageName, string message) {
            if (BannedEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                BannedEvent(m);
            }
        }

        // 512
        private void OnClientNotFoundEvent(object sender, int messageId, string messageName, string message) {
            if (ClientNotFoundEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                ClientNotFoundEvent(this, m);
            }
        }

        // 513
        private void OnAccountNotFoundEvent(object sender, int messageId, string messageName, string message) {
            if (AccountNotFoundEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                AccountNotFoundEvent(this, m);
            }
        }

        // 514
        private void OnAccountExistsEvent(object sender, int messageId, string messageName, string message) {
            if (AccountExistsEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                AccountExistsEvent(this, m);
            }
        }

        // 515
        private void OnCannotBeDisconnectedEvent(object sender, int messageId, string messageName, string message) {
            if (CannotBeDisconnectedEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                CannotBeDisconnectedEvent(this, m);
            }
        }

        // 516
        private void OnPermissionDeniedEvent(object sender, int messageId, string messageName, string message) {
            Debug.WriteLine("CONNECTION:Messages -> WARNING! Permission denied. ID: " + messageId + " : message: " + message);

            if (PermissionDeniedEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                PermissionDeniedEvent(this, m);
            }
        }

        // 520
        private void OnFileOrDirectoryNotFoundEvent(object sender, int messageId, string messageName, string message) {
            if (FileOrDirectoryNotFoundEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                FileOrDirectoryNotFoundEvent(this, m);
            }
        }

        // 521
        private void OnFileOrDirectoryExistsEvent(object sender, int messageId, string messageName, string message) {
            if (FileOrDirectoryExistsEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                FileOrDirectoryExistsEvent(this, m);
            }
        }

        // 522
        private void OnChecksumMismatchEvent(object sender, int messageId, string messageName, string message) {
            if (ChecksumMismatchEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                ChecksumMismatchEvent(this, m);
            }
        }

        // 523
        private void OnQueueLimitExceededEvent(object sender, int messageId, string messageName, string message) {
            if (QueueLimitExceededEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                QueueLimitExceededEvent(this, m);
            }
        }

        // 600
        private void OnUserSpecificationEvent(object sender, int messageId, string messageName, string message) {
            if (UserSpecificationEvent != null) {
                var w = SplitMessage(message);
                var name = w[0];
                var password = w[1];
                var user = w[2];
                var privileges = w[3];
                Privileges p = null;
                //Privileges p = new Privileges(name, w[3]);

                var m = new MessageEventArgs_600(messageId, messageName, p, name, password, user);

                UserSpecificationEvent(this, m);
            }
        }

        // 601
        private void OnGroupSpecificationEvent(object sender, int messageId, string messageName, string message) {
            if (GroupSpecificationEvent != null) {
                var w = SplitMessage(message);
                var name = w[0];
                Privileges p = null;
                //Privileges p = new Privileges (name, w[1]);

                var m = new MessageEventArgs_601(messageId, messageName, p, name);

                GroupSpecificationEvent(this, m);
            }
        }

        // 602
        private void OnPrivilegesSpecificationEvent(object sender, int messageId, string messageName, string message) {
            if (PrivilegesSpecificationEvent != null) {
                Privileges p = null;
                //Privileges p = new Privileges("", message); // CheckThis
                var m = new MessageEventArgs_602(messageId, messageName, p);
                PrivilegesSpecificationEvent(m);
            }
        }

        // 610
        private void OnUserListingEvent(object sender, int messageId, string messageName, string message) {
            if (UserListingEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                UserListingEvent(this, m);
            }
        }

        // 611
        private void OnUserListingDoneEvent(object sender, int messageId, string messageName, string message) {
            if (UserListingDoneEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                UserListingDoneEvent(this, m);
            }
        }

        // 620
        private void OnGroupListingEvent(object sender, int messageId, string messageName, string message) {
            if (GroupListingEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                GroupListingEvent(this, m);
            }
        }

        // 621
        private void OnGroupListingDoneEvent(object sender, int messageId, string messageName, string message) {
            if (GroupListingDoneEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                GroupListingDoneEvent(this, m);
            }
        }

        // 7xx
        private void OnTrackerCategoryListingEvent(object sender, int messageId, string messageName, string message) {
            if (TrackerCategoryListingEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                TrackerCategoryListingEvent(this, m);
            }
        }

        // 7xx
        private void OnTrackerCategoryListingDoneEvent(object sender, int messageId, string messageName, string message) {
            if (TrackerCategoryListingDoneEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                TrackerCategoryListingDoneEvent(this, m);
            }
        }

        // 7xx
        private void OnTrackerServerListingEvent(object sender, int messageId, string messageName, string message) {
            if (TrackerServerListingEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                TrackerServerListingEvent(this, m);
            }
        }

        // 7xx
        private void OnTrackerServerListingDoneEvent(object sender, int messageId, string messageName, string message) {
            if (TrackerServerListingDoneEvent != null) {
                var m = new MessageEventArgs_Messages(messageId, messageName, message);
                TrackerServerListingDoneEvent(this, m);
            }
        }

        #endregion

        #region Message Parser

        /// <summary>Parses the messages</summary>
        /// <param name="msg">The message from the server</param>
        private void ParseMessage(string msg) {
            // Request the message identifier and the message data
            var msgId = Convert.ToInt32(msg.Substring(0, 3));
            var argument = msg.Substring(4);

            if (msgId == 310 || msgId == 340 || msgId == 410) {
                var length = 120;
                var end = "...'";
                if (argument.Length < 120) {
                    length = argument.Length;
                    end = "'";
                }
                Debug.WriteLine("CONNECTION:Messages -> Received: " + msgId + ": '"
                                + argument.Substring(0, length) + end);
            } else if (msgId != 320 && msgId != 321
                       && msgId != 410 && msgId != 411) {
                Debug.WriteLine("CONNECTION:Messages -> Received: " + msgId + ": '"
                                + argument + "'");
            }

            switch (msgId) {
                case 200:
                    OnServerInformationEvent(this, msgId, "Server Information", argument);
                    break;
                case 201:
                    OnLoginSucceededEvent(this, msgId, "Login Succeeded", argument);
                    break;
                case 202:
                    OnPingReplyEvent(this, msgId, "Ping Reply", argument);
                    break;
                case 203:
                    OnServerBannerEvent(this, msgId, "Server Banner", argument);
                    break;
                case 300:
                    OnChatEvent(this, msgId, "Chat", argument);
                    break;
                case 301:
                    OnActionChatEvent(this, msgId, "Action Chat", argument);
                    break;
                case 302:
                    OnClientJoinEvent(this, msgId, "Client Join", argument);
                    break;
                case 303:
                    OnClientLeaveEvent(this, msgId, "Client Leave", argument);
                    break;
                case 304:
                    OnStatusChangeEvent(this, msgId, "Status Change", argument);
                    break;
                case 305:
                    OnPrivateMessageEvent(this, msgId, "Private Message", argument);
                    break;
                case 306:
                    OnClientKickedEvent(this, msgId, "Client Kicked", argument);
                    break;
                case 307:
                    OnClientBannedEvent(this, msgId, "Client Banned", argument);
                    break;
                case 308:
                    OnClientInformationEvent(this, msgId, "Client Information", argument);
                    break;
                case 309:
                    OnBroadcastMessageEvent(this, msgId, "Broadcast Message", argument);
                    break;
                case 310:
                    OnUserListEvent(this, msgId, "User List", argument);
                    break;
                case 311:
                    OnUserListDoneEvent(this, msgId, "User List Done", argument);
                    break;
                case 320:
                    OnNewsEvent(this, msgId, "News", argument);
                    break;
                case 321:
                    OnNewsDoneEvent(this, msgId, "News Done", argument);
                    break;
                case 322:
                    OnNewsPostedEvent(this, msgId, "News Posted", argument);
                    break;
                case 330:
                    OnPrivateChatCreatedEvent(this, msgId, "Private Chat Created", argument);
                    break;
                case 331:
                    OnPrivateChatInvitationEvent(this, msgId, "Private Chat Invitation", argument);
                    break;
                case 332:
                    OnPrivateChatDeclinedEvent(this, msgId, "Private Chat Declined", argument);
                    break;
                case 340:
                    OnClientImageChangedEvent(this, msgId, "Client Image Change", argument);
                    break;
                case 341:
                    OnChatTopicEvent(this, msgId, "Chat Topic", argument);
                    break;
                case 400:
                    OnTransferReadyEvent(this, msgId, "Transfer Ready", argument);
                    break;
                case 401:
                    OnTransferQueuedEvent(this, msgId, "Transfer Queued", argument);
                    break;
                case 402:
                    OnFileInformationEvent(this, msgId, "File Information", argument);
                    break;
                case 410:
                    OnFileListingEvent(this, msgId, "File Listing", argument);
                    break;
                case 411:
                    OnFileListingDoneEvent(msgId, "File Listing Done", argument);
                    break;
                case 420:
                    OnSearchListingEvent(this, msgId, "Search Listing", argument);
                    break;
                case 421:
                    OnSearchListingDoneEvent(this, msgId, "Search Listing Done", argument);
                    break;
                case 500:
                    OnCommandFailedEvent(this, msgId, "Command Failed", argument);
                    break;
                case 501:
                    OnCommandNotRecognizedEvent(this, msgId, "Command Not Recognized", argument);
                    break;
                case 502:
                    OnCommandNotImplementedEvent(this, msgId, "Command Not Implemented", argument);
                    break;
                case 503:
                    OnSyntaxErrorEvent(this, msgId, "Syntax Error", argument);
                    break;
                case 510:
                    OnLoginFailedEvent(this, msgId, "Login Failed", argument);
                    break;
                case 511:
                    OnBannedEvent(this, msgId, "Banned", argument);
                    break;
                case 512:
                    OnClientNotFoundEvent(this, msgId, "Client Not Found", argument);
                    break;
                case 513:
                    OnAccountNotFoundEvent(this, msgId, "Account Not Found", argument);
                    break;
                case 514:
                    OnAccountExistsEvent(this, msgId, "Account Exists", argument);
                    break;
                case 515:
                    OnCannotBeDisconnectedEvent(this, msgId, "Cannot Be Disconnected", argument);
                    break;
                case 516:
                    OnPermissionDeniedEvent(this, msgId, "Permission Denied", argument);
                    break;
                case 520:
                    OnFileOrDirectoryNotFoundEvent(this, msgId, "File or Directory Not Found", argument);
                    break;
                case 521:
                    OnFileOrDirectoryExistsEvent(this, msgId, "File or Directory Exists", argument);
                    break;
                case 522:
                    OnChecksumMismatchEvent(this, msgId, "Checksum Mismatch", argument);
                    break;
                case 523:
                    OnQueueLimitExceededEvent(this, msgId, "Queue Limit Exceeded", argument);
                    break;
                case 600:
                    OnUserSpecificationEvent(this, msgId, "User Specification", argument);
                    break;
                case 601:
                    OnGroupSpecificationEvent(this, msgId, "Group Specification", argument);
                    break;
                case 602:
                    OnPrivilegesSpecificationEvent(this, msgId, "Privileges Specification", argument);
                    break;
                case 610:
                    OnUserListingEvent(this, msgId, "User Listing", argument);
                    break;
                case 611:
                    OnUserListingDoneEvent(this, msgId, "User Listing Done", argument);
                    break;
                case 620:
                    OnGroupListingEvent(this, msgId, "Group Listing", argument);
                    break;
                case 621:
                    OnGroupListingDoneEvent(this, msgId, "Group Listing Done", argument);
                    break;
                case 710:
                    OnTrackerCategoryListingEvent(this, msgId, "Tracker Category Listing", argument);
                    break;
                case 711:
                    OnTrackerCategoryListingDoneEvent(this, msgId, "Tracker Category Listing Done", argument);
                    break;
                case 720:
                    OnTrackerServerListingEvent(this, msgId, "Tracker Server Listing", argument);
                    break;
                case 721:
                    OnTrackerServerListingDoneEvent(this, msgId, "Tracker Server Listing Done", argument);
                    break;
                default:
                    Debug.WriteLine("Unhandled message id: '" + msgId + "'"); // TODO: Handle error
                    break;
            }
        }

        #endregion

        #region Other Methods

        /// <summary>Handles incoming messages</summary>
        /// <param name="message"></param>
        public void MessageReceived(string message) {
            try {
                ParseMessage(message);
            } catch (FormatException formatExp) {
                Debug.WriteLine("Error trying to parse the message "
                                + "recieved on socket!\nReason\n" + formatExp);
            }
        }

        /// <summary>Splits the string by the Utility.FS</summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private string[] SplitMessage(string message) {
            // Parse the server information event
            char[] delimiterChars = {Convert.ToChar(Utility.FS)};
            return message.Split(delimiterChars, StringSplitOptions.None);
        }

        #endregion
    }
}