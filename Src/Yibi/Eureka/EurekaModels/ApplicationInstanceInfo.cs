using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Eureka.EurekaModels
{
    internal class ApplicationInstanceInfo
    {
        public string Name { get; set; }

        public IEnumerable<InstanceInfo> Instance { get; set; }
    }
}
