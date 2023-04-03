using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatAiClient.Models
{
    /// <summary>
    /// Modelインターフェース
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// 表示名称
        /// </summary>
        string DisplayName { get; set; }

        /// <summary>
        /// 設定値
        /// </summary>
        string ParamValue { get; set; }

        /// <summary>
        /// URLパス
        /// </summary>
        string UrlPass { get; set; }

        /// <summary>
        /// コンテンツタイプ
        /// </summary>
        string ContentType { get; set; }

        /// <summary>
        /// HTTPコンテンツを設定する
        /// </summary>
        /// <param name="requestModel">リクエストモデル</param>
        void SetHttpContent(RequestModel requestModel);

        /// <summary>
        /// POST処理
        /// </summary>
        /// <param name="requestModel">リクエストモデル</param>
        /// <returns>レスポンスモデル</returns>
        Task<ResponseModel> PostAsync(RequestModel requestModel);

        /// <summary>
        /// レスポンス内容を取得する
        /// </summary>
        /// <param name="responseModel">レスポンスモデル</param>
        /// <returns>レスポンス内容</returns>
        Task<string> GetResponseContent(ResponseModel responseModel);

        /// <summary>
        /// キャンセル
        /// </summary>
        void CancelPendingRequests();

        /// <summary>
        /// HTTPクライアント初期化
        /// </summary>
        /// <param name="httpClient">HTTPクライアント</param>
        void InitHttpClient(HttpClient httpClient);
    }
}
