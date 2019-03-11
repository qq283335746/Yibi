using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Eureka.EurekaModels
{
    /// <summary>
    /// 对应Eureka的Instance实例信息
    /// </summary>
    internal class InstanceInfo
    {
        public string InstanceId { get; set; }

        public string HostName { get; set; }

        public string App { get; set; }

        public string IpAddr { get; set; }

        public string Status { get; set; }

        public string Overriddenstatus { get; set; }

        public PortInfo Port { get; set; }

        public SecurePortInfo SecurePort { get; set; }

        public int CountryId { get; set; }

        public DataCenterInfo DataCenterInfo { get; set; }

        public LeaseInfo LeaseInfo { get; set; }

        public MetadataInfo Metadata { get; set; }

        public string HomePageUrl { get; set; }

        public string StatusPageUrl { get; set; }

        public string HealthCheckUrl { get; set; }

        public string VipAddress { get; set; }

        public string SecureVipAddress { get; set; }

        public bool IsCoordinatingDiscoveryServer { get; set; }

        public long LastUpdatedTimestamp { get; set; }

        public long LastDirtyTimestamp { get; set; }

        public string ActionType { get; set; }
    }
}
