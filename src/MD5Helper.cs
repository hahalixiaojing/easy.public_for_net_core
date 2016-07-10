using System;
using System.Security.Cryptography;
using System.Text;

namespace Easy.Public
{
    /// <summary>
    /// 
    /// </summary>
    public class MD5Helper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static String Encrypt(String text)
        {
            Byte[] data = Encoding.UTF8.GetBytes(text.ToCharArray());
            MD5 md5 = MD5.Create();
            Byte[] result = md5.ComputeHash(data);
            return StringHelper.BytesToHex(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static byte[] Encrypt2(String text)
        {
            Byte[] data = Encoding.UTF8.GetBytes(text.ToCharArray());
            MD5 md5 = MD5.Create();
            Byte[] result = md5.ComputeHash(data);
            return result;
        }

    }
}
