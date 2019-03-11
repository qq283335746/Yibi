using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Eureka.EurekaModels
{
    internal class DataCenterInfo
    {
        public string Name { get; set; }

        [JsonProperty("@class")]
        public string ClassRelation { get; set; }
    }
}
