#region Information and licence agreements

/*
 * NewsModel.cs 
 * Created by Ola Lindberg, 2006-12-09
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

using System.Collections.Generic;
using SharpWired.Connection;
using SharpWired.MessageEvents;

namespace SharpWired.Model.News {
    /// <summary>Represents all the news posted on the server</summary>
    public class News {

        private readonly List<NewsMessageItem> newsList = new List<NewsMessageItem>();
        
        /// <summary>Gets the news list. Sorted Descending (e.g. earliest post first).</summary>
        public List<NewsMessageItem> NewsList {
            get {
                var l = new List<NewsMessageItem>(newsList);
                l.Reverse();
                return l;
            }
        }
        
        public News(Messages m) {
            //All three are needed in order to sort the list
            m.NewsPostedEvent += OnNewsPosted;
            m.NewsEvent += OnNews;
            m.NewsDoneEvent += OnNewsDone;
        }
        
        public delegate void NewsPostedDelegate(NewsMessageItem newsPost);
        public delegate void NewsListingDoneDelegate(List<NewsMessageItem> newsListing);
        /// <summary>Raised when a news post is received from the server</summary>
        public event NewsPostedDelegate NewsPostedEvent;
        /// <summary>Raised when the requested news listing (eg. in respons to NEWS) is done.</summary>
        public event NewsListingDoneDelegate NewsListingDoneEvent;

        private void OnNewsPosted(MessageEventArgs_320322 message) {
            var n = new NewsMessageItem(message);
            if (!newsList.Contains(n)) {
                newsList.Add(n);
                if (NewsPostedEvent != null) {
                    NewsPostedEvent(n);
                }
            }
        }

        private void OnNews(MessageEventArgs_320322 message) {
            var n = new NewsMessageItem(message);
            if (!newsList.Contains(n)) {
                newsList.Add(n);
            }
        }

        private void OnNewsDone(MessageEventArgs_Messages message) {
            if (NewsListingDoneEvent != null) {
                NewsListingDoneEvent(NewsList);
            }
        }
    }
}