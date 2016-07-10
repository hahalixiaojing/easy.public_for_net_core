using System;

namespace Easy.Public.Doc
{
    /// <summary>
    /// 
    /// </summary>
    public class MemberTypeInfo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="summary"></param>
        public MemberTypeInfo(String name,Type type,string summary)
        {
            this.Name = name;
            this.Type = type;
            this.Summary = summary;
        }
        /// <summary>
        /// 成员名称
        /// </summary>
        public String Name
        {
            get;
            private set;
        }
        /// <summary>
        /// 成员类型
        /// </summary>
        public Type Type
        {
            get;
            private set;
        }
        /// <summary>
        /// 成员说明
        /// </summary>
        public String Summary
        {
            get;
            private set;
        }
        
    }
}
