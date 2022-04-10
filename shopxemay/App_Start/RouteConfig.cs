using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace shopxemay
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         //   //khai báo url = có định
         //   routes.MapRoute(
         //     name: "Tatcasanpham",
         //     url: "tat-ca-san-pham",
         //     defaults: new { controller = "ShopXe", action = "Index", id = UrlParameter.Optional }
         // );

         //   routes.MapRoute(
         //     name: "GioHang",
         //     url: "gio-hang",
         //     defaults: new { controller = "GioHang", action = "Index", id = UrlParameter.Optional }
         // );

         //   routes.MapRoute(
         //    name: "TimKiem",
         //    url: "tim-kiem",
         //    defaults: new { controller = "TimKiem", action = "Index", id = UrlParameter.Optional }
         //);
         //   //khai bao url động
         //   routes.MapRoute(
         //       name: "SileSlug",
         //       url: "Slug",
         //       defaults: new { controller = "ShopXe", action = "Index", id = UrlParameter.Optional }
         //   );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ShopXe", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
