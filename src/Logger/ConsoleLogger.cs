using System;
using System.Diagnostics;

namespace Easy.Public.Logger
{
    /// <summary>
    /// 控制台Log
    /// </summary>
    public class ConsoleLogger : IMyLogger
    {
        #region IMyLog Members
        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialization() { }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="log"></param>
        public void WriteLog(Log log)
        {
            Debug.WriteLine(String.Format("tag : {0}", log.Tag));
            Debug.WriteLine(String.Format("message : {0}", log.Message));
            Debug.WriteLine(String.Format("datetime : {0}", log.DateTime));
            Debug.WriteLine(String.Format("type: {0}", log.LogLevel.ToString()));
            Debug.WriteLine("==========================================");
        }
        #endregion
    }
}
