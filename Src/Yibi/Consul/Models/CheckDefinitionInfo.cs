using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Consul.Models
{
    public class CheckDefinitionInfo
    {
        public string Interval { get; set; }

        public string Timeout { get; set; }

        public string DeregisterCriticalServiceAfter { get; set; }

        public string HTTP { get; set; }

        public string Method { get; set; }

        public bool TLSSkipVerify { get; set; }

        public string TCP { get; set; }
    }
}
