namespace Easy.Public.Logger
{
    /// <summary>
    /// 日志接口
    /// </summary>
    public interface IMyLogger
    {
        /// <summary>
        /// 初始化
        /// </summary>
        void Initialization();
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="log"></param>
        void WriteLog(Log log);
    }
}
