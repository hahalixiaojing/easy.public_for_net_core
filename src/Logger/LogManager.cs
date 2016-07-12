using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Easy.Public.Logger
{
    /// <summary>
    /// logmanager
    /// </summary>
    public static class LogManager
    {
        private readonly static Queue<Log> queue = new Queue<Log>(30);
        private readonly static Semaphore semaphore = new Semaphore(30, 30);
        private readonly static IList<IMyLogger> myLog = new List<IMyLogger>();

        static LogManager()
        {
            LogLevel = LogLevel.Error;
            IsLogged = true;
            Task.Factory.StartNew(LogManager.Work,TaskCreationOptions.LongRunning);
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="log"></param>
        public static void Register(IMyLogger log)
        {
            log.Initialization();
            myLog.Add(log);
        }
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="isLogged"></param>
        /// <param name="loglevel"></param>
        public static void Config(bool isLogged, LogLevel loglevel)
        {
            LogLevel = loglevel;
            IsLogged = isLogged;
        }

        private static LogLevel LogLevel
        {
            get;
            set;
        }
        private static bool IsLogged
        {
            get;
            set;
        }

        /// <summary>
        /// 所有信息都记录
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="message"></param>
        public static void Verbose(String tag, object message)
        {
            if (IsLogged && LogLevel == LogLevel.Verbose)
            {
                LogManager.AddLog(new Log(tag, message, LogLevel.Verbose));
            }
        }
        /// <summary>
        /// 一般信息
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="message"></param>
        public static void Info(String tag, object message)
        {
            if (IsLogged && LogManager.LogLevel <= LogLevel.Info)
            {
                LogManager.AddLog(new Log(tag, message, LogLevel.Info));
            }
        }
        /// <summary>
        /// 警告信息
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="message"></param>
        public static void Warn(String tag, object message)
        {
            if (IsLogged && LogManager.LogLevel <= LogLevel.Warning)
            {
                LogManager.AddLog(new Log(tag, message, LogLevel.Warning));
            }
        }
        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="message"></param>
        public static void Error(String tag, object message)
        {
            if (IsLogged && LogManager.LogLevel <= LogLevel.Error)
            {
                LogManager.AddLog(new Log(tag, message, LogLevel.Error));
            }
        }

        private static void AddLog(Log log)
        {
            if (semaphore.WaitOne(1000))
            {
                lock (queue)
                {
                    queue.Enqueue(log);
                    Monitor.Pulse(queue);
                }
            }
        }

        private static void Work()
        {
            while (true)
            {
                Log log = LogManager.Dequeue();
                if (myLog != null)
                {
                    try
                    {
                        foreach (var l in myLog)
                        {
                            Task.Factory.StartNew(() =>
                            {
                                l.WriteLog(log);
                            });
                        }
                    }
                    catch (Exception e) { throw e; }
                }
            }
        }
        private static Log Dequeue()
        {
            lock (queue)
            {
                while (true)
                {
                    if (queue.Count > 0)
                    {
                        Log log = queue.Dequeue();
                        semaphore.Release();
                        return log;
                    }
                    Monitor.Wait(queue);
                }
            }
        }
    }
}
