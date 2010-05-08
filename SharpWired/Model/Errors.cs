#region Information and licence agreements

/*
 * ErrorController.cs 
 * Created by Ola Lindberg 2007-12-15
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

using System.Text;
using SharpWired.Connection;
using SharpWired.Connection.Bookmarks;
using SharpWired.MessageEvents;
using SharpWired.Model;
using System;

namespace SharpWired.Model {
    /// <summary>
    /// Reads error messages from various sources (ie the connection layer) and 
    /// raises nicer error messages to consume by GUI
    /// </summary>
    public class Errors : ModelBase {
        /// <summary>Report a Connection Exception</summary>
        /// <param name="ce"></param>
        public void ReportConnectionExceptionError(ConnectionException ce) {
            var errorDescription = "";
            var solutionIdea = "";

            if (ce.Message == "HostNotFound") {
                errorDescription += "The server you tried connecting to doesn't exist.";
                solutionIdea += "Make sure the host name for the server you tried connecting to is correct.";
            } else if (ce.Message == "NoRouteToTost") {
                errorDescription += "A socket operation was attempted to an unreachable host";
                solutionIdea += "Check the host name you tried connecting to. Make sure it's correct.";
            } else if (ce.Message == "ConnectionRefused") {
                errorDescription += "No connection could be made because the target computer actively refused it. This usually results from trying to connect to a service that is inactive on the foreign host—that is, one with no server application running.";
                solutionIdea += "Check the host name you tried connecting to, make sure it's correct. You can also try to report this problem to the server owners.";
            } else { 
                errorDescription += "An unknown error occured.";
                solutionIdea += "Please report this error in the SharpWired bug tracker at http://code.google.com/p/sharpwired/issues/list. Error message is: " + ce;
            }

            solutionIdea += " For now, restart SharpWired before trying again."; // TODO: Remove this once SW recovers from connection problems

            Console.WriteLine("Error! " + errorDescription);
            Console.WriteLine("Bookmark: " + ce.Bookmark);

            if (LoginFailed != null)
                LoginFailed(errorDescription, solutionIdea, ce.Bookmark);
        }

        /// <summary>Delegate for ConnectionErrorEvent</summary>
        /// <param name="errorDescription"></param>
        /// <param name="solutionIdea"></param>
        /// <param name="bookmark"></param>
        public delegate void LoginToServerFailedDelegate(string errorDescription, string solutionIdea, Bookmark bookmark);

        /// <summary>Event triggered when loggin in to the server failed</summary>
        public event LoginToServerFailedDelegate LoginFailed;

        public Errors() {
            Model.ConnectionManager.Messages.LoginFailedEvent += Messages_LoginFailedEvent;
            Model.ConnectionManager.Messages.ClientNotFoundEvent += Messages_ClientNotFoundEvent;
        }

        private void Messages_LoginFailedEvent(object sender, MessageEventArgs_Messages messageEventArgs) {
            var currentBookmark = Model.ConnectionManager.CurrentBookmark;

            var errorDescription = "Login failure caused by a problem with the login or password when connecting to " + currentBookmark.Server.ServerName + ".";
            var solutionIdea = "Check your login name and password and try again.";

            LoginFailed(errorDescription, solutionIdea, currentBookmark);
        }

        private void Messages_ClientNotFoundEvent(object sender, MessageEventArgs_Messages messageEventArgs) {
            var currentBookmark = Model.ConnectionManager.CurrentBookmark;

            var errorDescription = "Login failure since the login name was not found on the server " + currentBookmark.Server.ServerName + ".";
            var solutionIdea = "Check your login name and try again.";

            LoginFailed(errorDescription, solutionIdea, currentBookmark);
        }
    }
}