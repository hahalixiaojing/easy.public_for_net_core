using System;
namespace Easy.Public.Logger
{
    /// <summary>
    /// 日志对象
    /// </summary>
    public class Log
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="message"></param>
        /// <param name="logLevel"></param>
        public Log(String tag, Object message, LogLevel logLevel)
        {
            this.Tag = tag;
            this.Message = message;
            this.LogLevel = logLevel;
            this.DateTime = DateTime.Now;
        }
        /// <summary>
        /// 标签
        /// </summary>
        /// <returns></returns>
        public String Tag
        {
            get;
            private set;
        }
        /// <summary>
        /// 消息内容
        /// </summary>
        /// <returns></returns>
        public Object Message
        {
            get;
            private set;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime DateTime
        {
            get;
            private set;
        }
        /// <summary>
        /// 消息级别
        /// </summary>
        /// <returns></returns>
        public LogLevel LogLevel
        {
            get;
            private set;
        }
    }

  
}
