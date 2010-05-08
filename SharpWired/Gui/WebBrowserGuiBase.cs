using System;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace SharpWired.Gui {
    /// <summary>Base class for all SharpWired views that's using a WebBrowser to display data.</summary>
    public class WebBrowserGuiBase : SharpWiredGuiBase {
        private String browserHeader;
        private String browserFooter;
        private readonly StringBuilder browserBody = new StringBuilder();
        private int altItemCounter;

        private delegate void AppendHTMLToWebBrowserCallbackObsolete(WebBrowser browser, GuiMessageItem guiMessage);
        private delegate void AppendHTMLToWebBrowserCallback(WebBrowser browser, IPrintableHTML htmlItem);

        private delegate void ResetWebBrowserCallback(WebBrowser browser);

        protected string AltItemBeginningHtml {
            get {
                if (altItemCounter%2 == 0) {
                    altItemCounter++;
                    return "<div class=\"standard\">";
                }
                altItemCounter++;
                return "<div class=\"alternative\">";
            }
        }

        [Obsolete]
        protected void AppendHTMLToWebBrowser(WebBrowser browser, GuiMessageItem guiMessage) {
            if (InvokeRequired) {
                AppendHTMLToWebBrowserCallbackObsolete c = AppendHTMLToWebBrowser;
                Invoke(c, new object[] {browser, guiMessage});
            } else {
                browserBody.Append(guiMessage.HTML);
                browser.DocumentText = browserHeader + browserBody + browserFooter;
            }
        }

        protected void AppendHTMLToWebBrowser(WebBrowser browser, IPrintableHTML htmlItem) {
            if (InvokeRequired) {
                AppendHTMLToWebBrowserCallback c = AppendHTMLToWebBrowser;
                Invoke(c, new object[] { browser, htmlItem });
            } else {
                browserBody.Append(htmlItem.ToHTML());
                browser.DocumentText = browserHeader + browserBody + browserFooter;
            }
        }

        protected void ResetWebBrowser(WebBrowser browser) {
            if (InvokeRequired) {
                ResetWebBrowserCallback c = ResetWebBrowser;
                Invoke(c, new object[] {browser});
            } else {
                var chatStyleSheet = "<link href=\"" + GuiUtil.CSSFilePath + "\\GUI\\SharpWiredStyleSheet.css\" rel=\"stylesheet\" type=\"text/css\" />";
                var chatJavaScript = "<script>function pageDown () { if (window.scrollBy) window.scrollBy(0, window.innerHeight ? window.innerHeight : document.body.clientHeight); }</script>";

                browserHeader = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">" +
                                "<html xmlns=\"http://www.w3.org/1999/xhtml\" xml:lang=\"en\" lang=\"en\">" +
                                "<head><title>SharpWired</title>" +
                                chatJavaScript +
                                chatStyleSheet +
                                "</head><body onload=\"pageDown(); return false;\">\n";

                browserFooter = "</body></html>";

                browser.DocumentText = browserHeader + browserFooter;
                browserBody.Length = 0;
            }
        }
    }
}