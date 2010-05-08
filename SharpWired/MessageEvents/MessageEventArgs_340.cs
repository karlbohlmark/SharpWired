#region Information and licence agreements

/*
 * MessageEventArgs_340.cs 
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

using System.Drawing;

namespace SharpWired.MessageEvents {
    /// <summary>MessageEventArgs for message Client Image Changed (340)</summary>
    public class MessageEventArgs_340 : MessageEventArgs_201 {
        private readonly Bitmap image;

        /// <summary>The image for a user</summary>
        public Bitmap Image { get { return image; } }

        /// <summary>Constructor</summary>
        /// <param name="messageId">The message id</param>
        /// <param name="messageName">The message name</param>
        /// <param name="userId">The user id that changed image</param>
        /// <param name="image">The new image</param>
        public MessageEventArgs_340(int messageId, string messageName, int userId, Bitmap image)
            : base(messageId, messageName, userId) {
            this.image = image;
        }
    }
}