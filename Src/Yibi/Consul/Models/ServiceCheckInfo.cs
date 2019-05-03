using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Consul.Models
{
    /// <summary>
    /// 字段见：https://www.consul.io/api/agent/check.html
    /// </summary>
    public class ServiceCheckInfo
    {
        public string ID { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// like "10s"
        /// </summary>
        public string Interval { get; set; }

        /// <summary>
        /// like "passing", "warning", and "critical"
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// like "10m"
        /// </summary>
        public string DeregisterCriticalServiceAfter { get; set; }

        /// <summary>
        /// like "http://xxx.xxx.xxx"
        /// </summary>
        public string HTTP { get; set; }

        /// <summary>
        /// like "GET","POST",...
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// like "10s"
        /// </summary>
        public string Timeout { get; set; }

        public string ServiceID { get; set; }

        public string Notes { get; set; }

        public IList<string> Args { get; set; }

        public string AliasNode { get; set; }

        public string AliasService { get; set; }

        public string GRPC { get; set; }

        public string GRPCUseTLS { get; set; }

        public bool TLSSkipVerify { get; set; }

        public string TCP { get; set; }

        public string TTL { get; set; }
    }
}
