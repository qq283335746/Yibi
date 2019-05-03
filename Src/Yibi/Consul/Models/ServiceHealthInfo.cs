using Yibi.Consul.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Consul.Models
{
    public class ServiceHealthInfo
    {
        /// <summary>
        /// like "passing", "warning", and "critical"
        /// </summary>
        public StatusOptions AggregatedStatus { get; set; }

        public ServiceInfo Service { get; set; }

        public IEnumerable<HealthCheckInfo> Checks { get; set; }
    }
}
