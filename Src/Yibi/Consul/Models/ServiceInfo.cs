using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Consul.Models
{
    /// <summary>
    /// 字段见：https://www.consul.io/api/agent/service.html
    /// </summary>
    public class ServiceInfo
    {
        public string ID { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 示例：127.0.0.1
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 示例：80
        /// </summary>
        public int Port { get; set; }

        public IList<string> Tags { get; set; }

        public Dictionary<string,string> Meta { get; set; }

        public string Kind { get; set; }

        public string ProxyDestination { get; set; }

        public bool EnableTagOverride { get; set; }

        public ServiceCheckInfo Check { get; set; }

        public IEnumerable<ServiceCheckInfo> Checks { get; set; }
    }
}
