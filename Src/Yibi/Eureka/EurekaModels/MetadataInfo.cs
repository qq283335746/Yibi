using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Eureka.EurekaModels
{
    internal class MetadataInfo
    {
        [JsonProperty("$")]
        public string Text { get; set; }

        [JsonProperty("@class")]
        public string ClassRelation { get; set; }

    }
}
