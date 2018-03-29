using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Doandinhduong
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*botdetect}",
            new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "Search",
                url: "tim-kiem",
                defaults: new { controller = "Thucpham", action = "Search", id = UrlParameter.Optional },
                namespaces: new[] { "Doandinhduong.Controllers" }
            );
            routes.MapRoute(
                name: "Register",
                url: "dang-ky",
                defaults: new { controller = "LoginRegister", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "Doandinhduong.Controllers" }
            );
            routes.MapRoute(
                name: "Dangnhap",
                url: "dang-nhap",
                defaults: new { controller = "LoginRegister", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "Doandinhduong.Controllers" }
            );
            routes.MapRoute(
                name: "gianhchoban",
                url: "gianh-cho-ban/{username}",
                defaults: new { controller = "Nguoidung", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Doandinhduong.Controllers" }
            );
            routes.MapRoute(
                name: "gianhcho",
                url: "gianh-cho-ban",
                defaults: new { controller = "Nguoidung", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Doandinhduong.Controllers" }
            );
            routes.MapRoute(
               name: "theodoicothe",
               url: "theo-doi-co-the/{username}",
               defaults: new { controller = "Theodoi", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "Doandinhduong.Controllers" }
           );
                routes.MapRoute(
                name: "Capnhatthongtin",
                url: "cap-nhap-thong-tin/{username}",
                defaults: new { controller = "Nguoidung", action = "Edit", id = UrlParameter.Optional },
                namespaces: new[] { "Doandinhduong.Controllers" }
            );
                routes.MapRoute(
                   name: "Chitietthucpham",
                   url: "chi-tiet/{id}",
                   defaults: new { controller = "Thucpham", action = "Chitietthucpham", id = UrlParameter.Optional },
                   namespaces: new[] { "Doandinhduong.Controllers" }
               );
            routes.MapRoute(
                   name: "lienhe",
                   url: "lien-he",
                   defaults: new { controller = "Lienhe", action = "Index", id = UrlParameter.Optional },
                   namespaces: new[] { "Doandinhduong.Controllers" }
               );
            routes.MapRoute(
                   name: "congcu",
                   url: "cong-cu",
                   defaults: new { controller = "Congcu", action = "Index", id = UrlParameter.Optional },
                   namespaces: new[] { "Doandinhduong.Controllers" }
               );
           
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Doandinhduong.Controllers" }
            );
        }
    }
}