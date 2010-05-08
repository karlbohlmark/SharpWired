#region Information and licence agreements

/*
 * HeartBeatTimer.cs
 * Created by Ola Lindberg, 2008-01-26
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
using System.Threading;

namespace SharpWired.Connection {
    /// <summary>Timer that keeps connection to the server by sending regular PING commands</summary>
    internal class HeartBeatTimer {
        private ConnectionManager connectionManager;
        private Timer timer;
        private readonly HeartBeatHandler heartBeatHandler;

        public void StartTimer() {
            TimerCallback tc = heartBeatHandler.DoPing;
            timer = new Timer(tc);
            var waitBeforeStarting = 10000; // TODO: Move to configuration
            var waitBetwenPings = 60000;    // TODO: Move to configuration
            timer.Change(waitBeforeStarting, waitBetwenPings);
        }

        public void StopTimer() {
            timer.Dispose();
        }

        public HeartBeatTimer(ConnectionManager connectionManager) {
            this.connectionManager = connectionManager;
            heartBeatHandler = new HeartBeatHandler(connectionManager);
        }
    }

    /// <summary>The TimerCallback object receiving the message sent from the timer</summary>
    internal class HeartBeatHandler {
        private readonly ConnectionManager connectionManager;
        private DateTime lastPing;

        public DateTime LastSentPing { get { return lastPing; } }

        public void DoPing(Object stateInfo) {
            connectionManager.Commands.Ping(this);
            lastPing = DateTime.Now;
        }

        public HeartBeatHandler(ConnectionManager connectionManager) {
            this.connectionManager = connectionManager;
        }
    }
}