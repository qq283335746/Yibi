using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yibi.Web.Models;
using Yibi.Web.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Yibi.Web.Controllers
{
    [Route("Api/[action]")]
    public class ManagerController : Controller
    {
        private readonly ISiteMenuService _menuService;

        public ManagerController(ISiteMenuService menuService)
        {
            _menuService = menuService;
        }

        public async Task<SiteMenuResult> GetSiteMenusAsync(int? parentId)
        {
            try
            {
                var siteMenus = await _menuService.GetSiteMenusAsync(parentId ?? 1);

                return new SiteMenuResult { ResCode = Enums.ResCodeOptions.Success, SiteMenus = siteMenus };
            }
            catch(Exception ex)
            {
                return new SiteMenuResult { ResCode = Enums.ResCodeOptions.Error, Message = ex.Message };
            }
        }

        /// <summary>
        /// 获取当前父节点下的站点菜单树
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public async Task<SiteMenuResult> GetSiteMenusTreeByParentId(int parentId)
        {
            try
            {
                var result = new SiteMenuResult { ResCode = Enums.ResCodeOptions.Success };

                var menus = await _menuService.GetSiteMenusAsync(parentId);
                result.SiteMenusTree = _menuService.CreateSiteMenuTreeJson(menus, parentId);

                return result;
            }
            catch (Exception ex)
            {
                return new SiteMenuResult { ResCode = Enums.ResCodeOptions.Error, Message = ex.Message };
            }
        }
    }
}
