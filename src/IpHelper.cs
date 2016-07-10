using System;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Linq;
namespace Easy.Public
{
    /// <summary>
    /// 获得服务器IP地址帮助类，此类有BUG
    /// </summary>
    public static class IpHelper
    {
        /// <summary>
        /// 获得电脑IP4地址列表
        /// </summary>
        /// <returns></returns>
        public static string[] Ip4List()
        {
            string hostName = Dns.GetHostName();
            IPAddress[] addressList = System.Net.Dns.GetHostAddressesAsync(hostName).Result;
            foreach(var a in addressList)
            {
                System.Console.WriteLine(a.ToString());
            }

            return addressList.Where(m => m.AddressFamily == AddressFamily.InterNetwork)
                            .Select(m => m.ToString()).ToArray();
        }
        /// <summary>
        /// 获得一个内网IP
        /// </summary>
        /// <returns></returns>
        public static string IntranetIp4()
        {
            string[] ipList = Ip4List();
            foreach (var ip in ipList)
            {
                byte[] bytes = IPAddress.Parse(ip).GetAddressBytes();

                if (bytes[0] == 192 && bytes[1] == 168)
                {
                    return ip;
                }
                if (bytes[0] == 10)
                {
                    return ip;
                }

                if (bytes[0] == 172 && bytes[1] >= 16 && bytes[1] <= 31)
                {
                    return ip;
                }
                
            }
            return string.Empty;
        }
        /// <summary>
        /// 获得广域网IP
        /// </summary>
        /// <returns></returns>
        public static string InternetIp4()
        {
            string intranetIp4 = IntranetIp4();
            return Ip4List().Where(m => m != intranetIp4 && !m.StartsWith("169")).FirstOrDefault();
        }
        /// <summary>
        /// 127.0.0.1 IP地址
        /// </summary>
        /// <returns></returns>
        public static string LoopbackIp()
        {
            return IPAddress.Loopback.ToString();
        }

        /// <summary>
        /// 随机获得指定范围内可用的端口号
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="start">起始端口</param>
        /// <param name="end">结束端口</param>
        /// <returns></returns>
        public static int GetAvailablePort(string ip, int start, int end)
        {

            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();

            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();
            var rand = new Random(Guid.NewGuid().GetHashCode());
            var port = rand.Next(start, end + 1);

            while (true)
            {
                bool istry = false;
                foreach (IPEndPoint endPoint in ipEndPoints)
                {
                    if (endPoint.Port == port && endPoint.Address.ToString() == ip)
                    {
                        istry = true;
                        break;
                    }
                }
                if (istry)
                {
                    port = rand.Next(start, end + 1);
                    istry = false;
                    continue;
                }
                return port;
            }

        }
    }
}
