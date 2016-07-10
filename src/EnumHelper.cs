

namespace Easy.Public
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="text"></param>
        /// <param name="currentKeys"></param>
        /// <param name="defaultText"></param>
        /// <returns></returns>
        public static string GetText(int[] keys, string[] text, int currentKeys, string defaultText)
        {
            int index = -1 ;
            for(var i = 0; i < keys.Length; i++)
            {
                if(currentKeys == keys[i])
                {
                    index = i;
                    break;
                }
            }
            if(index == -1)
            {
                return defaultText;
            }
            return text[index];
        }
    }
}

