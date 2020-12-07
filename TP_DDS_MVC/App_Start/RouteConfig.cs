using System;
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
                name: "Compras index",
                url: "compra",
                defaults: new { controller = "Compra", action = "Index" }
            );

            routes.MapRoute(
                name: "ListCompras",
                url: "compra/list",
                defaults: new { controller = "Compra", action = "ListCompras" }
            );

            routes.MapRoute(
                name: "Add Compra",
                url: "compra/add",
                defaults: new { controller = "Compra", action = "AddCompra" }
            );
                       
            routes.MapRoute(
                name: "Add Prestador de servicios",
                url: "compra/prestador-de-servicios/add",
                defaults: new { controller = "Compra", action = "AddPrestadorDeServicios" }
            );

            routes.MapRoute(
                name: "List Prestador de servicios",
                url: "compra/prestador-de-servicios",
                defaults: new { controller = "Compra", action = "ListPrestadorDeServicios" }
            );

            routes.MapRoute(
                name: "Add Medio de Pago",
                url: "compra/medio-de-pago/add",
                defaults: new { controller = "Compra", action = "AddMedioDePago" }
            );

            routes.MapRoute(
                name: "Add Presupuesto",
                url: "compra/presupuesto/add",
                defaults: new { controller = "Compra", action = "AddPresupuesto" }
            );

            routes.MapRoute(
                name: "List presupuesto",
                url: "compra/presupuesto",
                defaults: new { controller = "Compra", action = "ListPresupuestos", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Detalle presupuesto",
                url: "compra/presupuesto/{id}",
                defaults: new { controller = "Compra", action = "DetallePresupuesto", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Add Egreso",
                url: "compra/egreso/add",
                defaults: new { controller = "Compra", action = "AddEgreso" }
            );

            routes.MapRoute(
                name: "Add Entidad",
                url: "entidad/entidad-juridica/add",
                defaults: new { controller = "Entidad", action = "AddEntidadJuridica" }
            );

            routes.MapRoute(
                name: "Logout",
                url: "usuario/logout",
                defaults: new { controller = "User", action = "Logout" }
            );

            routes.MapRoute(
                name: "Bandeja de mensajes",
                url: "usuario/mensajes",
                defaults: new { controller = "User", action = "BandejaDeMensajes" }
            );

            routes.MapRoute(
                 name: "Panel Admin",
                 url: "usuario/admin",
                 defaults: new { controller = "User", action = "PanelAdmin" }
             );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
