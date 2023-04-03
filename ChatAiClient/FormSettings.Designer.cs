namespace ChatAiClient
{
    partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelApiKey = new System.Windows.Forms.Label();
            this.labelApiUrl = new System.Windows.Forms.Label();
            this.textBoxApiKey = new System.Windows.Forms.TextBox();
            this.textBoxApiUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabelApiKeys = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxShowApiKey = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelChunkSize = new System.Windows.Forms.Label();
            this.numericUpDownChunkSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChunkSize)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(396, 236);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(477, 236);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelApiKey
            // 
            this.labelApiKey.AutoSize = true;
            this.labelApiKey.Location = new System.Drawing.Point(15, 23);
            this.labelApiKey.Name = "labelApiKey";
            this.labelApiKey.Size = new System.Drawing.Size(71, 12);
            this.labelApiKey.TabIndex = 0;
            this.labelApiKey.Text = "API キー (*1)";
            // 
            // labelApiUrl
            // 
            this.labelApiUrl.AutoSize = true;
            this.labelApiUrl.Location = new System.Drawing.Point(15, 53);
            this.labelApiUrl.Name = "labelApiUrl";
            this.labelApiUrl.Size = new System.Drawing.Size(85, 12);
            this.labelApiUrl.TabIndex = 3;
            this.labelApiUrl.Text = "API URL (必須)";
            // 
            // textBoxApiKey
            // 
            this.textBoxApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxApiKey.Location = new System.Drawing.Point(117, 20);
            this.textBoxApiKey.Name = "textBoxApiKey";
            this.textBoxApiKey.Size = new System.Drawing.Size(342, 19);
            this.textBoxApiKey.TabIndex = 1;
            // 
            // textBoxApiUrl
            // 
            this.textBoxApiUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxApiUrl.Location = new System.Drawing.Point(117, 50);
            this.textBoxApiUrl.Name = "textBoxApiUrl";
            this.textBoxApiUrl.Size = new System.Drawing.Size(402, 19);
            this.textBoxApiUrl.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "API キーは 下記URLより取得できます。";
            // 
            // linkLabelApiKeys
            // 
            this.linkLabelApiKeys.AutoSize = true;
            this.linkLabelApiKeys.Location = new System.Drawing.Point(15, 46);
            this.linkLabelApiKeys.Name = "linkLabelApiKeys";
            this.linkLabelApiKeys.Size = new System.Drawing.Size(246, 12);
            this.linkLabelApiKeys.TabIndex = 1;
            this.linkLabelApiKeys.TabStop = true;
            this.linkLabelApiKeys.Text = "https://platform.openai.com/account/api-keys ";
            this.linkLabelApiKeys.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelApiKeys_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.numericUpDownChunkSize);
            this.groupBox1.Controls.Add(this.checkBoxShowApiKey);
            this.groupBox1.Controls.Add(this.labelApiKey);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelChunkSize);
            this.groupBox1.Controls.Add(this.labelApiUrl);
            this.groupBox1.Controls.Add(this.textBoxApiKey);
            this.groupBox1.Controls.Add(this.textBoxApiUrl);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "設定値";
            // 
            // checkBoxShowApiKey
            // 
            this.checkBoxShowApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxShowApiKey.AutoSize = true;
            this.checkBoxShowApiKey.Location = new System.Drawing.Point(471, 22);
            this.checkBoxShowApiKey.Name = "checkBoxShowApiKey";
            this.checkBoxShowApiKey.Size = new System.Drawing.Size(48, 16);
            this.checkBoxShowApiKey.TabIndex = 2;
            this.checkBoxShowApiKey.Text = "表示";
            this.checkBoxShowApiKey.UseVisualStyleBackColor = true;
            this.checkBoxShowApiKey.CheckedChanged += new System.EventHandler(this.checkBoxShowApiKey_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.linkLabelApiKeys);
            this.groupBox2.Location = new System.Drawing.Point(12, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 75);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "*1";
            // 
            // labelChunkSize
            // 
            this.labelChunkSize.AutoSize = true;
            this.labelChunkSize.Location = new System.Drawing.Point(15, 83);
            this.labelChunkSize.Name = "labelChunkSize";
            this.labelChunkSize.Size = new System.Drawing.Size(68, 12);
            this.labelChunkSize.TabIndex = 5;
            this.labelChunkSize.Text = "チャンクサイズ";
            // 
            // numericUpDownChunkSize
            // 
            this.numericUpDownChunkSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownChunkSize.DecimalPlaces = 1;
            this.numericUpDownChunkSize.Location = new System.Drawing.Point(117, 80);
            this.numericUpDownChunkSize.Name = "numericUpDownChunkSize";
            this.numericUpDownChunkSize.Size = new System.Drawing.Size(63, 19);
            this.numericUpDownChunkSize.TabIndex = 6;
            this.numericUpDownChunkSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "MB";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(564, 271);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(580, 240);
            this.Name = "FormSettings";
            this.Text = "設定";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChunkSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelApiKey;
        private System.Windows.Forms.Label labelApiUrl;
        private System.Windows.Forms.TextBox textBoxApiKey;
        private System.Windows.Forms.TextBox textBoxApiUrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabelApiKeys;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxShowApiKey;
        private System.Windows.Forms.NumericUpDown numericUpDownChunkSize;
        private System.Windows.Forms.Label labelChunkSize;
        private System.Windows.Forms.Label label1;
    }
}