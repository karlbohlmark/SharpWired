using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpWired.Connection.Bookmarks;

namespace SharpWired.Gui.Messages {
    class ErrorMessage : IPrintableHTML {

        private string errorDescription;
        private string solutionIdea;
        private Bookmark bookmark;

        public ErrorMessage(string errorDescription, string solutionIdea, Bookmark bookmark) {
            this.errorDescription = errorDescription;
            this.solutionIdea = solutionIdea;
            this.bookmark = bookmark;
        }

        public string ToHTML() {
            return
@"<div class=""error"">
	<span class=""time"">" + DateTime.Now.ToShortTimeString() + @"</span>
	<span class=""description"">
		<p>
			" + errorDescription.Replace("\n", "<br/>\n") + @"
		</p>
	</span>
    <span class=""solution"">
		<p>
			" + solutionIdea.Replace("\n", "<br/>\n") + @"
		</p>
	</span>
</div>
";
        }
    }
}
