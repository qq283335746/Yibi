using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yibi.Web.Models
{
    public class SiteMenuInfo
    {
        public int Id { get; set; }
        public int ParentId { get; set; }

        //public Guid Id { get; set; }

        //public Guid ParentId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public int Sort { get; set; }
    }
}
