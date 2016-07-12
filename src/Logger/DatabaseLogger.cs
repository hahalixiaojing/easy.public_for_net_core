using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace Easy.Public.Logger
{
    /// <summary>
    /// 记录到数据库
    /// </summary>
    public class DatabaseLogger : IMyLogger
    {
        private Type connectionType;
        private IFormatProvider formatProvider = new LogSqlFormatter();
        /// <summary>
        /// 数据库字符串
        /// </summary>
        /// <returns></returns>
        public String ConnectionString
        {
            get;
            set;
        }
        /// <summary>
        /// SQL
        /// </summary>
        /// <returns></returns>
        public String CommandSqlText
        {
            get;
            set;
        }
        /// <summary>
        /// 数据连接类型
        /// </summary>
        /// <returns></returns>
        public String ConnectionType
        {
            get;
            set;
        }

        #region IMyLogger Members
        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialization()
        {
            if (!String.IsNullOrEmpty(this.ConnectionType))
            {
                this.connectionType = Type.GetType(this.ConnectionType);
            }
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="log"></param>
        public void WriteLog(Log log)
        {
            if (String.IsNullOrEmpty(this.ConnectionString) || String.IsNullOrEmpty(this.CommandSqlText) || String.IsNullOrEmpty(this.ConnectionType))
            {
                return;
            }
            if (this.connectionType == null)
            {
                return;
            }
            
            using (DbConnection connection = Activator.CreateInstance(this.connectionType, this.ConnectionString) as DbConnection)
            {
                connection.Open();
                DbCommand commmand = connection.CreateCommand();
                commmand.Connection = connection;
                commmand.CommandText = String.Format(formatProvider, this.CommandSqlText, log);
                commmand.CommandType = CommandType.Text;
                try
                {
                    commmand.ExecuteNonQuery();
                }
                catch { }
                finally
                {
                    commmand.Dispose();
                }
            }
        }

        #endregion
    }
}
