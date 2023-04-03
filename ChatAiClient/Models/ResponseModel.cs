using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatAiClient.Models
{
    /// <summary>
    /// レスポンスモデル
    /// </summary>
    public class ResponseModel
    {
        /// <summary>
        /// レスポンス内容
        /// </summary>
        public List<string> ResponseContents { get; set; }

        /// <summary>
        /// HTTPレスポンスメッセージリスト
        /// </summary>
        public List<HttpResponseMessage> HttpResponseMessages { get; set; }

        /// <summary>
        /// リトライフラグ
        /// </summary>
        public bool IsRetry { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ResponseModel()
        {
            ResponseContents = new List<string>();
            HttpResponseMessages = new List<HttpResponseMessage>();
        }
    }
}
