using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpWired.Model.Messaging;
using System.Drawing;

namespace SharpWired.Gui.Messages {
    class ChatMessage : SharpWiredGuiBase, IPrintableHTML {
        private ChatMessageItem message;

        public ChatMessage(ChatMessageItem message) {
            this.message = message;
        }

        public string ToHTML() {

            var divClass = "";
            if (message.FromUser == Model.Server.User) {
                divClass = " class=\"me\"";
            }

            return
"<div" + divClass + @">
	<span class=""time"">" + message.Time.ToShortTimeString() + @"</span>
	<span class=""user"" style=""color: " + ColorTranslator.ToHtml(message.FromUser.Color) + "\">" + message.FromUser.Nick + @"</span>
	<span class=""text"">
		<p>
			" + message.ChatMessage.Replace("\n", "<br/>\n") + @"
		</p>
	</span>
</div>
";
        }
    }
}
