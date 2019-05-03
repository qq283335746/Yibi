using System;
using Yibi.Converter;

namespace ConsoleApp.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("正在启动，请稍后...");

            OoxmlConvert.RunTest();

            Console.WriteLine("运行结束，请按任意键结束!");

            Console.Read();
        }
    }
}
