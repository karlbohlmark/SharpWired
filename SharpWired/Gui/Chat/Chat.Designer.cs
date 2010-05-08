namespace SharpWired.Gui.Chat {
    partial class Chat {
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
            this.components = new System.ComponentModel.Container();
            this.chatWebBrowser = new System.Windows.Forms.WebBrowser();
            this.chatSplitContainer = new System.Windows.Forms.SplitContainer();
            this.chatPanel = new System.Windows.Forms.Panel();
            this.topicWrapperPanel = new System.Windows.Forms.Panel();
            this.topicDisplayLabel = new System.Windows.Forms.Label();
            this.setByLabel = new System.Windows.Forms.Label();
            this.setByHeaderLabel = new System.Windows.Forms.Label();
            this.topicHeaderLabel = new System.Windows.Forms.Label();
            this.topicTextBox = new System.Windows.Forms.TextBox();
            this.chatInputTable = new System.Windows.Forms.TableLayoutPanel();
            this.sendChatButton = new System.Windows.Forms.Button();
            this.chatInputTextBox = new System.Windows.Forms.TextBox();
            this.chatToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.chatSplitContainer.Panel1.SuspendLayout();
            this.chatSplitContainer.Panel2.SuspendLayout();
            this.chatSplitContainer.SuspendLayout();
            this.chatPanel.SuspendLayout();
            this.topicWrapperPanel.SuspendLayout();
            this.chatInputTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // chatWebBrowser
            // 
            this.chatWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.chatWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.chatWebBrowser.Name = "chatWebBrowser";
            this.chatWebBrowser.Size = new System.Drawing.Size(437, 182);
            this.chatWebBrowser.TabIndex = 1;
            // 
            // chatSplitContainer
            // 
            this.chatSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.chatSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.chatSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.chatSplitContainer.Name = "chatSplitContainer";
            this.chatSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // chatSplitContainer.Panel1
            // 
            this.chatSplitContainer.Panel1.Controls.Add(this.chatPanel);
            this.chatSplitContainer.Panel1.Controls.Add(this.topicWrapperPanel);
            // 
            // chatSplitContainer.Panel2
            // 
            this.chatSplitContainer.Panel2.Controls.Add(this.chatInputTable);
            this.chatSplitContainer.Size = new System.Drawing.Size(439, 258);
            this.chatSplitContainer.SplitterDistance = 229;
            this.chatSplitContainer.TabIndex = 3;
            // 
            // chatPanel
            // 
            this.chatPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chatPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatPanel.Controls.Add(this.chatWebBrowser);
            this.chatPanel.Location = new System.Drawing.Point(0, 44);
            this.chatPanel.Name = "chatPanel";
            this.chatPanel.Size = new System.Drawing.Size(439, 184);
            this.chatPanel.TabIndex = 4;
            // 
            // topicWrapperPanel
            // 
            this.topicWrapperPanel.Controls.Add(this.topicDisplayLabel);
            this.topicWrapperPanel.Controls.Add(this.setByLabel);
            this.topicWrapperPanel.Controls.Add(this.setByHeaderLabel);
            this.topicWrapperPanel.Controls.Add(this.topicHeaderLabel);
            this.topicWrapperPanel.Controls.Add(this.topicTextBox);
            this.topicWrapperPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topicWrapperPanel.Location = new System.Drawing.Point(0, 0);
            this.topicWrapperPanel.Name = "topicWrapperPanel";
            this.topicWrapperPanel.Size = new System.Drawing.Size(439, 44);
            this.topicWrapperPanel.TabIndex = 3;
            // 
            // topicDisplayLabel
            // 
            this.topicDisplayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.topicDisplayLabel.Enabled = false;
            this.topicDisplayLabel.Location = new System.Drawing.Point(49, 7);
            this.topicDisplayLabel.Name = "topicDisplayLabel";
            this.topicDisplayLabel.Size = new System.Drawing.Size(385, 16);
            this.topicDisplayLabel.TabIndex = 4;
            this.chatToolTip.SetToolTip(this.topicDisplayLabel, "Click to change the chat topic. Press enter when done or Escape to cancel.");
            this.topicDisplayLabel.MouseLeave += new System.EventHandler(this.topicDisplayLabel_MouseLeave);
            this.topicDisplayLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topicDisplayLabel_MouseUp);
            this.topicDisplayLabel.MouseEnter += new System.EventHandler(this.topicDisplayLabel_MouseEnter);
            // 
            // setByLabel
            // 
            this.setByLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.setByLabel.Enabled = false;
            this.setByLabel.Location = new System.Drawing.Point(49, 25);
            this.setByLabel.Name = "setByLabel";
            this.setByLabel.Size = new System.Drawing.Size(385, 16);
            this.setByLabel.TabIndex = 3;
            // 
            // setByHeaderLabel
            // 
            this.setByHeaderLabel.AutoSize = true;
            this.setByHeaderLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setByHeaderLabel.Location = new System.Drawing.Point(3, 25);
            this.setByHeaderLabel.Name = "setByHeaderLabel";
            this.setByHeaderLabel.Size = new System.Drawing.Size(42, 13);
            this.setByHeaderLabel.TabIndex = 2;
            this.setByHeaderLabel.Text = "Set By:";
            // 
            // topicHeaderLabel
            // 
            this.topicHeaderLabel.AutoSize = true;
            this.topicHeaderLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topicHeaderLabel.Location = new System.Drawing.Point(3, 6);
            this.topicHeaderLabel.Name = "topicHeaderLabel";
            this.topicHeaderLabel.Size = new System.Drawing.Size(38, 13);
            this.topicHeaderLabel.TabIndex = 1;
            this.topicHeaderLabel.Text = "Topic:";
            // 
            // topicTextBox
            // 
            this.topicTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.topicTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.topicTextBox.Location = new System.Drawing.Point(49, 4);
            this.topicTextBox.Name = "topicTextBox";
            this.topicTextBox.Size = new System.Drawing.Size(384, 20);
            this.topicTextBox.TabIndex = 0;
            this.topicTextBox.Visible = false;
            this.topicTextBox.Leave += new System.EventHandler(this.topicTextBox_Leave);
            this.topicTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.topicTextBox_KeyUp);
            // 
            // chatInputTable
            // 
            this.chatInputTable.ColumnCount = 2;
            this.chatInputTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.13212F));
            this.chatInputTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.86788F));
            this.chatInputTable.Controls.Add(this.sendChatButton, 1, 0);
            this.chatInputTable.Controls.Add(this.chatInputTextBox, 0, 0);
            this.chatInputTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatInputTable.Location = new System.Drawing.Point(0, 0);
            this.chatInputTable.Name = "chatInputTable";
            this.chatInputTable.RowCount = 1;
            this.chatInputTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.chatInputTable.Size = new System.Drawing.Size(439, 25);
            this.chatInputTable.TabIndex = 11;
            // 
            // sendChatButton
            // 
            this.sendChatButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sendChatButton.Enabled = false;
            this.sendChatButton.Location = new System.Drawing.Point(347, 0);
            this.sendChatButton.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.sendChatButton.Name = "sendChatButton";
            this.sendChatButton.Size = new System.Drawing.Size(92, 25);
            this.sendChatButton.TabIndex = 9;
            this.sendChatButton.Text = "Send";
            this.sendChatButton.UseVisualStyleBackColor = true;
            this.sendChatButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sendChatButton_MouseUp);
            // 
            // chatInputTextBox
            // 
            this.chatInputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatInputTextBox.Enabled = false;
            this.chatInputTextBox.Location = new System.Drawing.Point(0, 1);
            this.chatInputTextBox.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.chatInputTextBox.Multiline = true;
            this.chatInputTextBox.Name = "chatInputTextBox";
            this.chatInputTextBox.Size = new System.Drawing.Size(342, 23);
            this.chatInputTextBox.TabIndex = 10;
            this.chatInputTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.chatInputTextBox_KeyUp);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chatSplitContainer);
            this.Name = "Chat";
            this.Size = new System.Drawing.Size(439, 258);
            this.chatSplitContainer.Panel1.ResumeLayout(false);
            this.chatSplitContainer.Panel2.ResumeLayout(false);
            this.chatSplitContainer.ResumeLayout(false);
            this.chatPanel.ResumeLayout(false);
            this.topicWrapperPanel.ResumeLayout(false);
            this.topicWrapperPanel.PerformLayout();
            this.chatInputTable.ResumeLayout(false);
            this.chatInputTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser chatWebBrowser;
        private System.Windows.Forms.SplitContainer chatSplitContainer;
        private System.Windows.Forms.Button sendChatButton;
        private System.Windows.Forms.Panel topicWrapperPanel;
        private System.Windows.Forms.Label topicHeaderLabel;
        private System.Windows.Forms.TextBox topicTextBox;
        private System.Windows.Forms.Label setByLabel;
        private System.Windows.Forms.Label setByHeaderLabel;
        private System.Windows.Forms.Label topicDisplayLabel;
        private System.Windows.Forms.ToolTip chatToolTip;
        private System.Windows.Forms.TextBox chatInputTextBox;
        private System.Windows.Forms.Panel chatPanel;
        private System.Windows.Forms.TableLayoutPanel chatInputTable;
    }
}
