using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Yibi.Core.Server.Extensions
{
    public static class IRouteBuilderExtensions
    {
        public static IRouteBuilder MapServiceRoutes(this IRouteBuilder routes)
        {
            routes.MapRoute(
                name: Routes.IndexRouteName,
                template: "api/v1/index",
                defaults: new { controller = "Index", action = "Get" });

            routes.MapRoute(
                name: Routes.PackageRouteName,
                template: "api/v1/package",
                defaults: new { controller = "Package", action = "Get" });

            return routes;
        }
    }
}
