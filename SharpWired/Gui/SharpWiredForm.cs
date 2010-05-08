#region Information and licence agreements

/*
 * SharpWiredForm.cs 
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using SharpWired.Connection.Bookmarks;
using SharpWired.Controller;
using SharpWired.Gui.About;
using SharpWired.Gui.Bookmarks;
using SharpWired.Model;
using WiredControls.Containers.Forms;
using WiredControls.ToolStripItems;

namespace SharpWired.Gui {
    /// <summary>The main GUI</summary>
    public partial class SharpWiredForm : WiredForm {
        private readonly SharpWiredModel model;
        private BookmarkBackgroundLoader mBookmarkBackgroundLoader;

        /// <summary>A list of the ToolStripMenuItems that represents bookmarks.</summary>
        private readonly List<ToolStripMenuItem> bookmarkItems = new List<ToolStripMenuItem>();

        /// <summary>Constructor</summary>
        public SharpWiredForm(SharpWiredModel model,
                              SharpWiredController sharpWiredController) {
            this.model = model;

            InitializeComponent();

            chatUserContainer.Init();
            newsContainer.Init();
            filesContainer.Init();
            transferContainer.Init();

            chatUserContainer.Dock = DockStyle.Fill;
            newsContainer.Dock = DockStyle.Fill;
            filesContainer.Dock = DockStyle.Fill;
            transferContainer.Dock = DockStyle.Fill;

            newsContainer.Visible = false;
            chatUserContainer.Visible = true;
            filesContainer.Visible = false;
            transferContainer.Visible = false;

            publicChatToolStripButton.Enabled = false;

            BookmarkManager.GetBookmarks();

            model.Connected += OnLoggedIn;
        }

        public void OnLoggedIn(Server s) {
            s.Offline += OnOffline;

            var onlineMessage = new StringBuilder();
            onlineMessage.Append("Connected");
            if (model.Server.ServerName != "") {
                onlineMessage.Append(" to: " + model.Server.ServerName);
            }

            UpdateToolStripText(onlineMessage.ToString());

            var t = GetToolStripMenuItem(mainMenu, "disconnectToolStripMenuItem");
            if (t != null && !t.Enabled) {
                ToggleToolStripItem(t);
            }
        }

        /// <summary>Returns the first ToolStripItem in the given MenuStrip that matched the given name.</summary>
        /// <param name="strip"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private ToolStripItem GetToolStripMenuItem(MenuStrip strip, string name) {
            var t = strip.Items.Find(name, true);
            for (var i = 0; i < t.Length; i++) {
                if (t[i].Name == name) {
                    return t[i];
                }
            }
            return null;
        }

        public void OnOffline() {
            UpdateToolStripText("Disconnected");

            var t = GetToolStripMenuItem(mainMenu, "disconnectToolStripMenuItem");
            if (t != null && t.Enabled) {
                ToggleToolStripItem(t);
            }
        }

        private void Exit(object sender) {
            Application.Exit();
        }

        private void Disconnect(object sender) {
            if (SharpWiredModel.Instance.Server != null) {
                model.Disconnect();
            }
        }

        #region Bookmark in the menu.

        /// <summary>Displays the bookmark dialog window</summary>
        /// <param name="sender"></param>
        private void ShowBookmarksDialog(object sender) {
            using (var diag = new BookmarkManagerDialog()) {
                // NOTE: Bookmark manager could be shown as a modless dialog
                diag.ShowDialog(this);

                if (diag.BookmarkToConnect != null) {
                    var bookmark = diag.BookmarkToConnect;
                    model.Connect(bookmark);
                }
            }
        }

        /// <summary>User wants to manage bookmarks. Open the bookmarmanager gui.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void manageBookmarksToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowBookmarksDialog(sender);
        }

        /// <summary>
        /// When opening the Bookmark menu item, we start a background worker that
        /// reads the bookmark file (which takes some time > 0.1s) and adds the items
        /// as they are created.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bookmarksToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            // Removing should be quick, even if its n^2 or so.
            if (bookmarkItems.Count > 0) {
                foreach (var item in bookmarkItems) {
                    bookmarksToolStripMenuItem.DropDownItems.Remove(item);
                }
            }

            if (mLoadingToolStripMenuItem != null
                || bookmarksToolStripMenuItem.DropDownItems.Contains(mLoadingToolStripMenuItem)) {
                bookmarksToolStripMenuItem.DropDownItems.Remove(mLoadingToolStripMenuItem);
            }
            // Add the haxxor (Loading...) item again.
            mLoadingToolStripMenuItem = new AnimatedLoaderItem("(Loading...)");
            (mLoadingToolStripMenuItem as AnimatedLoaderItem).Start();
            bookmarksToolStripMenuItem.DropDownItems.Add(mLoadingToolStripMenuItem);

            // Create a loader that can read the bookmark file in the background and then
            // report to us the items to add.
            if (mBookmarkBackgroundLoader == null) {
                mBookmarkBackgroundLoader = new BookmarkBackgroundLoader();
            }

            mBookmarkBackgroundLoader.ProgressChanged += mBookmarkBackgroundLoader_ProgressChanged;
            mBookmarkBackgroundLoader.RunWorkerCompleted += mBookmarkBackgroundLoader_RunWorkerCompleted;

            // If the loader is working, try cancel and the invoke again.
            if (mBookmarkBackgroundLoader.IsBusy) {
                mBookmarkBackgroundLoader.CancelAsync();
            }
            if (!mBookmarkBackgroundLoader.IsBusy) {
                mBookmarkLoadingTimer.Start();
                mBookmarkBackgroundLoader.LoadBookmarks(bookmarkItems, bookmarksToolStripMenuItem, BookmarkItemClick);
            }
        }

        /// <summary>The worker is done. Remove the (Loading...) menu item and remove event listeners.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mBookmarkBackgroundLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            bookmarksToolStripMenuItem.DropDownItems.Remove(mLoadingToolStripMenuItem);
            mBookmarkBackgroundLoader.ProgressChanged -= mBookmarkBackgroundLoader_ProgressChanged;
            mBookmarkBackgroundLoader.RunWorkerCompleted -= mBookmarkBackgroundLoader_RunWorkerCompleted;
            mBookmarkLoadingTimer.Stop();
            (mLoadingToolStripMenuItem as AnimatedLoaderItem).Stop();
        }

        /// <summary>The loader have loaded something. Add it to the menu.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mBookmarkBackgroundLoader_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if (e.UserState is ToolStripMenuItem) {
                bookmarksToolStripMenuItem.DropDownItems.Add(e.UserState as ToolStripMenuItem);
            }
        }

        /// <summary>The method that is invoked when a bookmark item is clicked.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BookmarkItemClick(object sender, EventArgs e) {
            if ((sender as ToolStripMenuItem).Tag is Bookmark) {
                model.Connect((sender as ToolStripMenuItem).Tag as Bookmark);
            }
        }

        private void mBookmarkLoadingTimer_Tick(object sender, EventArgs e) {
            var text = mLoadingToolStripMenuItem.Text;
            // cut out loading.
            var t = text.Substring(1, text.Length - 2);
            // move one char from beginning to end, or vice versa.
            var nt = t.Substring(1, t.Length - 1) + t[0];
            mLoadingToolStripMenuItem.Text = "(" + nt + ")";
        }

        #endregion

        #region Listeners from GUI

        private void aboutSharpWiredToolStripMenuItem_Click(object sender, EventArgs e) {
            var box = new AboutBox();
            box.ShowDialog();
            box.Dispose();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Disconnect(sender);
            Exit(sender);
        }

        private void ExitToolStripButton_Click(object sender, EventArgs e) {
            Disconnect(sender);
            Exit(sender);
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e) {
            Disconnect(sender);
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowBookmarksDialog(sender);
        }

        /// <summary>The news button was clicked</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newsToolStripButton_Click(object sender, EventArgs e) {
            newsContainer.Visible = true;
            chatUserContainer.Visible = false;
            filesContainer.Visible = false;
            transferContainer.Visible = false;

            publicChatToolStripButton.Enabled = true;
            newsToolStripButton.Enabled = false;
            filesToolStripButton.Enabled = true;
            transfersToolStripButton.Enabled = true;
        }

        /// <summary>The public chat button was clicked</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void publicChatToolStripButton_Click(object sender, EventArgs e) {
            newsContainer.Visible = false;
            chatUserContainer.Visible = true;
            filesContainer.Visible = false;
            transferContainer.Visible = false;

            publicChatToolStripButton.Enabled = false;
            newsToolStripButton.Enabled = true;
            filesToolStripButton.Enabled = true;
            transfersToolStripButton.Enabled = true;
        }

        /// <summary>The files button was clicked</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filesToolStripButton_Click(object sender, EventArgs e) {
            filesContainer.Visible = true;
            chatUserContainer.Visible = false;
            newsContainer.Visible = false;
            transferContainer.Visible = false;

            publicChatToolStripButton.Enabled = true;
            newsToolStripButton.Enabled = true;
            filesToolStripButton.Enabled = false;
            transfersToolStripButton.Enabled = true;
        }

        /// <summary>The transfers button was clicked</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void transfersToolStripButton_Click(object sender, EventArgs e) {
            filesContainer.Visible = false;
            chatUserContainer.Visible = false;
            newsContainer.Visible = false;
            transferContainer.Visible = true;

            publicChatToolStripButton.Enabled = true;
            newsToolStripButton.Enabled = true;
            filesToolStripButton.Enabled = true;
            transfersToolStripButton.Enabled = false;
        }

        #endregion

        #region Thread safe manipulation

        private delegate void UpdateToolStripTextCallback(String text);

        private delegate void ToggleToolStripItemCallback(ToolStripItem tsi);

        private void UpdateToolStripText(String text) {
            if (InvokeRequired) {
                UpdateToolStripTextCallback callback = UpdateToolStripText;
                Invoke(callback, new object[] {text});
            } else {
                var toolstrips = mainStatusStrip.Items.Find("toolStripStatusLabel_ServerStatus", true);
                toolstrips[0].Text = text;
            }
        }

        private void ToggleToolStripItem(ToolStripItem tsi) {
            if (InvokeRequired) {
                ToggleToolStripItemCallback callback
                    = ToggleToolStripItem;
                Invoke(callback, new object[] {tsi});
            } else {
                tsi.Enabled = !tsi.Enabled;
            }
        }

        #endregion
    }
}