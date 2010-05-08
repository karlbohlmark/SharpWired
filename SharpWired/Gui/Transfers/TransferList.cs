using System;
using System.Collections.Generic;
using System.Drawing;
using SharpWired.Model.Transfers;

namespace SharpWired.Gui.Transfers {
    public partial class TransferList : SharpWiredGuiBase {
        private List<PrototypeTransferItem> Items { get; set; }

        private delegate void ItemModifier(PrototypeTransferItem ti, bool odd);

        public TransferList() {
            InitializeComponent();
            Items = new List<PrototypeTransferItem>();
        }

        public override void Init() {
            base.Init();

            // TODO: Ugly to know about parent! Fix!
            Parent.VisibleChanged += TransferList_VisibleChanged;
        }

        private void TransferList_VisibleChanged(object sender, EventArgs e) {
            if (Parent.Visible) {
                RefreshStart();
            } else {
                RefreshStop();
            }
        }

        protected override void OnOnline() {
            Model.Server.Transfers.TransferAdded += OnTransferAdded;
        }

        protected override void OnOffline() {
            RefreshStop();
            Model.Server.Transfers.TransferAdded -= OnTransferAdded;
        }

        private void OnTransferAdded(ITransfer t) {
            AddTransferItem(t);
        }

        private void AddTransferItem(ITransfer t) {
            var ti = new PrototypeTransferItem();
            ti.Init(t);

            Items.Add(ti);
            RefreshStart();
        }

        private void Repaint() {
            var currentPos = 0;

            ModifyItems(
                delegate(PrototypeTransferItem current, bool odd)
                    {
                        current.Width = transferScrollPanel.Width - 2;
                        current.Top = currentPos*current.Height;
                        current.Clicked += OnItemClicked; // TODO: This shouldn't be done on each repaint!
                        current.Repaint();

                        SetItemColor(current, odd);
                        transferScrollPanel.Controls.Add(current);

                        currentPos += 1;
                        odd = !odd;
                    }
                );
        }

        private void OnClicked(object sender, EventArgs e) {
            ModifyItems(
                delegate(PrototypeTransferItem current, bool odd)
                    {
                        current.Selected = false;
                        SetItemColor(current, odd);
                    }
                );
        }

        private void OnItemClicked(PrototypeTransferItem ti, bool control) {
            ModifyItems(
                delegate(PrototypeTransferItem current, bool odd)
                    {
                        var clicked = ti == current;

                        if (clicked && control) {
                            current.Selected = !current.Selected;
                        } else if (clicked) {
                            current.Selected = true;
                        } else if (!control) {
                            current.Selected = false;
                        }

                        SetItemColor(current, odd);
                    }
                );
        }

        private void SetItemColor(PrototypeTransferItem ti, bool odd) {
            if (ti.Selected) {
                ti.BackColor = SystemColors.MenuHighlight;
            } else if (odd) {
                ti.BackColor = SystemColors.Window;
            } else {
                ti.BackColor = SystemColors.Control;
            }
        }

        private void ModifyItems(ItemModifier modify) {
            var odd = true;
            foreach (var current in Items) {
                modify(current, odd);
                odd = !odd;
            }
        }

        private void refreshTimer_Tick(object sender, EventArgs e) {
            Repaint();
        }

        private void RefreshStart() {
            if (Visible && Items.Count > 0 && !refreshTimer.Enabled) {
                refreshTimer.Start();
            }
        }

        private void RefreshStop() {
            if (refreshTimer.Enabled) {
                refreshTimer.Stop();
            }
        }
    }
}