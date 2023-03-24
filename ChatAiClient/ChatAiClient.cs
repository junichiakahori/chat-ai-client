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
using NLog.Targets;
using System.Diagnostics;
using System.Net;

namespace ChatAiClient
{
    /// <summary>
    /// ChatAiClientメイン画面
    /// </summary>
    public partial class ChatAiClient : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private static HttpClient _client;

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
            /// 通常
            /// </summary>
            Normal,

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
        public ChatAiClient()
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
                Console.WriteLine(ex);
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
            formSettings.ShowDialog();

            // HTTPクライアントを初期化
            InitHttpClient();
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
            // ログファイルを開く
            System.Diagnostics.Process.Start(fileName);
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
            // ログ出力
            logger.Info(textBoxRequest.Text);

            // 画面状態制御(送信中)
            ControlDisplayState(DisplayState.Submission);

            // JSONデータを作成
            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new
                    {
                        role = "user",
                        content = textBoxRequest.Text
                    }
                }
            };
            var requestBodyJson = JsonConvert.SerializeObject(requestBody);
            var httpContent = new StringContent(string.Empty);
            var response = new HttpResponseMessage();
            try
            {
                // ChatGPT API実行
                // 最大3回まで再試行する
                int retryCount = 3;
                while (retryCount > 0)
                {
                    httpContent = new StringContent(requestBodyJson, Encoding.UTF8, "application/json");
                    response = await _client.PostAsync($"v1/chat/completions", httpContent);
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
                        logger.Error(errorMessage);
                        // エラー処理
                        retryCount--;
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
                            var messageContent = message["content"].ToString();
                            var displayText = messageContent.Replace("\n", "\r\n");
                            Console.WriteLine(displayText);
                            // ログ出力
                            logger.Info(displayText);
                            textBoxResponseText.Text = displayText;
                            webBrowserResponseHtml.DocumentText = "<meta http-equiv=\"X-UA-Compatible>\" content=\"IE=edge, chrome=1\">";
                            webBrowserResponseHtml.DocumentText += displayText.Replace(" ", "&nbsp;").Replace("\r\n", "<br />");
                        }
                    }
                    // 画面状態制御(通常)
                    ControlDisplayState(DisplayState.Normal);
                }
                // 失敗の場合
                else
                {
                    var errorMessage = "Error: " + response.StatusCode;
                    // エラーメッセージを表示
                    toolStripStatusLabel.Text = errorMessage;

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
                // エラーメッセージを表示
                toolStripStatusLabel.Text = Settings.Default.NavigationMessageException;
                Console.WriteLine(ex.ToString());
                // ログ出力
                logger.Error(ex.ToString());
                // 画面状態制御(エラー)
                ControlDisplayState(DisplayState.Error);
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
        /// 画面状態制御
        /// </summary>
        /// <param name="displayState"></param>
        private void ControlDisplayState(DisplayState displayState)
        {
            switch (displayState)
            {
                case DisplayState.Init:
                    // 初期表示
                    toolStripButtonSubmit.Enabled = true;
                    toolStripButtonCancel.Enabled = false;
                    toolStripStatusLabel.Text = Settings.Default.NavigationMessageInit;
                    textBoxRequest.Text = string.Empty;
                    textBoxResponseText.Text = string.Empty;
                    webBrowserResponseHtml.DocumentText = string.Empty;
                    break;
                case DisplayState.Normal:
                    // 通常
                    toolStripButtonSubmit.Enabled = true;
                    toolStripButtonCancel.Enabled = false;
                    toolStripStatusLabel.Text = Settings.Default.NavigationMessageNormal;
                    break;
                case DisplayState.Submission:
                    // 送信中
                    toolStripButtonSubmit.Enabled = false;
                    toolStripButtonCancel.Enabled = true;
                    toolStripStatusLabel.Text = Settings.Default.NavigationMessageSubmission;
                    textBoxResponseText.Text = string.Empty;
                    webBrowserResponseHtml.DocumentText = string.Empty;
                    break;
                case DisplayState.Cancel:
                    // キャンセル    
                    toolStripButtonSubmit.Enabled = true;
                    toolStripButtonCancel.Enabled = false;
                    toolStripStatusLabel.Text = Settings.Default.NavigationMessageCancel;
                    break;
                case DisplayState.Error:
                    // エラー
                    toolStripButtonSubmit.Enabled = true;
                    toolStripButtonCancel.Enabled = false;
                    toolStripStatusLabel.Text = Settings.Default.NavigationMessageError;
                    break;
            }
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

            if (_client != null)
            {
                _client.Dispose();
            }
            _client = new HttpClient();
            _client.BaseAddress = new Uri(Settings.Default.ApiUrl);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Default.ApiKey);
            _client.Timeout = TimeSpan.FromSeconds(180);
        }
    }
}
