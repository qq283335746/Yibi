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

            routes.MapRoute(
               name: Routes.LiteDbTestRouteName,
               template: "api/v1/LiteDb",
               defaults: new { controller = "LiteDbTest", action = "Get" });

            //routes.MapRoute(
            //  name: Routes.LiteDbTestHelloWorldRouteName,
            //  template: "api/v1/LiteDb/HelloWorld",
            //  defaults: new { controller = "LiteDbTest", action = "HelloWorld" });

            routes.MapRoute(
              name: Routes.LiteDbTestGetAllRouteName,
              template: "api/v1/LiteDb/{Action}",
              defaults: new { controller = "LiteDbTest", action = "{Action}" });

            routes.MapRoute(
              name: Routes.EfDbTestRouteName,
              template: "api/v1/EfDb",
              defaults: new { controller = "EfDbTest", action = "Get" });

            routes.MapRoute(
              name: Routes.EfDbTestGetAllRouteName,
              template: "api/v1/EfDb/{Action}",
              defaults: new { controller = "EfDbTest", action = "{Action}" });

            return routes;
        }
    }
}
