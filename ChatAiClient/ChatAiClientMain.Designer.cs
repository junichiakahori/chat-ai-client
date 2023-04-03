namespace ChatAiClient
{
    partial class ChatAiClientMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatAiClientMain));
            this.webBrowserResponseHtml = new System.Windows.Forms.WebBrowser();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenLogFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxRequest = new System.Windows.Forms.GroupBox();
            this.richTextBoxRequest = new System.Windows.Forms.RichTextBox();
            this.groupBoxResponse = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageHtml = new System.Windows.Forms.TabPage();
            this.tabPageText = new System.Windows.Forms.TabPage();
            this.richTextBoxResponseText = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSubmit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBoxModels = new System.Windows.Forms.ToolStripComboBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBoxRequest.SuspendLayout();
            this.groupBoxResponse.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageHtml.SuspendLayout();
            this.tabPageText.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowserResponseHtml
            // 
            this.webBrowserResponseHtml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserResponseHtml.Location = new System.Drawing.Point(9, 6);
            this.webBrowserResponseHtml.Name = "webBrowserResponseHtml";
            this.webBrowserResponseHtml.Size = new System.Drawing.Size(530, 109);
            this.webBrowserResponseHtml.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItemSettings,
            this.toolStripMenuItemHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpenLogFile,
            this.toolStripMenuItemClose});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(70, 20);
            this.toolStripMenuItem2.Text = "ファイル (&F)";
            // 
            // toolStripMenuItemOpenLogFile
            // 
            this.toolStripMenuItemOpenLogFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemOpenLogFile.Image")));
            this.toolStripMenuItemOpenLogFile.Name = "toolStripMenuItemOpenLogFile";
            this.toolStripMenuItemOpenLogFile.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItemOpenLogFile.Text = "ログファイルを開く (&L)";
            this.toolStripMenuItemOpenLogFile.Click += new System.EventHandler(this.toolStripMenuItemOpenLogFile_Click);
            // 
            // toolStripMenuItemClose
            // 
            this.toolStripMenuItemClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemClose.Image")));
            this.toolStripMenuItemClose.Name = "toolStripMenuItemClose";
            this.toolStripMenuItemClose.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItemClose.Text = "終了 (&X)";
            this.toolStripMenuItemClose.Click += new System.EventHandler(this.toolStripMenuItemClose_Click);
            // 
            // toolStripMenuItemSettings
            // 
            this.toolStripMenuItemSettings.Name = "toolStripMenuItemSettings";
            this.toolStripMenuItemSettings.Size = new System.Drawing.Size(63, 20);
            this.toolStripMenuItemSettings.Text = "設定 (&O)";
            this.toolStripMenuItemSettings.Click += new System.EventHandler(this.toolStripMenuItemSettings_Click);
            // 
            // toolStripMenuItemHelp
            // 
            this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
            this.toolStripMenuItemHelp.Size = new System.Drawing.Size(68, 20);
            this.toolStripMenuItemHelp.Text = "ヘルプ (&H)";
            this.toolStripMenuItemHelp.Click += new System.EventHandler(this.toolStripMenuItemHelp_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 339);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(584, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabel.Text = "説明";
            // 
            // groupBoxRequest
            // 
            this.groupBoxRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxRequest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxRequest.Controls.Add(this.richTextBoxRequest);
            this.groupBoxRequest.Location = new System.Drawing.Point(12, 3);
            this.groupBoxRequest.Name = "groupBoxRequest";
            this.groupBoxRequest.Size = new System.Drawing.Size(560, 96);
            this.groupBoxRequest.TabIndex = 0;
            this.groupBoxRequest.TabStop = false;
            this.groupBoxRequest.Text = "依頼";
            // 
            // richTextBoxRequest
            // 
            this.richTextBoxRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxRequest.Location = new System.Drawing.Point(13, 18);
            this.richTextBoxRequest.Name = "richTextBoxRequest";
            this.richTextBoxRequest.Size = new System.Drawing.Size(537, 72);
            this.richTextBoxRequest.TabIndex = 1;
            this.richTextBoxRequest.Text = "";
            this.richTextBoxRequest.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRequest_KeyDown);
            // 
            // groupBoxResponse
            // 
            this.groupBoxResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxResponse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxResponse.Controls.Add(this.tabControl1);
            this.groupBoxResponse.Location = new System.Drawing.Point(12, 3);
            this.groupBoxResponse.Name = "groupBoxResponse";
            this.groupBoxResponse.Size = new System.Drawing.Size(560, 172);
            this.groupBoxResponse.TabIndex = 0;
            this.groupBoxResponse.TabStop = false;
            this.groupBoxResponse.Text = "回答";
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageHtml);
            this.tabControl1.Controls.Add(this.tabPageText);
            this.tabControl1.Location = new System.Drawing.Point(0, 18);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(554, 148);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageHtml
            // 
            this.tabPageHtml.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageHtml.Controls.Add(this.webBrowserResponseHtml);
            this.tabPageHtml.Location = new System.Drawing.Point(4, 4);
            this.tabPageHtml.Name = "tabPageHtml";
            this.tabPageHtml.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHtml.Size = new System.Drawing.Size(546, 122);
            this.tabPageHtml.TabIndex = 0;
            this.tabPageHtml.Text = "HTML";
            // 
            // tabPageText
            // 
            this.tabPageText.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageText.Controls.Add(this.richTextBoxResponseText);
            this.tabPageText.Location = new System.Drawing.Point(4, 4);
            this.tabPageText.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageText.Name = "tabPageText";
            this.tabPageText.Size = new System.Drawing.Size(546, 122);
            this.tabPageText.TabIndex = 1;
            this.tabPageText.Text = "テキスト";
            // 
            // richTextBoxResponseText
            // 
            this.richTextBoxResponseText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxResponseText.Location = new System.Drawing.Point(9, 3);
            this.richTextBoxResponseText.Name = "richTextBoxResponseText";
            this.richTextBoxResponseText.Size = new System.Drawing.Size(537, 116);
            this.richTextBoxResponseText.TabIndex = 2;
            this.richTextBoxResponseText.Text = "";
            this.richTextBoxResponseText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRequest_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSubmit,
            this.toolStripButtonCancel,
            this.toolStripComboBoxModels});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(584, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSubmit
            // 
            this.toolStripButtonSubmit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSubmit.Image")));
            this.toolStripButtonSubmit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSubmit.Name = "toolStripButtonSubmit";
            this.toolStripButtonSubmit.Size = new System.Drawing.Size(51, 22);
            this.toolStripButtonSubmit.Text = "送信";
            this.toolStripButtonSubmit.ToolTipText = "送信 (Ctrl + Enter)";
            this.toolStripButtonSubmit.Click += new System.EventHandler(this.toolStripButtonSubmit_Click);
            // 
            // toolStripButtonCancel
            // 
            this.toolStripButtonCancel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCancel.Image")));
            this.toolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCancel.Name = "toolStripButtonCancel";
            this.toolStripButtonCancel.Size = new System.Drawing.Size(73, 22);
            this.toolStripButtonCancel.Text = "キャンセル";
            this.toolStripButtonCancel.ToolTipText = "キャンセル (Esc)";
            this.toolStripButtonCancel.Click += new System.EventHandler(this.toolStripButtonCancel_Click);
            // 
            // toolStripComboBoxModels
            // 
            this.toolStripComboBoxModels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxModels.Name = "toolStripComboBoxModels";
            this.toolStripComboBoxModels.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBoxModels.ToolTipText = "使用するモデル";
            this.toolStripComboBoxModels.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxModels_SelectedIndexChanged);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(0, 52);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.groupBoxRequest);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.groupBoxResponse);
            this.splitContainer.Size = new System.Drawing.Size(584, 284);
            this.splitContainer.SplitterDistance = 102;
            this.splitContainer.TabIndex = 2;
            // 
            // ChatAiClientMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "ChatAiClientMain";
            this.Text = "ChatAiClient";
            this.Load += new System.EventHandler(this.ChatAiClient_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChatAiClient_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBoxRequest.ResumeLayout(false);
            this.groupBoxResponse.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageHtml.ResumeLayout(false);
            this.tabPageText.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.WebBrowser webBrowserResponseHtml;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSettings;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.GroupBox groupBoxRequest;
        private System.Windows.Forms.GroupBox groupBoxResponse;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSubmit;
        private System.Windows.Forms.ToolStripButton toolStripButtonCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageHtml;
        private System.Windows.Forms.TabPage tabPageText;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenLogFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClose;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxModels;
        private System.Windows.Forms.RichTextBox richTextBoxRequest;
        private System.Windows.Forms.RichTextBox richTextBoxResponseText;
    }
}

