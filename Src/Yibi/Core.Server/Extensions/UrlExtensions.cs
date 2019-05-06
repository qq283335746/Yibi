using System;
using Microsoft.AspNetCore.Mvc;

namespace Yibi.Core.Server.Extensions
{
    public static class UrlExtensions
    {
        public static string PackageBase(this IUrlHelper url) => url.AbsoluteUrl("v3/package/");
        public static string RegistrationsBase(this IUrlHelper url) => url.AbsoluteUrl("v3/registration/");

        public static string AbsoluteUrl(this IUrlHelper url, string relativePath)
        {
            var request = url.ActionContext.HttpContext.Request;

            return string.Concat(
                request.Scheme, "://",
                request.Host.ToUriComponent(),
                request.PathBase.ToUriComponent(),
                "/", relativePath);
        }

        public static string AbsoluteRouteUrl(this IUrlHelper url, string routeName, object routeValues = null)
            => url.RouteUrl(routeName, routeValues, url.ActionContext.HttpContext.Request.Scheme);
    }
}
