using ChatAiClient.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace ChatAiClient.Models
{
    /// <summary>
    /// 音声モデル
    /// </summary>
    public class AudioModel : IModel
    {
        /// <summary>
        /// HTTPクライアント
        /// </summary>
        public static HttpClient HttpClient = new HttpClient();

        /// <summary>
        /// 表示名称
        /// </summary>
        public string DisplayName { get; set; } = Resources.ModelAudioDisplayName;

        /// <summary>
        /// 設定値
        /// </summary>
        public string ParamValue { get; set; } = Resources.ModelAudioParamValue;

        /// <summary>
        /// URLパス
        /// </summary>
        public string UrlPass { get; set; } = Resources.ModelAudioUrlPass;

        /// <summary>
        /// コンテンツタイプ
        /// </summary>
        public string ContentType { get; set; } = Resources.ModelAudioContentType;

        /// <summary>
        /// 分割ファイルパスリスト
        /// </summary>
        public List<string> SplitFilePathList { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AudioModel()
        {
        }

        /// <summary>
        /// Disposeメソッド
        /// </summary>
        public void Dispose()
        {
            HttpClient?.Dispose();
        }

        /// <summary>
        /// HTTPコンテンツを設定する
        /// </summary>
        /// <param name="requestModel">リクエストモデル</param>
        public void SetHttpContent(RequestModel requestModel)
        {
            // HTTPコンテンツリストを初期化
            requestModel.HttpContents = new List<HttpContent>();

            // ファイル未選択の場合
            if (requestModel.FileStream == null)
            {
                // 分割ファイルパスリストを初期化
                SplitFilePathList = new List<string>();
                // アップロードする音声ファイルパスを取得する
                using (var openFileDialog = new OpenFileDialog())
                {
                    // mp3, mp4, mpeg, mpga, m4a, wav, or webm
                    openFileDialog.Filter = "音声ファイル (*.mp3, *.mp4, *.mpeg, *.mpga, *.m4a, *.wav, *.webm)|*.mp3;*.mp4;*.mpeg;*.mpga;*.m4a;*.wav;*.webm";
                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        requestModel.Content = string.Empty;
                        return;
                    }
                    requestModel.Content = openFileDialog.FileName;
                }
            }
            // ファイル分割
            SplitFile(requestModel.Content);
            foreach (var filePath in SplitFilePathList)
            {
                // HTTPコンテンツリストを作成
                var content = new MultipartFormDataContent();
                content.Add(content: new StringContent(content: ParamValue, encoding: Encoding.UTF8), name: "model");
                var fileName = HttpUtility.UrlEncode(Path.GetFileName(filePath));

                requestModel.FileStream = File.OpenRead(filePath);
                content.Add(content: new StreamContent(content: requestModel.FileStream), name: "file", fileName: fileName);
                requestModel.HttpContents.Add(content);
            }

        }

        /// <summary>
        /// POST処理
        /// </summary>
        /// <param name="requestModel">リクエストモデル</param>
        /// <returns>レスポンスモデル</returns>
        public async Task<ResponseModel> PostAsync(RequestModel requestModel)
        {
            var responseModel = new ResponseModel();
            foreach (var httpContent in requestModel.HttpContents)
            {
                // API実行
                var responseMessage = await HttpClient.PostAsync($"{UrlPass}", httpContent);
                responseModel.HttpResponseMessages.Add(responseMessage);
                switch (responseMessage.StatusCode)
                {
                    case HttpStatusCode.OK:
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.RequestEntityTooLarge:
                        responseModel.IsRetry = false;
                        break;
                    default:
                        responseModel.IsRetry = true;
                        break;
                }
            }

            return responseModel;
        }

        /// <summary>
        /// レスポンス内容を取得する
        /// </summary>
        /// <param name="responseModel">レスポンスモデル</param>
        /// <returns></returns>
        public async Task<string> GetResponseContent(ResponseModel responseModel)
        {
            foreach(var httpResponseMessage in responseModel.HttpResponseMessages)
            {
                var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);

                var json = JObject.Parse(responseContent);
                var text = json["text"];
                if (text != null)
                {
                    // 回答内容テキスト出力
                    responseModel.ResponseContents.Add(text.ToString());
                }
            }

            return string.Join("\n", responseModel.ResponseContents);
        }

        /// <summary>
        /// キャンセル
        /// </summary>
        public void CancelPendingRequests()
        {
            HttpClient.CancelPendingRequests();
        }

        /// <summary>
        /// HTTPクライアント初期化
        /// </summary>
        /// <param name="httpClient">HTTPクライアント</param>
        public void InitHttpClient(HttpClient httpClient)
        {
            if (HttpClient != null)
            {
                HttpClient.Dispose();
            }
            HttpClient = httpClient;
        }

        /// <summary>
        /// ファイル分割
        /// </summary>
        /// <param name="inputFilePath">入力ファイルパス</param>
        private void SplitFile(string inputFilePath)
        {
            // 分割サイズを取得(単位はMB)
            long chunkSize = (long)(Settings.Default.ChunkSizeMb * 1024 * 1024);
            int fileNumber = 0;
            int headerSize = 128;
            long bytesToRead = chunkSize;
            // 入力ファイルを読み取るためのファイルストリームを作成する
            using (var input = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                long fileSize = input.Length;
                long currentPosition = 0;
                while (currentPosition < fileSize)
                {
                    // 残データサイズ
                    long remainingSize = fileSize - currentPosition;
                    // 読み取るバイト数(チャンクサイズか残データサイズのどちらか小さい方で読み取る)
                    // 初回読み取りの場合
                    if (fileNumber == 0)
                    {
                        bytesToRead = Math.Min(chunkSize, remainingSize);
                    }
                    // 2回目以降の場合
                    else
                    {
                        // チャンクサイズの方が小さい場合はチャンクサイズからヘッダーサイズを除いて読み取る
                        bytesToRead = Math.Min(chunkSize - headerSize, remainingSize);
                    }
                    // 分割するバイト配列
                    var buffer = new byte[bytesToRead];
                    input.Read(buffer, 0, buffer.Length);
                    // 現在の位置を記憶する
                    currentPosition = input.Position;
                    var outputFilePathName = GenerateOutputFileName(inputFilePath, fileNumber, chunkSize, bytesToRead);
                    // 分割されたファイルを書き込むためのファイルストリームを作成
                    using (var output = new FileStream(outputFilePathName, FileMode.Create))
                    {
                        // 初回読み取りの場合
                        if (fileNumber > 0)
                        {
                            // ファイルの先頭からヘッダー情報を読み込み
                            var header = GetHeader(inputFilePath);
                            // ヘッダー情報を書き込む
                            output.Write(header, 0, header.Length);
                        }
                        // バイト配列を書き込む
                        output.Write(buffer, 0, buffer.Length);
                        // 分割ファイルパスリストに追加
                        SplitFilePathList.Add(output.Name);
                    }
                    // 分割されたファイル数をカウント
                    fileNumber++;
                }
            }
        }

        /// <summary>
        /// 分割ファイル名を生成する
        /// </summary>
        /// <param name="inputFilePath">入力ファイルパス</param>
        /// <param name="fileNumber">分割ファイルの連番</param>
        /// <param name="chunkSize">チャンクサイズ</param>
        /// <param name="bytesRead">読み取ったバイト数</param>
        /// <returns>分割ファイルパス</returns>
        private string GenerateOutputFileName(string inputFilePath, int fileNumber, long chunkSize, long bytesRead)
        {
            var directoryName = Path.GetDirectoryName(inputFilePath);
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(inputFilePath);
            var extension = Path.GetExtension(inputFilePath);
            var fileSize = new FileInfo(inputFilePath).Length;
            var totalChunks = (int)Math.Ceiling((double)fileSize / chunkSize);
            var chunkNumber = fileNumber + 1;
            return Path.Combine(directoryName, $"{fileNameWithoutExtension}_{chunkNumber.ToString().PadLeft(totalChunks.ToString().Length, '0')}_{bytesRead}{extension}");
        }

        /// <summary>
        /// ファイルヘッダーを取得する
        /// </summary>
        /// <param name="inputFilePath">入力ファイルパス</param>
        /// <returns></returns>
        private byte[] GetHeader(string inputFilePath)
        {
            var headerSize = 128;
            var buffer = new byte[headerSize];
            using (var input = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                input.Read(buffer, 0, headerSize);
            }
            return buffer;
        }
    }
}
