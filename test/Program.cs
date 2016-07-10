using Easy.Public;
using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var test = new EntityPropertyHelperTest();
            test.SetPropertyTest();
            Entity entity = null;

            var result = NullHelper.IfNull(entity, 100, m => m.Id);
            Console.WriteLine($"should 100 actual {result}");

            var q = new Query()
            {
                Name = "lixiaojing",
                Id = 0
            };

            var sql = new SQLBuilder();
            sql.AppendWhere();
            sql.Append(!string.IsNullOrWhiteSpace(q.Name), "and", "name=@name");
            sql.Append(q.Id>0,"and","Id=@Id");

            Console.WriteLine(sql.Sql());

            Console.WriteLine($"外网IP：{IpHelper.InternetIp4()}"); 
            Console.WriteLine($"内网IP：{IpHelper.IntranetIp4()}");
            Console.WriteLine($"look up：{ IpHelper.LoopbackIp()}");
            Console.WriteLine("================");
            foreach(var ip in IpHelper.Ip4List())
            {
                Console.WriteLine(ip);
            }
            int port = IpHelper.GetAvailablePort(IpHelper.IntranetIp4(),1000,9999);

            Console.WriteLine($"this port is {port}");


            int r = StringHelper.ToInt32("1",100);
            Console.WriteLine($"int is {r}");
            bool r2 = StringHelper.ToBoolean("true",false);
            Console.WriteLine($"bool is {r2}");


            string md5 = MD5Helper.Encrypt("123");
            Console.WriteLine(md5);
            string sha256 = SHA256Helper.Signature("123");
            Console.WriteLine(sha256);

           

        }
    }

    class Query
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
