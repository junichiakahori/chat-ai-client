using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatAiClient.Models
{
    /// <summary>
    /// リクエストモデル
    /// </summary>
    public class RequestModel
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// HTTPコンテンツリスト
        /// </summary>
        public List<HttpContent> HttpContents { get; set; }

        /// <summary>
        /// ファイルストリーム
        /// </summary>
        public FileStream FileStream { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RequestModel()
        {
            HttpContents = new List<HttpContent>();
        }

        /// <summary>
        /// Disposeメソッド
        /// </summary>
        public void Dispose()
        {
            FileStream?.Close();
        }
    }
}
