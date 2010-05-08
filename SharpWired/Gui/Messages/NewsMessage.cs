using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpWired.Model.News;
using SharpWired.Model.Users;
using System.Drawing;

namespace SharpWired.Gui.Messages {
    class NewsMessage : SharpWiredGuiBase, IPrintableHTML {

        private NewsMessageItem post;

        public NewsMessage(NewsMessageItem post) {
            this.post = post;
        }

        public string ToHTML() {

            var divClass = "";
            if (post.Nick == Model.Server.User.Nick) {
                divClass = " class=\"me\"";
            }

            NickColor nc = new NickColor(post.Nick);

            return
"<div" + divClass + @">
	<span class=""time"">" + post.Time.ToShortTimeString() + @"</span>
	<span class=""user"" style=""color: " + ColorTranslator.ToHtml(nc.RGB) + "\">" + post.Nick + @"</span>
	<span class=""text"">
		<p>
			" + post.Post.Replace("\n", "<br/>\n") + @"
		</p>
	</span>
</div>
";
        }
    }
}
