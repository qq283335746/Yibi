using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yibi.Web.Models
{
    public class TreeJsonInfo
    {
        public string id { get; set; }

        public string text { get; set; }

        public string state { get; set; }

        public object attributes { get; set; }

        public object children { get; set; }
    }
}
