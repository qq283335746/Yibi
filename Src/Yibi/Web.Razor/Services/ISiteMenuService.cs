using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yibi.Web.Models;

namespace Yibi.Web.Services
{
    public interface ISiteMenuService
    {
        Task<IEnumerable<SiteMenuInfo>> GetSiteMenusAsync(int parentId);

        IEnumerable<TreeJsonInfo> CreateSiteMenuTreeJson(IEnumerable<SiteMenuInfo> q, object parentId);
    }
}
