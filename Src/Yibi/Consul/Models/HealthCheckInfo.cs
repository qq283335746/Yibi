using Yibi.Consul.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Consul.Models
{
    public class HealthCheckInfo
    {
        public string Node { get; set; }

        public string CheckID { get; set; }

        public string Name { get; set; }

        public StatusOptions Status { get; set; }

        public string Notes { get; set; }

        public string Output { get; set; }

        public string ServiceID { get; set; }

        public string ServiceName { get; set; }

        public int CreateIndex { get; set; }

        public int ModifyIndex { get; set; }

        public IEnumerable<string> ServiceTags { get; set; }

        public CheckDefinitionInfo Definition { get; set; }
    }
}
