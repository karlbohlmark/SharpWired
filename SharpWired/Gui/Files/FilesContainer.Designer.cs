namespace SharpWired.Gui.Files
{
    partial class FilesContainer
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tree = new SharpWired.Gui.Files.Tree();
            this.folderListing = new SharpWired.Gui.Files.FolderListing();
            this.breadCrumb = new SharpWired.Gui.Files.BreadCrumb();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 36);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.folderListing);
            this.splitContainer1.Size = new System.Drawing.Size(400, 197);
            this.splitContainer1.SplitterDistance = 123;
            this.splitContainer1.TabIndex = 6;
            // 
            // tree
            // 
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.Location = new System.Drawing.Point(0, 0);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(123, 197);
            this.tree.TabIndex = 6;
            // 
            // folderListing
            // 
            this.folderListing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderListing.Location = new System.Drawing.Point(0, 0);
            this.folderListing.Name = "details";
            this.folderListing.Size = new System.Drawing.Size(273, 197);
            this.folderListing.TabIndex = 0;
            // 
            // breadCrumb
            // 
            this.breadCrumb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.breadCrumb.Location = new System.Drawing.Point(5, 5);
            this.breadCrumb.Margin = new System.Windows.Forms.Padding(0);
            this.breadCrumb.Name = "breadCrumb";
            this.breadCrumb.Size = new System.Drawing.Size(400, 28);
            this.breadCrumb.TabIndex = 7;
            // 
            // FilesContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.breadCrumb);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FilesContainer";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(410, 238);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private FolderListing folderListing;
        private Tree tree;
        private BreadCrumb breadCrumb;
    }
}
