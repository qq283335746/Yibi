using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Eureka.EurekaModels
{
    internal class LeaseInfo
    {
        public int RenewalIntervalInSecs { get; set; }

        public int DurationInSecs { get; set; }

        public long RegistrationTimestamp { get; set; }

        public long LastRenewalTimestamp { get; set; }

        public long EvictionTimestamp { get; set; }

        public long ServiceUpTimestamp { get; set; }
    }
}
