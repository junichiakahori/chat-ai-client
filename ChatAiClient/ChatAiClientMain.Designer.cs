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
            this.textBoxRequest = new System.Windows.Forms.TextBox();
            this.textBoxResponseText = new System.Windows.Forms.TextBox();
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
            this.groupBoxResponse = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageHtml = new System.Windows.Forms.TabPage();
            this.tabPageText = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSubmit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBoxRequest.SuspendLayout();
            this.groupBoxResponse.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageHtml.SuspendLayout();
            this.tabPageText.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxRequest
            // 
            this.textBoxRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRequest.Location = new System.Drawing.Point(13, 20);
            this.textBoxRequest.Multiline = true;
            this.textBoxRequest.Name = "textBoxRequest";
            this.textBoxRequest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxRequest.Size = new System.Drawing.Size(518, 94);
            this.textBoxRequest.TabIndex = 0;
            this.textBoxRequest.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRequest_KeyDown);
            // 
            // textBoxResponseText
            // 
            this.textBoxResponseText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResponseText.Location = new System.Drawing.Point(9, 5);
            this.textBoxResponseText.Multiline = true;
            this.textBoxResponseText.Name = "textBoxResponseText";
            this.textBoxResponseText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxResponseText.Size = new System.Drawing.Size(519, 149);
            this.textBoxResponseText.TabIndex = 2;
            this.textBoxResponseText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxResponseText_KeyDown);
            // 
            // webBrowserResponseHtml
            // 
            this.webBrowserResponseHtml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserResponseHtml.Location = new System.Drawing.Point(9, 6);
            this.webBrowserResponseHtml.Name = "webBrowserResponseHtml";
            this.webBrowserResponseHtml.Size = new System.Drawing.Size(518, 147);
            this.webBrowserResponseHtml.TabIndex = 0;
            this.webBrowserResponseHtml.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserResponseHtml_DocumentCompleted);
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
            this.statusStrip.Location = new System.Drawing.Point(0, 393);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(584, 22);
            this.statusStrip.TabIndex = 4;
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
            this.groupBoxRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxRequest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxRequest.Controls.Add(this.textBoxRequest);
            this.groupBoxRequest.Location = new System.Drawing.Point(12, 52);
            this.groupBoxRequest.Name = "groupBoxRequest";
            this.groupBoxRequest.Size = new System.Drawing.Size(548, 120);
            this.groupBoxRequest.TabIndex = 2;
            this.groupBoxRequest.TabStop = false;
            this.groupBoxRequest.Text = "質問";
            // 
            // groupBoxResponse
            // 
            this.groupBoxResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxResponse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxResponse.Controls.Add(this.tabControl1);
            this.groupBoxResponse.Location = new System.Drawing.Point(12, 178);
            this.groupBoxResponse.Name = "groupBoxResponse";
            this.groupBoxResponse.Size = new System.Drawing.Size(548, 212);
            this.groupBoxResponse.TabIndex = 3;
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
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(542, 186);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageHtml
            // 
            this.tabPageHtml.Controls.Add(this.webBrowserResponseHtml);
            this.tabPageHtml.Location = new System.Drawing.Point(4, 4);
            this.tabPageHtml.Name = "tabPageHtml";
            this.tabPageHtml.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHtml.Size = new System.Drawing.Size(534, 160);
            this.tabPageHtml.TabIndex = 0;
            this.tabPageHtml.Text = "HTML";
            this.tabPageHtml.UseVisualStyleBackColor = true;
            // 
            // tabPageText
            // 
            this.tabPageText.Controls.Add(this.textBoxResponseText);
            this.tabPageText.Location = new System.Drawing.Point(4, 4);
            this.tabPageText.Name = "tabPageText";
            this.tabPageText.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageText.Size = new System.Drawing.Size(534, 160);
            this.tabPageText.TabIndex = 1;
            this.tabPageText.Text = "テキスト";
            this.tabPageText.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSubmit,
            this.toolStripButtonCancel});
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
            // ChatAiClientMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(584, 415);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBoxResponse);
            this.Controls.Add(this.groupBoxRequest);
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
            this.groupBoxRequest.PerformLayout();
            this.groupBoxResponse.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageHtml.ResumeLayout(false);
            this.tabPageText.ResumeLayout(false);
            this.tabPageText.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxRequest;
        private System.Windows.Forms.TextBox textBoxResponseText;
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
    }
}

