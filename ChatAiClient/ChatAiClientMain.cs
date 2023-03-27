using System;
using System.Text;
using System.Text.RegularExpressions;
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
using MarkdownSharp;
using System.IO;
using mshtml;

namespace ChatAiClient
{
    /// <summary>
    /// ChatAiClientメイン画面
    /// </summary>
    public partial class ChatAiClientMain : Form
    {
        private static readonly int RetryCountMax = 3;
        private static readonly int ContinueCountMax = 10;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
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
            // 入力チェック
            if (string.IsNullOrEmpty(textBoxRequest.Text))
            {
                return;
            }

            // ログ出力
            _logger.Info($"[Request]\r\n{textBoxRequest.Text}");

            // 画面状態制御(送信中)
            ControlDisplayState(DisplayState.Submission);

            // リクエストBody生成
            var requestBodyJson = CreateRequestBodyJson(textBoxRequest.Text);
            var httpContent = new StringContent(string.Empty);
            var response = new HttpResponseMessage();
            try
            {
                // ChatGPT API実行
                // エラーが発生した場合、再試行する
                int retryCount = 0;
                for (int i = 0; i < ContinueCountMax; i++)
                {
                    httpContent = new StringContent(requestBodyJson, Encoding.UTF8, "application/json");
                    response = await _client.PostAsync($"{Settings.Default.ApiUrlPass}", httpContent);
                    if (response.IsSuccessStatusCode)
                    {
                        // レスポンス処理
                        break;
                    }
                    else if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        // 途中で止まった場合は続きをリクエスト
                        // リクエストBody生成
                        requestBodyJson = CreateRequestBodyJson(Settings.Default.RequestContinueText);
                        // ログ出力
                        _logger.Error($"[Continue]\r\n{Settings.Default.RequestContinueText}");
                    }
                    else
                    {
                        var errorMessage = "Error: " + response.StatusCode;
                        Console.WriteLine(errorMessage);
                        // ログ出力
                        _logger.Error($"[Retry]\r\n{errorMessage}");
                        // 再試行
                        retryCount++;
                        if (retryCount >= RetryCountMax)
                        {
                            break;
                        }
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
                            textBoxResponseText.Text = displayText;
                            // 回答内容HTML出力
                            var displayHtml = messageContent.Replace("\r\n", "\n");
                            displayHtml = messageContent.Replace("\r\n", "\n");
                            displayHtml = messageContent.Replace("\n", "<br>\n");
                            // HTMLタグ以外のスペースを&nbsp;に置換する正規表現パターン
                            string pattern = @"(?!(<[^>]*\s))\s";
                            // 置換
                            string outputHtml = Regex.Replace(displayHtml, pattern, "&nbsp;");
                            //var markdown = new Markdown();
                            //markdown.AutoNewLines = true;
                            //markdown.EmptyElementSuffix = ">";
                            //displayHtml = markdown.Transform(displayHtml);
                            string header = Resources.header_txt;
                            string res = $"<div id=\"response-list\">\n{outputHtml}\n</div>";
                            //string js1 = Resources.index_js;
                            //string js2 = Resources.highlight_min_js;
                            //string js3 = Resources.showdown_min_js;
                            //string js = $"<script>\n{js1}\n{js2}\n{js3}\n</script>";
                            string footer = Resources.footer_txt;
                            //webBrowserResponseHtml.DocumentText = $"{header}\n{res}\n{js}\n{footer}";
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
        /// 回答内容HTMLの読み込み完了時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowserResponseHtml_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                // CSS読み込み
                //LoadCss();
            }
            catch (Exception ex)
            {
                // 例外処理
                HandlingException(ex);
            }
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
                    toolStripButtonSubmit.Enabled = true;
                    toolStripButtonCancel.Enabled = false;
                    toolStripStatusLabel.Text = Settings.Default.NavigationMessageInit;
                    textBoxRequest.Text = string.Empty;
                    textBoxResponseText.Text = string.Empty;
                    webBrowserResponseHtml.DocumentText = string.Empty;
                    webBrowserResponseHtml.AllowNavigation = true;
                    webBrowserResponseHtml.ScriptErrorsSuppressed = true;
                    break;
                case DisplayState.Success:
                    // 成功
                    toolStripButtonSubmit.Enabled = true;
                    toolStripButtonCancel.Enabled = false;
                    toolStripStatusLabel.Text = Settings.Default.NavigationMessageNormal;
                    // ダイアログ表示
                    MessageBox.Show(toolStripStatusLabel.Text, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// リクエストBody生成
        /// </summary>
        /// <param name="content">リクエスト内容</param>
        /// <returns></returns>
        private string CreateRequestBodyJson(string content)
        {
            // JSONデータを作成
            var requestBody = new
            {
                model = Settings.Default.Model,
                messages = new[]
                {
                    new
                    {
                        role = "user",
                        content = content
                    }
                }
            };
            var requestBodyJson = JsonConvert.SerializeObject(requestBody);
            return requestBodyJson;
        }

        /// <summary>
        /// CSS読み込み
        /// </summary>
        private void LoadCss()
        {
            // リソース内のcssを読み込み
            var css1 = Resources.index_css;
            var css2 = Resources.highlight_min_css;

            IHTMLDocument2 htmlDocument2 = (IHTMLDocument2)webBrowserResponseHtml.Document.DomDocument;
            IHTMLStyleSheet htmlStyleSheet = htmlDocument2.createStyleSheet();
            htmlStyleSheet.cssText = css1;
            htmlStyleSheet.cssText = htmlStyleSheet.cssText + css2;
        }

        /// <summary>
        /// 例外処理
        /// </summary>
        /// <param name="ex"></param>
        private void HandlingException(Exception ex)
        {
            // エラーメッセージを表示
            toolStripStatusLabel.Text = Settings.Default.NavigationMessageException;
            Console.WriteLine(ex.ToString());
            // ログ出力
            _logger.Info($"[Exception]\r\n{ex.ToString()}");
            // 画面状態制御(エラー)
            ControlDisplayState(DisplayState.Error);
        }
    }
}
