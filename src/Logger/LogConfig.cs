using System;
namespace Easy.Public.Logger
{
    /// <summary>
    /// 日志配置
    /// </summary>
    public static class LogConfig
    {
        /// <summary>
        /// 是否记录日志
        /// </summary>
        public const String LOG_IS_LOGGED = "log_is_logged"; //值 true ,false
        /// <summary>
        /// 日志级别
        /// </summary>
        public const String LOG_LEVEL = "log_level";//
        /// <summary>
        /// 日志记录类型
        /// </summary>
        public const String LOG_LOGGER = "log_logger";

        //其它具体日志记录器属性以:log_p_小写属性名定义

        //数据库记录日志示例
        //<!--<add key="log_p_connectionstring" value="Data Source=.\SQLEXPRESS;Initial Catalog=test_log;Persist Security Info=True;User ID=sa;Password=sa123"/>
        //<add key="log_p_commandsqltext" value="insert into app_logs(log_tag,log_message,log_datetime,log_level) values('{0:t}','{0:m}','{0:d}','{0:l}');"/> t=tag,m=message,d=datetime,l=level
        //<add key="log_p_connectiontype" value="System.Data.SqlClient.SqlConnection, System.Data, Version=2.0.0.0,Culture=neutral,PublicKeyToken=b77a5c561934e089"/>-->
    }
}
