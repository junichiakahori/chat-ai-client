using ChatAiClient.Properties;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ChatAiClient
{
    /// <summary>
    /// 設定画面
    /// </summary>
    public partial class FormSettings : Form
    {
        private static readonly char PasswordChar = '*';
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初期表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSettings_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        /// <summary>
        /// キャンセル
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // 入力チェック
            if (string.IsNullOrEmpty(textBoxApiUrl.Text))
            {
                MessageBox.Show(string.Format(Resources.InputErrorMessage, labelUrl.Text), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxApiUrl.BackColor = System.Drawing.Color.Red;
                textBoxApiUrl.Focus();
                return;
            }
            Settings.Default.ApiKey = textBoxApiKey.Text;
            Settings.Default.ApiUrl = textBoxApiUrl.Text;
            Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 設定値取得
        /// </summary>
        private void LoadSettings()
        {
            textBoxApiKey.PasswordChar = PasswordChar;
            textBoxApiKey.Text = Settings.Default.ApiKey;
            checkBoxShowApiKey.Checked = false;
            // APIのURLが未設定の場合、デフォルトのURLを表示する
            if (string.IsNullOrEmpty(Settings.Default.ApiUrl))
            {
                textBoxApiUrl.Text = Settings.Default.ApiUrlDefault;
            }
            else
            {
                textBoxApiUrl.Text = Settings.Default.ApiUrl;
            }
            linkLabelApiKeys.Text = Settings.Default.ApiKeysUrl;
        }

        /// <summary>
        /// APIキー表示変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxShowApiKey_CheckedChanged(object sender, EventArgs e)
        {
            if (textBoxApiKey.PasswordChar == PasswordChar)
            {
                textBoxApiKey.PasswordChar = '\0';
                checkBoxShowApiKey.Text = "隠す";
            }
            else
            {
                textBoxApiKey.PasswordChar = PasswordChar;
                checkBoxShowApiKey.Text = "表示";
            }
        }

        /// <summary>
        /// APIキーURLクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabelApiKeys_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // APIKeysページを開く
            Process.Start(Settings.Default.ApiKeysUrl);
        }
    }
}
