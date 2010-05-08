#region Information and licence agreements

/*
 * LagHandler.cs 
 * Created by Ola Lindberg, 2008-02-10
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
using SharpWired.MessageEvents;

namespace SharpWired.Connection {
    /// <summary>
    /// Holds information about the current server lag i.e. the time
    /// it takes for a message to travel from the client to the server
    /// and back to the client.
    /// </summary>
    public class LagHandler {
        private DateTime lastReceivedPing;
        private DateTime lastSentPing;
        private TimeSpan? lag;

        /// <summary>Gets the current lag</summary>
        public TimeSpan? CurrentLag {
            get {
                /* TimeSpan.CompareTo explanation
                 * >0 lastReceivedPing is before lastSentPing
                 * =0 lastReceivedPing is at the same time as lastSentPing
                 * <0 lastReceivedPing is after or lastSentPing is null
                 */
                var lagComparison = lastReceivedPing.CompareTo(lastSentPing);
                if ((lastReceivedPing.Ticks > 0) && (lastSentPing.Ticks > 0)) {
                    if (lagComparison >= 0) {
                        lag = lastReceivedPing.Subtract(lastSentPing);
                        return lag;
                    } else {
                        //If we fail we return last succesful lag time
                        return lag;
                    }
                }
                return null;
            }
        }

        /// <summary>Notify this when a ping is sent</summary>
        public void OnPingSent(object sender) {
            lastSentPing = DateTime.Now;
        }

        /// <summary>Notify this wehn a ping is received</summary>
        public void OnPingReceived(object sender, MessageEventArgs_Messages m) {
            lastReceivedPing = DateTime.Now;
        }
    }
}