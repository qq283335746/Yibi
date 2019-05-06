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
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + "首页" });
                        break;
                    case "Consul":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + "分布式架构之Consul" });
                        break;
                    default:
                        break;
                }
            }

            return items;
        }
    }
}
