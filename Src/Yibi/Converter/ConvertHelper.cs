using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Yibi.Converter.Models;

namespace Yibi.Converter
{
    public class ConvertHelper
    {
        public static IEnumerable<WordToHtmlInfo> GetSources()
        {
            var items = new List<WordToHtmlInfo>();

            var files = Directory.GetFiles(@"E:\MyWorkspace\Temp\qq283335746.github.io\docs");
            foreach (var filePath in files)
            {
                var ext = Path.GetExtension(filePath);
                if (ext != ".docx") continue;

                var fileName = Path.GetFileNameWithoutExtension(filePath);
                var prefix = "Yibi Chen ";

                switch (fileName)
                {
                    case "Index":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + "" });
                        break;
                    case "Home":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + "首页" });
                        break;
                    case "Consul":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + "分布式架构之Consul" });
                        break;
                    case "Eureka":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + "分布式架构之Eureka" });
                        break;
                    case "Apollo":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + "分布式架构之Apollo（阿波罗）配置中心" });
                        break;
                    case "NuGet":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + ".Net开发之NuGet" });
                        break;
                    default:
                        break;
                }
            }

            return items;
        }
    }
}
