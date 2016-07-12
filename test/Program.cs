using Easy.Public;
using Easy.Public.Doc;
using System;
using System.IO;
using System.Reflection;
using Easy.Public.Logger;
namespace ConsoleApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
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
            sql.Append(q.Id > 0, "and", "Id=@Id");

            Console.WriteLine(sql.Sql());

            Console.WriteLine($"外网IP：{IpHelper.InternetIp4()}"); 
            Console.WriteLine($"内网IP：{IpHelper.IntranetIp4()}");
            Console.WriteLine($"look up：{ IpHelper.LoopbackIp()}");
            Console.WriteLine("================");
            foreach (var ip in IpHelper.Ip4List())
            {
                Console.WriteLine(ip);
            }
            int port = IpHelper.GetAvailablePort(IpHelper.IntranetIp4(), 1000, 9999);

            Console.WriteLine($"this port is {port}");


            int r = StringHelper.ToInt32("1", 100);
            Console.WriteLine($"int is {r}");
            bool r2 = StringHelper.ToBoolean("true", false);
            Console.WriteLine($"bool is {r2}");


            string md5 = MD5Helper.Encrypt("123");
            Console.WriteLine(md5);
            string sha256 = SHA256Helper.Signature("123");
            Console.WriteLine(sha256);


            var file = new System.IO.FileInfo(Path.Combine(AppContext.BaseDirectory, "Easy.Public.xml"));

            XmlDoc doc = new XmlDoc(file);

            string typeSummary = doc.ClassSummary(typeof(IpHelper));
            Console.WriteLine(typeSummary);

            Type type = typeof(IpHelper);
            foreach (var m in type.GetMethods())
            {
                string text = doc.MethodSummary(m);
                Console.WriteLine(text);
            }

            Type queryType = typeof(Query);

            var file2 = new System.IO.FileInfo(Path.Combine(AppContext.BaseDirectory, "test.xml"));
            XmlDoc queryDoc = new XmlDoc(file2);
            var dic = queryDoc.AllFieldsSummary(queryType);

            foreach (var item in dic)
            {
                Console.WriteLine(item.Key + "," + item.Value.Summary);
            }

            LogManager.Register(new PlainFileLogger());

            LogManager.Info("tag","abc");

        }
    }
    /// <summary>
    /// 
    /// </summary>
    class Query
    {
        /// <summary>
        /// 性别
        /// </summary>
        public bool Sex;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Id { get; set; }
    }
}
