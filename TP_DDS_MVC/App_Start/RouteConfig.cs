﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TP_DDS_MVC.Controllers;

namespace TP_DDS_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            
            
            routes.MapRoute(
                name: "ListCompras",
                url: "compra",
                defaults: new { controller = "Compra", action = "Presupuestos" }
            );

            routes.MapRoute(
                name: "Add Compra",
                url: "compra/add",
                defaults: new { controller = "Compra", action = "AddCompra" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
