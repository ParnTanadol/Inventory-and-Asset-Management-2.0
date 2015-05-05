using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Inventory_and_Asset_Management_2._0
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
