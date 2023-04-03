using ChatAiClient.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ChatAiClient.Models
{
    /// <summary>
    /// チャットモデル
    /// </summary>
    public class ChatModel : IModel
    {
        /// <summary>
        /// HTTPクライアント
        /// </summary>
        public static HttpClient HttpClient = new HttpClient();

        /// <summary>
        /// 表示名称
        /// </summary>
        public string DisplayName { get; set; } = Resources.ModelChatDisplayName;

        /// <summary>
        /// 設定値
        /// </summary>
        public string ParamValue { get; set; } = Resources.ModelChatParamValue;

        /// <summary>
        /// URLパス
        /// </summary>
        public string UrlPass { get; set; } = Resources.ModelChatUrlPass;

        /// <summary>
        /// コンテンツタイプ
        /// </summary>
        public string ContentType { get; set; } = Resources.ModelChatContentType;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ChatModel()
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

            // JSONデータを作成
            var requestBody = new
            {
                model = ParamValue,
                messages = new[]
                {
                    new
                    {
                        role = "user",
                        content = requestModel.Content
                    }
                }
            };
            var requestBodyJson = JsonConvert.SerializeObject(requestBody);
            requestModel.HttpContents.Add(new StringContent(requestBodyJson, Encoding.UTF8, "application/json"));
        }

        /// <summary>
        /// POST処理
        /// </summary>
        /// <param name="requestModel">リクエストモデル</param>
        /// <returns>レスポンス内容</returns>
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
            foreach (var httpResponseMessage in responseModel.HttpResponseMessages)
            {
                var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);

                var json = JObject.Parse(responseContent);
                var choices = json["choices"];
                if (choices != null)
                {
                    var message = choices[0]["message"];
                    if (message != null)
                    {
                        // 回答内容テキスト出力
                        responseModel.ResponseContents.Add(message["content"].ToString());
                    }
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
    }
}
