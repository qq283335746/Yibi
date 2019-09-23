using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yibi.Web.Models
{
    public class SiteMenuResult:ResponseResult
    {
        public IEnumerable<SiteMenuInfo> SiteMenus { get; set; }

        /// <summary>
        /// 树json
        /// </summary>
        public IEnumerable<TreeJsonInfo> SiteMenusTree { get; set; }
    }
}
