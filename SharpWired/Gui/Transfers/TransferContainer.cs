namespace SharpWired.Gui.Transfers {
    public partial class TransferContainer : SharpWiredGuiBase {
        public TransferContainer() {
            InitializeComponent();
        }

        public override void Init() {
            transferList1.Init();
        }
    }
}