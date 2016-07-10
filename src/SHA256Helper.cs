using System;
using System.Text;
using System.Security.Cryptography;

namespace Easy.Public
{

    /// <summary>
    /// SHA256 哈希函数 加密帮助类
    /// </summary>
    public static class SHA256Helper
    {
        /// <summary>
        /// 将文本进行加密码签名
        /// </summary>
        /// <param name="text">需要签名的文本</param>
        /// <returns>返回基于base64的签名文本</returns>
        public static String Signature(String text)
        {
            Byte[] byteText = Encoding.UTF8.GetBytes(text.ToCharArray());
            using (HMACSHA256 hmacsha256 = new HMACSHA256())
            {
                Byte[] signatureBytes = hmacsha256.ComputeHash(byteText);
                return StringHelper.BytesToHex(signatureBytes);
            }
        }
    }
}
