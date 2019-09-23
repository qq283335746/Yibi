using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yibi.Web.Models;

namespace Yibi.Web.Services
{
    public class SiteMenuService : ISiteMenuService
    {
        public async Task<IEnumerable<SiteMenuInfo>> GetSiteMenusAsync(int parentId)
        {
            return await Task.Run(() =>
            {
                var datas = new List<SiteMenuInfo>();
                for(var i = 0; i < 11; i++)
                {
                    var id = i;
                    datas.Add(new SiteMenuInfo { Id = id, Title = "测试菜单" + i });
                    for(var j = i + 1; j < i + 3; j++)
                    {
                        datas.Add(new SiteMenuInfo { Id = j,ParentId = id, Title = "测试菜单" + j, Url = "/Managers/MyRazorPage001" });
                    }
                }

                return datas.Where(m => m.ParentId.Equals(parentId));
            });
        }

        public IEnumerable<TreeJsonInfo> CreateSiteMenuTreeJson(IEnumerable<SiteMenuInfo> q, object parentId)
        {
            var datas = new List<TreeJsonInfo>();

            var gGuidEmpty = Guid.Empty.ToString("N");
            
            var childList = q.Where(x => !x.Id.Equals(gGuidEmpty) && x.ParentId.Equals(parentId)).OrderBy(m => m.Sort);
            if (childList != null && childList.Any())
            {
                foreach (var model in childList)
                {
                    var hasChild = q.Any(m => !m.Id.Equals(gGuidEmpty) && m.ParentId.Equals(model.Id));
                    var state = hasChild ? "closed" : "open";
                    if (model.ParentId.Equals(Guid.Empty.ToString("N"))) state = "open";
                    var nodeInfo = new TreeJsonInfo { id = model.Id.ToString(), text = model.Title, state = state, attributes = model };
                    nodeInfo.children = hasChild ? CreateSiteMenuTreeJson(q, model.Id) : new List<TreeJsonInfo>();

                    datas.Add(nodeInfo);
                }
            }
            return datas;
        }
    }
}
