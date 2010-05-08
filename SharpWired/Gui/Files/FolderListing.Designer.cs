namespace SharpWired.Gui.Files
{
    partial class FolderListing
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
            this.detailsListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // detailsListView
            // 
            this.detailsListView.AllowColumnReorder = true;
            this.detailsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsListView.Location = new System.Drawing.Point(0, 0);
            this.detailsListView.Name = "detailsListView";
            this.detailsListView.Size = new System.Drawing.Size(418, 298);
            this.detailsListView.TabIndex = 0;
            this.detailsListView.UseCompatibleStateImageBehavior = false;
            this.detailsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseDoubleClick);
            this.detailsListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            // 
            // FolderListing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.detailsListView);
            this.Name = "FolderListing";
            this.Size = new System.Drawing.Size(418, 298);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView detailsListView;
    }
}
