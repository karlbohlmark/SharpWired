using System.Windows.Forms;
using SharpWired.Controller;
using SharpWired.Model;

namespace SharpWired.Gui {
    internal class SharpWiredGui {
        public SharpWiredGui(SharpWiredModel model, SharpWiredController sharpWiredController) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SharpWiredForm(model, sharpWiredController));
        }
    }
}