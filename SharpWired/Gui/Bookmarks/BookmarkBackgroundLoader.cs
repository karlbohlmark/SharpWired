using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using SharpWired.Connection.Bookmarks;
using SharpWired.Gui.Resources.Icons;

namespace SharpWired.Gui.Bookmarks {
    /// <summary>
    /// This class takes a MenuItem and adds the bookmarks to it, after they have been read.
    /// Argument must be a BookmarkLoaderArgument!
    /// </summary>
    internal class BookmarkBackgroundLoader : BackgroundWorker {
        /// <summary>Set some properties we want.</summary>
        public BookmarkBackgroundLoader() {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        /// <summary>This runs the loader for you!</summary>
        /// <param name="pBookmarkItems">The list of items that represents bookmarks.</param>
        /// <param name="pMenuItem">The menu item for bookmarks.</param>
        /// <param name="pItemClickMethod">The method to invoke upon item.Click.</param>
        internal void LoadBookmarks(List<ToolStripMenuItem> pBookmarkItems, ToolStripMenuItem pMenuItem, EventHandler pItemClickMethod) {
            var arg = new BookmarkLoaderArgument(pBookmarkItems, pMenuItem, pItemClickMethod);
            RunWorkerAsync(arg);
        }

        /// <summary>The e.Argument must be BookmarkLoaderArgument.</summary>
        /// <param name="e"></param>
        protected override void OnDoWork(DoWorkEventArgs e) {
            base.OnDoWork(e);

            if (e.Argument is BookmarkLoaderArgument) {
                AddBookmarks(e.Argument as BookmarkLoaderArgument);
            } else {
                throw new ArgumentException("The argument must be of type " + typeof (BookmarkLoaderArgument) + "!");
            }
        }

        /// <summary>Read the bookmarks and report them.</summary>
        /// <param name="arg">The bookmarks to add.</param>
        private void AddBookmarks(BookmarkLoaderArgument arg) {
            if (BookmarkManager.Bookmarks == null) {
                // This is what takes time.
                BookmarkManager.GetBookmarks();
            }

            var done = 0;
            foreach (var bookmark in BookmarkManager.Bookmarks) {
                var item = new ToolStripMenuItem(bookmark.ToShortString());
                item.Tag = bookmark;
                item.Click += arg.ItemClickMethod;
                item.Image = IconHandler.Instance[IconList.File];
                arg.BookmarkItems.Add(item);
                //arg.MenuItem.DropDownItems.Add(item);

                // This is just for show ;-)
                done++;
                ReportProgress(done/BookmarkManager.Bookmarks.Count, item);
            }
        }

        #region Argument Class.

        /// <summary>Holds the arguments that is to be passed to the background loader.</summary>
        internal class BookmarkLoaderArgument {
            public EventHandler ItemClickMethod { get; set; }

            public ToolStripMenuItem MenuItem { get; set; }

            public List<ToolStripMenuItem> BookmarkItems { get; set; }

            internal BookmarkLoaderArgument(List<ToolStripMenuItem> pBookmarkItems, ToolStripMenuItem pItem, EventHandler pClickMethod) {
                MenuItem = pItem;
                BookmarkItems = pBookmarkItems;
                ItemClickMethod = pClickMethod;
            }
        }

        #endregion
    }
}