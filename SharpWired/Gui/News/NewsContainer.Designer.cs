#region Information and licence agreements
/*
 * NewsUserControl.Designer.cs
 * Created by Ola Lindberg, 2006-12-10
 * 
 * SharpWired - a Wired client.
 * See: http://www.zankasoftware.com/wired/ for more infromation about Wired
 * 
 * Copyright (C) Ola Lindberg (http://olalindberg.com)
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301 USA
 */
#endregion

namespace SharpWired.Gui.News
{
    /// <summary>GUI class for news view</summary>
    partial class NewsContainer
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
            this.newsWebBrowser = new System.Windows.Forms.WebBrowser();
            this.newsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.newsWrapperPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.postNewsTextBox = new System.Windows.Forms.TextBox();
            this.postNewsButton = new System.Windows.Forms.Button();
            this.newsSplitContainer.Panel1.SuspendLayout();
            this.newsSplitContainer.Panel2.SuspendLayout();
            this.newsSplitContainer.SuspendLayout();
            this.newsWrapperPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // newsWebBrowser
            // 
            this.newsWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newsWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.newsWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.newsWebBrowser.Name = "newsWebBrowser";
            this.newsWebBrowser.Size = new System.Drawing.Size(455, 258);
            this.newsWebBrowser.TabIndex = 0;
            // 
            // newsSplitContainer
            // 
            this.newsSplitContainer.BackColor = System.Drawing.SystemColors.Control;
            this.newsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newsSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.newsSplitContainer.Location = new System.Drawing.Point(5, 5);
            this.newsSplitContainer.Name = "newsSplitContainer";
            this.newsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // newsSplitContainer.Panel1
            // 
            this.newsSplitContainer.Panel1.Controls.Add(this.newsWrapperPanel);
            // 
            // newsSplitContainer.Panel2
            // 
            this.newsSplitContainer.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.newsSplitContainer.Size = new System.Drawing.Size(457, 325);
            this.newsSplitContainer.SplitterDistance = 260;
            this.newsSplitContainer.TabIndex = 1;
            // 
            // newsWrapperPanel
            // 
            this.newsWrapperPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newsWrapperPanel.Controls.Add(this.newsWebBrowser);
            this.newsWrapperPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newsWrapperPanel.Location = new System.Drawing.Point(0, 0);
            this.newsWrapperPanel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.newsWrapperPanel.Name = "newsWrapperPanel";
            this.newsWrapperPanel.Size = new System.Drawing.Size(457, 260);
            this.newsWrapperPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.74398F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.25602F));
            this.tableLayoutPanel1.Controls.Add(this.postNewsTextBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.postNewsButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(457, 61);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // postNewsTextBox
            // 
            this.postNewsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.postNewsTextBox.Enabled = false;
            this.postNewsTextBox.Location = new System.Drawing.Point(0, 1);
            this.postNewsTextBox.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.postNewsTextBox.Multiline = true;
            this.postNewsTextBox.Name = "postNewsTextBox";
            this.postNewsTextBox.Size = new System.Drawing.Size(368, 59);
            this.postNewsTextBox.TabIndex = 2;
            // 
            // postNewsButton
            // 
            this.postNewsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.postNewsButton.Enabled = false;
            this.postNewsButton.Location = new System.Drawing.Point(373, 0);
            this.postNewsButton.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.postNewsButton.Name = "postNewsButton";
            this.postNewsButton.Size = new System.Drawing.Size(84, 61);
            this.postNewsButton.TabIndex = 1;
            this.postNewsButton.Text = "Post";
            this.postNewsButton.UseVisualStyleBackColor = true;
            this.postNewsButton.Click += new System.EventHandler(this.postNewsButton_Click);
            // 
            // NewsContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.newsSplitContainer);
            this.Name = "NewsContainer";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(467, 335);
            this.newsSplitContainer.Panel1.ResumeLayout(false);
            this.newsSplitContainer.Panel2.ResumeLayout(false);
            this.newsSplitContainer.ResumeLayout(false);
            this.newsWrapperPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser newsWebBrowser;
        private System.Windows.Forms.SplitContainer newsSplitContainer;
        private System.Windows.Forms.Button postNewsButton;
        private System.Windows.Forms.Panel newsWrapperPanel;
        private System.Windows.Forms.TextBox postNewsTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
