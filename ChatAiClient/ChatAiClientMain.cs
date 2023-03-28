using ChatAiClient.Models;
using ChatAiClient.Properties;
using Newtonsoft.Json.Linq;
using NLog;
using NLog.Targets;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatAiClient
{
    /// <summary>
    /// ChatAiClientメイン画面
    /// </summary>
    public partial class ChatAiClientMain : Form
    {
        private static readonly int RetryCountMax = 3;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private static HttpClient _client;
        private static IModel _model;

        /// <summary>
        /// 画面状態
        /// </summary>
        public enum DisplayState
        {
            /// <summary>
            /// 初期表示
            /// </summary>
            Init,

            /// <summary>
            /// 成功
            /// </summary>
            Success,

            /// <summary>
            /// 送信中
            /// </summary>
            Submission,

            /// <summary>
            /// キャンセル
            /// </summary>
            Cancel,

            /// <summary>
            /// エラー
            /// </summary>
            Error
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ChatAiClientMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初期表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatAiClient_Load(object sender, EventArgs e)
        {
            try
            {
                // 画面状態制御(初期表示)
                ControlDisplayState(DisplayState.Init);

                // HTTPクライアントを初期化
                InitHttpClient();
            }
            catch (Exception ex)
            {
                // 例外処理
                HandlingException(ex);
            }
        }

        /// <summary>
        /// 設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemSettings_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings();
            if (formSettings.ShowDialog() == DialogResult.OK)
            {
                // HTTPクライアントを初期化
                InitHttpClient();
            }
        }

        /// <summary>
        /// ログファイルを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemOpenLogFile_Click(object sender, EventArgs e)
        {
            // ログファイルパスを取得
            var fileName = LogManager.Configuration.FindTargetByName<FileTarget>("logfile").FileName.Render(new LogEventInfo());
            // ファイルが存在しない場合
            if (!File.Exists(fileName))
            {
                MessageBox.Show(string.Format(Resources.ExistErrorMessage, $"ログファイル({fileName})"), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // ログファイルを開く
            Process.Start(fileName);
        }

        /// <summary>
        /// 終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ヘルプ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemHelp_Click(object sender, EventArgs e)
        {
            // ヘルプページを開く
            Process.Start(Settings.Default.HelpUrl);
        }

        /// <summary>
        /// 送信
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void toolStripButtonSubmit_Click(object sender, EventArgs e)
        {
            // 入力チェック(チャットモデルが選択されている場合)
            if (toolStripComboBoxModels.SelectedItem.ToString() == Resources.ModelChatDisplayName)
            {
                // 質問内容が未入力のため、処理終了
                if (string.IsNullOrEmpty(richTextBoxRequest.Text))
                {
                    return;
                }
            }
            // 音声モデルが選択されている場合
            else if (toolStripComboBoxModels.SelectedItem.ToString() == Resources.ModelAudioDisplayName)
            {
                // アップロードする音声ファイルパスを取得する
                using (var openFileDialog = new OpenFileDialog())
                {
                    // mp3, mp4, mpeg, mpga, m4a, wav, or webm
                    openFileDialog.Filter = "音声ファイル (*.mp3, *.mp4, *.mpeg, *.mpga, *.m4a, *.wav, *.webm)|*.mp3;*.mp4;*.mpeg;*.mpga;*.m4a;*.wav;*.webm";
                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    richTextBoxRequest.Text = openFileDialog.FileName;
                }
                // ファイルが存在しない場合
                if (!File.Exists(richTextBoxRequest.Text))
                {
                    // エラー処理
                    MessageBox.Show(string.Format(Resources.ExistErrorMessage, $"指定されたファイル({richTextBoxRequest.Text})"), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // モデルが選択されていない場合
            else
            {
                // エラー処理
                MessageBox.Show(string.Format(Resources.InputErrorMessage, toolStripComboBoxModels.ToolTipText), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ログ出力
            _logger.Info($"[Request]\r\n{richTextBoxRequest.Text}");

            // 画面状態制御(送信中)
            ControlDisplayState(DisplayState.Submission);

            // リクエストBody生成
            var httpContent = _model.GetRequestBody(richTextBoxRequest.Text);
            var response = new HttpResponseMessage();
            try
            {
                // ChatGPT API実行
                // エラーが発生した場合、再試行する
                for (int i = 0; i < RetryCountMax; i++)
                {
                    response = await _client.PostAsync($"{_model.UrlPass}", httpContent);
                    if (response.IsSuccessStatusCode)
                    {
                        // レスポンス処理
                        break;
                    }
                    else
                    {
                        var errorMessage = "Error: " + response.StatusCode;
                        Console.WriteLine(errorMessage);
                        // ログ出力
                        _logger.Error($"[Retry]\r\n{errorMessage}");
                    }
                }
                var responseContent = string.Empty;
                // API実行結果を確認
                // 成功の場合
                if (response.IsSuccessStatusCode)
                {
                    // 回答を表示
                    responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);

                    var json = JObject.Parse(responseContent);
                    var choices = json["choices"];
                    if (choices != null)
                    {
                        var message = choices[0]["message"];
                        if (message != null)
                        {
                            // 回答内容テキスト出力
                            var messageContent = message["content"].ToString();
                            var displayText = messageContent.Replace("\n", "\r\n");
                            Console.WriteLine(displayText);
                            // ログ出力
                            _logger.Info($"[Response]\r\n{displayText}");
                            richTextBoxResponseText.Text = displayText;
                            // 回答内容HTML出力
                            var displayHtml = messageContent.Replace("\r\n", "\n");
                            displayHtml = messageContent.Replace("\r\n", "\n");
                            displayHtml = messageContent.Replace("\n", "<br>\n");
                            // HTMLタグ以外のスペースを&nbsp;に置換する正規表現パターン
                            string pattern = @"(?!(<[^>]*\s))\s";
                            // 置換
                            string outputHtml = Regex.Replace(displayHtml, pattern, "&nbsp;");
                            string header = Resources.header_txt;
                            string res = $"<div id=\"response-list\">\n{outputHtml}\n</div>";
                            string footer = Resources.footer_txt;
                            webBrowserResponseHtml.DocumentText = $"{header}\n{res}\n{footer}";
                        }
                    }
                    // 画面状態制御(成功)
                    ControlDisplayState(DisplayState.Success);
                }
                // 失敗の場合
                else
                {
                    var errorMessage = "Error: " + response.StatusCode;
                    // エラーメッセージを表示
                    toolStripStatusLabel.Text = errorMessage;
                    Console.WriteLine(errorMessage);
                    // エラーメッセージをログ出力
                    _logger.Error($"[Error]\r\n{errorMessage}");
                    // 画面状態制御(エラー)
                    ControlDisplayState(DisplayState.Error);
                }
            }
            catch (TaskCanceledException)
            {
                // 画面状態制御(キャンセル)
                ControlDisplayState(DisplayState.Cancel);
            }
            catch (Exception ex)
            {
                // 例外処理
                HandlingException(ex);
            }
        }

        /// <summary>
        /// キャンセル
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            // キャンセル処理
            _client.CancelPendingRequests();
        }

        /// <summary>
        /// 画面KeyDownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatAiClient_KeyDown(object sender, KeyEventArgs e)
        {
            // ショートカットキーが押されていない場合
            if (!PressedShortcutKey(e))
            {
                // 処理終了
                return;
            }

            // 送信
            if (e.KeyData == (Keys.Control | Keys.Enter))
            {
                toolStripButtonSubmit_Click(sender, e);
            }
            // キャンセル
            if (e.KeyData == Keys.Escape)
            {
                toolStripButtonCancel_Click(sender, e);
            }
        }

        /// <summary>
        /// 質問内容テキストボックスKeyDownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxRequest_KeyDown(object sender, KeyEventArgs e)
        {
            // ショートカットキーが押された場合はキャンセル
            if (PressedShortcutKey(e))
            {
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// 回答内容テキストボックスKeyDownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxResponseText_KeyDown(object sender, KeyEventArgs e)
        {
            // ショートカットキーが押された場合はキャンセル
            if (PressedShortcutKey(e))
            {
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// モデル変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBoxModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            // モデルを設定する
            SetModel(toolStripComboBoxModels.SelectedItem.ToString());
        }

        /// <summary>
        /// 画面状態制御
        /// </summary>
        /// <param name="displayState"></param>
        private void ControlDisplayState(DisplayState displayState)
        {
            // アプリのウィンドウを最前面に表示する
            this.TopMost = true;
            switch (displayState)
            {
                case DisplayState.Init:
                    // 初期表示
                    toolStripComboBoxModels.Items.Add(Resources.ModelChatDisplayName);
                    toolStripComboBoxModels.Items.Add(Resources.ModelAudioDisplayName);
                    toolStripComboBoxModels.SelectedItem = Resources.ModelChatDisplayName;
                    toolStripComboBoxModels.Enabled = true;
                    toolStripButtonSubmit.Enabled = true;
                    toolStripButtonCancel.Enabled = false;
                    toolStripStatusLabel.Text = Resources.NavigationMessageInit;
                    richTextBoxRequest.Text = string.Empty;
                    richTextBoxResponseText.Text = string.Empty;
                    webBrowserResponseHtml.DocumentText = string.Empty;
                    webBrowserResponseHtml.AllowNavigation = true;
                    webBrowserResponseHtml.ScriptErrorsSuppressed = true;
                    break;
                case DisplayState.Success:
                    // 成功
                    toolStripComboBoxModels.Enabled = true;
                    toolStripButtonSubmit.Enabled = true;
                    toolStripButtonCancel.Enabled = false;
                    toolStripStatusLabel.Text = Resources.NavigationMessageSuccess;
                    // ダイアログ表示
                    MessageBox.Show(toolStripStatusLabel.Text, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case DisplayState.Submission:
                    // 送信中
                    toolStripComboBoxModels.Enabled = false;
                    toolStripButtonSubmit.Enabled = false;
                    toolStripButtonCancel.Enabled = true;
                    toolStripStatusLabel.Text = Resources.NavigationMessageSubmission;
                    richTextBoxResponseText.Text = string.Empty;
                    webBrowserResponseHtml.DocumentText = string.Empty;
                    break;
                case DisplayState.Cancel:
                    // キャンセル
                    toolStripComboBoxModels.Enabled = true;
                    toolStripButtonSubmit.Enabled = true;
                    toolStripButtonCancel.Enabled = false;
                    toolStripStatusLabel.Text = Resources.NavigationMessageCancel;
                    break;
                case DisplayState.Error:
                    // エラー
                    toolStripComboBoxModels.Enabled = true;
                    toolStripButtonSubmit.Enabled = true;
                    toolStripButtonCancel.Enabled = false;
                    toolStripStatusLabel.Text = Resources.NavigationMessageError;
                    // ダイアログ表示
                    MessageBox.Show(toolStripStatusLabel.Text, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            // ウィンドウを最前面から解除する
            this.TopMost = false;
        }

        /// <summary>
        /// ショートカットキー押下判定
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool PressedShortcutKey(KeyEventArgs e)
        {
            bool pressedShortcutKey = false;

            // 送信
            if (e.KeyData == (Keys.Control | Keys.Enter))
            {
                pressedShortcutKey = true;
            }
            // キャンセル
            if (e.KeyData == Keys.Escape)
            {
                pressedShortcutKey = true;
            }

            return pressedShortcutKey;
        }

        /// <summary>
        /// HTTPクライアント初期化
        /// </summary>
        private void InitHttpClient()
        {
            // TLSを使用するようにServicePointManagerを設定する
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            if (_client != null)
            {
                _client.Dispose();
            }
            _client = new HttpClient();
            _client.BaseAddress = new Uri(Settings.Default.ApiUrl);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Default.ApiKey);
            _client.Timeout = TimeSpan.FromSeconds(180);
        }

        /// <summary>
        /// モデルを設定する
        /// </summary>
        /// <param name="displayName">表示名称</param>
        private void SetModel(string displayName)
        {
            // モデルを初期化
            if (_model != null)
            {
                _model = null;
            }
            // 「音声」の場合
            if (displayName == Resources.ModelAudioDisplayName)
            {
                _model = new AudioModel();
            }
            // それ以外の場合(デフォルト)
            else
            {
                _model = new ChatModel();
            }
        }

        /// <summary>
        /// 例外処理
        /// </summary>
        /// <param name="ex"></param>
        private void HandlingException(Exception ex)
        {
            // エラーメッセージを表示
            toolStripStatusLabel.Text = Resources.NavigationMessageException;
            Console.WriteLine(ex.ToString());
            // ログ出力
            _logger.Info($"[Exception]\r\n{ex.ToString()}");
            // 画面状態制御(エラー)
            ControlDisplayState(DisplayState.Error);
        }
    }
}
