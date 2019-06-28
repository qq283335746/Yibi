using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;
using Yibi.Converter;

namespace ConsoleApp.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("正在启动，请稍后...");

            var url = "http://10.168.92.146:8848/Authentication";
            var ueUrl = HttpUtility.UrlEncode(url);

            var ueUrl2 = @"127.0.0.1:8848/nacos/v1/ns/instance/beat?serviceName=nacos.test.2&beat=%7b%22cluster%22%3a%22c1%22%2c%22ip%22%3a%22127.0.0.1%22%2c%22metadata%22%3a%7b%7d%2c%22port%22%3a8080%2c%22scheduled%22%3atrue%2c%22serviceName%22%3a%22jinhan0Fx4s.173TL.net%22%2c%22weight%22%3a1%7d";
            var url2 = HttpUtility.UrlDecode(ueUrl2);

            var url3 = "{\"ip\":\"127.0.0.1\",\"metadata\":{},\"port\":5000,\"scheduled\":true,\"serviceName\":\"CybNacos001\"}";
            var ueUrl3 = HttpUtility.UrlEncode(url3);

            var dic = new Dictionary<string, string>();
            dic.Add("EndPoint", url);

            var json = JsonConvert.SerializeObject(dic);
            var ueJson = HttpUtility.UrlEncode(json);

            OoxmlConvert.RunTest();

            Console.WriteLine("运行结束，请按任意键结束!");

            Console.Read();
        }
    }
}
