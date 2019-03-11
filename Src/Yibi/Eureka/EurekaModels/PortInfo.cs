using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Eureka.EurekaModels
{
    internal class PortInfo
    {
        [JsonProperty("$")]
        public string Text { get; set; }

        [JsonProperty("@enabled")]
        public bool Enabled { get; set; }
    }
}
