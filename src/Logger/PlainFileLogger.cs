using System;
using System.Text;
using System.IO;

namespace Easy.Public.Logger
{
    /// <summary>
    /// 文件日志
    /// </summary>
    public class PlainFileLogger : IMyLogger
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

            StringBuilder logText = new StringBuilder();
            logText.Append("tag : ");
            logText.AppendLine(log.Tag);
            logText.Append("message : ");
            logText.AppendFormat("{0}" + Environment.NewLine, log.Message);
            logText.AppendLine("datetime : ");
            logText.Append(log.DateTime.ToString());
            logText.AppendLine("=====================================================");

            String logFile = this.GetLogFileName(log.LogLevel);
            File.AppendAllText(logFile, logText.ToString(),Encoding.UTF8);
        }
        #endregion
        /// <summary>
        /// 日志目录
        /// </summary>
        /// <returns></returns>
        public String LogDir
        {
            get;
            set;
        }
        /// <summary>
        /// 获得日志文件夹
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        private String GetLogFileName(LogLevel level)
        {
            string subPath = string.Empty;
            if (String.IsNullOrEmpty(LogDir))
            {
                subPath = Path.Combine(AppContext.BaseDirectory, "logs");
            }
            else if (this.LogDir.Contains(":"))
            {
                subPath = this.LogDir;
            }
            else
            {
                subPath = Path.Combine(AppContext.BaseDirectory, this.LogDir);
            }
            if (!Directory.Exists(subPath))
            {
                Directory.CreateDirectory(subPath);
            }

            subPath = Path.Combine(subPath, level.ToString());
            if (!Directory.Exists(subPath))
            {
                Directory.CreateDirectory(subPath);
            }
            return Path.Combine(subPath, DateTime.Now.ToString("yyyyMMdd") + ".log");
        }
    }
}
