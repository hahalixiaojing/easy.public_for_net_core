using Newtonsoft.Json;
using System.Net.Http;

namespace Easy.Public.Logger
{
    /// <summary>
    /// 远程日志
    /// </summary>
    public class RemoteLogger : IMyLogger
    {
        /// <summary>
        /// 调用地址
        /// </summary>
        /// <returns></returns>
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialization()
        {

        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="log"></param>
        public void WriteLog(Log log)
        {

            using (HttpClient client = new HttpClient())
            {
                var msg = new HttpRequestMessage(HttpMethod.Post, this.Url);
                msg.Content = new StringContent(JsonConvert.SerializeObject(log));
                msg.Headers.Add("Content-Type", "application/json");
                client.SendAsync(msg);
            }
        }
    }
}
