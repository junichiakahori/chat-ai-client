using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using ChatAiClient.Properties;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;

namespace ChatAiClient
{
    /// <summary>
    /// 設定画面
    /// </summary>
    public partial class FormSettings : Form
    {
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
            Settings.Default.ApiKey = textBoxApiKey.Text;
            Settings.Default.ApiUrl = textBoxApiUrl.Text;
            Settings.Default.ApiUrlPass = textBoxApiUrlPass.Text;
            Settings.Default.Save();
            this.Close();
        }

        /// <summary>
        /// 設定値取得
        /// </summary>
        private void LoadSettings()
        {
            textBoxApiKey.PasswordChar = '●';
            textBoxApiKey.Text = Settings.Default.ApiKey;
            checkBoxShowApiKey.Checked = false;
            textBoxApiUrl.Text = Settings.Default.ApiUrl;
            textBoxApiUrlPass.Text = Settings.Default.ApiUrlPass;
            linkLabelApiKeys.Text = Settings.Default.ApiKeysUrl;
        }

        /// <summary>
        /// APIキー表示変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxShowApiKey_CheckedChanged(object sender, EventArgs e)
        {
            if (textBoxApiKey.PasswordChar == '●')
            {
                textBoxApiKey.PasswordChar = '\0';
                checkBoxShowApiKey.Text = "隠す";
            }
            else
            {
                textBoxApiKey.PasswordChar = '●';
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
