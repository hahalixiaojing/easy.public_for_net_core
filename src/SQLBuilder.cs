using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easy.Public
{
    /// <summary>
    /// SQL构建
    /// </summary>
    public class SQLBuilder
    {
        readonly IList<SqlSegment> sqlSegments = new List<SqlSegment>();

        readonly SqlSegment WHERE = new SqlSegment()
        {
            IsAppend = false,
            Sql = "WHERE"
        };
        /// <summary>
        /// 
        /// </summary>
        public void AppendWhere()
        {
            sqlSegments.Add(WHERE);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        public void Append(string sql)
        {
            this.Append(true, "", sql);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="prepend"></param>
        /// <param name="sql"></param>
        public void Append(bool condition, String prepend, String sql)
        {
            if (condition)
            {
                if (sqlSegments.Last().Sql != "WHERE")
                {
                    sqlSegments.Add(new SqlSegment()
                    {
                        IsAppend = true,
                        Sql = prepend
                    });
                }


                sqlSegments.Add(new SqlSegment() { IsAppend = true, Sql = sql });

                if (sqlSegments.Any(m => m.Sql == "WHERE"))
                {
                    SqlSegment segment = sqlSegments.Single(m => m.Sql == "WHERE");
                    segment.IsAppend = true;

                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String Sql()
        {
            var sql = new StringBuilder();
            foreach (var keypair in sqlSegments)
            {
                if (keypair.IsAppend)
                {
                    sql.Append(" ");
                    sql.Append(keypair.Sql);
                }
            }
            return sql.ToString().Trim();
        }
    }

    class SqlSegment
    {
        public bool IsAppend
        {
            get;
            set;
        }
        public string Sql
        {
            get;
            set;
        }

    }
}
