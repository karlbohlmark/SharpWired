#region Information and licence agreements

/*
 * News.cs
 * Created by Ola Lindberg, 2006-12-10
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
using SharpWired.Model.News;
using System.Diagnostics;
using SharpWired.Gui.Messages;

namespace SharpWired.Gui.News {
    public partial class NewsContainer : WebBrowserGuiBase {
        private delegate void WriteToNewsCallback(GuiMessageItem guiMessage);

        public NewsContainer() {
            InitializeComponent();
        }

        public override void Init() {
            base.Init();
        }

        protected override void OnOnline() {
            Model.Server.News.NewsPostedEvent += OnNewsPostReceived;
            Model.Server.News.NewsListingDoneEvent += OnNewsListingDone;

            ToggleWindowsFormControl(postNewsButton);
            ToggleWindowsFormControl(postNewsTextBox);
            ResetWebBrowser(newsWebBrowser);
        }

        protected override void OnOffline() {
            Model.Server.News.NewsPostedEvent -= OnNewsPostReceived;
            Model.Server.News.NewsListingDoneEvent += OnNewsListingDone;

            ToggleWindowsFormControl(postNewsButton);
            ToggleWindowsFormControl(postNewsTextBox);
        }

        private void OnNewsListingDone(List<NewsMessageItem> newsList) {
            foreach (var n in newsList) {
                OnNewsPostReceived(n);
            }
        }

        private void OnNewsPostReceived(NewsMessageItem newPost) {
            var m = new NewsMessage(newPost);
            AppendHTMLToWebBrowser(newsWebBrowser, m);
        }

        private void postNewsButton_Click(object sender, EventArgs e) {
            //TODO: Privileges: Check if we are allowed to post news
            var text = postNewsTextBox.Text.Trim();
            if (text.Length > 0) {
                Model.ConnectionManager.Commands.Post(postNewsTextBox.Text);
            }

            postNewsTextBox.Clear();
        }
    }
}