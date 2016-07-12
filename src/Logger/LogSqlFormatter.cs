using System;

namespace Easy.Public.Logger
{
    public class LogSqlFormatter : IFormatProvider, ICustomFormatter
    {
        #region IFormatProvider Members
        /// <summary>
        /// 获得格式化
        /// </summary>
        /// <param name="formatType"></param>
        /// <returns></returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        #endregion

        #region ICustomFormatter Members
        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            Log log = arg as Log;
            if (format == "t")
            {
                return log.Tag;
            }
            else if (format == "m")
            {
                return string.Format("{0}", log.Message);
            }
            else if (format == "d")
            {
                return log.DateTime.ToString();
            }
            else if (format == "l")
            {
                return log.LogLevel.ToString();
            }
            return string.Empty;
        }
        #endregion
    }
}
