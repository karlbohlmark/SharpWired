namespace SharpWired.Gui.Files
{
    partial class BreadCrumb
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Clean up any resources being used.</summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.breadCrumbsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // breadCrumbsFlowLayoutPanel
            // 
            this.breadCrumbsFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.breadCrumbsFlowLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.breadCrumbsFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.breadCrumbsFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.breadCrumbsFlowLayoutPanel.Name = "breadCrumbsFlowLayoutPanel";
            this.breadCrumbsFlowLayoutPanel.Size = new System.Drawing.Size(150, 150);
            this.breadCrumbsFlowLayoutPanel.TabIndex = 0;
            this.breadCrumbsFlowLayoutPanel.WrapContents = false;
            // 
            // BreadCrumb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.breadCrumbsFlowLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "BreadCrumb";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel breadCrumbsFlowLayoutPanel;
    }
}
