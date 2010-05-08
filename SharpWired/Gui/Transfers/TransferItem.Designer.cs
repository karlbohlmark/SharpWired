namespace SharpWired.Gui.Transfers {
    partial class PrototypeTransferItem {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Clean up any resources being used.</summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.fileName = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.Label();
            this.pauseButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(50, 24);
            this.progressBar.Maximum = 1000;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(306, 16);
            this.progressBar.TabIndex = 0;
            this.progressBar.Click += new System.EventHandler(this.OnClicked);
            // 
            // fileName
            // 
            this.fileName.AutoSize = true;
            this.fileName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileName.Location = new System.Drawing.Point(46, 0);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(79, 21);
            this.fileName.TabIndex = 2;
            this.fileName.Text = "MyFile.zip";
            this.fileName.Click += new System.EventHandler(this.OnClicked);
            // 
            // info
            // 
            this.info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.info.AutoSize = true;
            this.info.Location = new System.Drawing.Point(47, 43);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(256, 13);
            this.info.TabIndex = 3;
            this.info.Text = "2 minutes remaining — 283 KiB of 2.83 MiB (38 KiB/s)";
            this.info.Click += new System.EventHandler(this.OnClicked);
            // 
            // pauseButton
            // 
            this.pauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pauseButton.FlatAppearance.BorderSize = 0;
            this.pauseButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.pauseButton.Location = new System.Drawing.Point(367, 20);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(24, 24);
            this.pauseButton.TabIndex = 5;
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.deleteButton.Location = new System.Drawing.Point(394, 20);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(24, 24);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.iconPictureBox.Image = global::SharpWired.Properties.Resources.format_justify_left;
            this.iconPictureBox.InitialImage = null;
            this.iconPictureBox.Location = new System.Drawing.Point(9, 14);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPictureBox.TabIndex = 1;
            this.iconPictureBox.TabStop = false;
            this.iconPictureBox.Click += new System.EventHandler(this.OnClicked);
            // 
            // TransferItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.info);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.iconPictureBox);
            this.Controls.Add(this.progressBar);
            this.Name = "TransferItem";
            this.Size = new System.Drawing.Size(428, 64);
            this.Click += new System.EventHandler(this.OnClicked);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.Label fileName;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button pauseButton;

    }
}
