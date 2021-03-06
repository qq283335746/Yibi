﻿using System;
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
                    case "Nacos":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + "分布式架构之Nacos" });
                        break;
                    case "Apollo":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + "分布式架构之Apollo（阿波罗）配置中心" });
                        break;
                    case "Redis":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + "分布式架构之Redis" });
                        break;
                    case "ElasticSearch":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + "分布式架构之ElasticSearch" });
                        break;
                    case "NuGet":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + ".Net开发之NuGet" });
                        break;
                    case "CSharpDotNet":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + "C#/.NET技术文档" });
                        break;
                    case "DotNetCore":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + "C#/.NET Core技术文档" });
                        break;
                    case "Sqlite":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + "关于Sqlite使用与问题集锦" });
                        break;
                    case "MySql":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + "关于MySql使用与问题集锦" });
                        break;
                    case "PostgreSql":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + "关于PostgreSql使用与问题集锦" });
                        break;
                    case "Wms":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + "智能仓储配送平台（WMS）" });
                        break;
                    case "Windows":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + "Windows组件编程相关" });
                        break;
                    case "Linux":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + "Windows组件编程相关" });
                        break;
                    case "GhPages":
                        items.Add(new WordToHtmlInfo { FilePath = filePath, PageName = fileName, PageTitle = prefix + "GitHub Pages使用相关" });
                        break;
                    default:
                        break;
                }
            }

            return items;
        }
    }
}
