using System.Windows.Forms;
using SharpWired.Model.Users;

namespace SharpWired.Gui.Chat {
    internal class WiredListViewItem : ListViewItem {
        public User UserItem { get; set; }

        public WiredListViewItem(User user, string nick, string imageIndex)
            : base(nick, imageIndex) {
            UserItem = user;
        }

        public WiredListViewItem(User user, string[] subItems, string imageKey)
            : base(subItems, imageKey) {
            UserItem = user;
        }
    }
}