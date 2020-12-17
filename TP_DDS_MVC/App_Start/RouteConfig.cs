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

            /// Proyecto
            /// 
            routes.MapRoute(
                name: "List Proyecto",
                url: "proyecto",
                defaults: new { controller = "ProyectoFinanciamiento", action = "ListProyectos" }
            );

            routes.MapRoute(
                name: "Add Proyecto",
                url: "proyecto/add",
                defaults: new { controller = "ProyectoFinanciamiento", action = "AddProyectoFinanciamiento" }
            );

            routes.MapRoute(
                name: "Detalle Proyecto",
                url: "proyecto/{id}",
                defaults: new { controller = "ProyectoFinanciamiento", action = "DetalleProyectos", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Bitácora de Operaciones",
                url: "bitacora",
                defaults: new { controller = "ProyectoFinanciamiento", action = "VerOperaciones" }
            );

            /// Compra/egreso 
            routes.MapRoute(
                name: "ListCompras",
                url: "compra",
                defaults: new { controller = "Compra", action = "ListCompras" }
            );

            routes.MapRoute(
                name: "Add Compra",
                url: "compra/add",
                defaults: new { controller = "Compra", action = "AddCompra" }
            );

            routes.MapRoute(
               name: "Edit Compra",
               url: "compra/edit/{id}",
               defaults: new { controller = "Compra", action = "EditCompra", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Detalle Compra",
                url: "compra/{id}",
                defaults: new { controller = "Compra", action = "DetalleCompra", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "delete Compra",
                url: "compra/delete/{id}",
                defaults: new { controller = "Compra", action = "DeleteCompra", id = UrlParameter.Optional }
            );


            /// prestador de servicios

            routes.MapRoute(
                name: "List Prestador de servicios",
                url: "prestador-de-servicios",
                defaults: new { controller = "Compra", action = "ListPrestadorDeServicios" }
            );

            routes.MapRoute(
                name: "Add Prestador de servicios",
                url: "prestador-de-servicios/add",
                defaults: new { controller = "Compra", action = "AddPrestadorDeServicios" }
            );

            routes.MapRoute(
                name: "Editar Prestador de servicios",
                url: "prestador-de-servicios/edit/{id}",
                defaults: new { controller = "Compra", action = "EditPrestadorDeServicios", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Detalle Prestador de servicios",
                url: "prestador-de-servicios/{id}",
                defaults: new { controller = "Compra", action = "DetallePrestadorDeServicios", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "delete Prestador de servicios",
                url: "prestador-de-servicios/delete/{id}",
                defaults: new { controller = "Compra", action = "DeletePrestadorDeServicios", id = UrlParameter.Optional }
            );

            ///medio de pago

            routes.MapRoute(
                name: "List Medio de Pago",
                url: "medio-de-pago",
                defaults: new { controller = "Compra", action = "ListMedioDePago" }
            );

            routes.MapRoute(
                name: "Add Medio de Pago",
                url: "medio-de-pago/add",
                defaults: new { controller = "Compra", action = "AddMedioDePago" }
            );

            routes.MapRoute(
                name: "Editar Medio de Pago",
                url: "medio-de-pago/edit/{id}",
                defaults: new { controller = "Compra", action = "EditMedioDePago", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Detalle Medio de Pago",
                url: "medio-de-pago/{id}",
                defaults: new { controller = "Compra", action = "DetalleMedioDePago", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "delete medio de pago",
                url: "medio-de-pago/delete/{id}",
                defaults: new { controller = "Compra", action = "DeleteMedioDePago", id = UrlParameter.Optional }
            );


            ///presupuesto 

            routes.MapRoute(
                name: "List presupuesto",
                url: "presupuesto",
                defaults: new { controller = "Compra", action = "ListPresupuestos", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Add Presupuesto",
                url: "presupuesto/add",
                defaults: new { controller = "Compra", action = "AddPresupuesto" }
            );

            routes.MapRoute(
                name: "Editar presupuesto",
                url: "presupuesto/edit/{id}",
                defaults: new { controller = "Compra", action = "EditPresupuesto", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Detalle presupuesto",
                url: "presupuesto/{id}",
                defaults: new { controller = "Compra", action = "DetallePresupuesto", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "delete presupuesto",
                url: "presupuesto/delete/{id}",
                defaults: new { controller = "Compra", action = "DeletePresupuesto", id = UrlParameter.Optional }
            );

            /////egreso

            //routes.MapRoute(
            //    name: "Add Egreso",
            //    url: "compra/egreso/add",
            //    defaults: new { controller = "Compra", action = "AddEgreso" }
            //);


            /// ingresos

            routes.MapRoute(
                name: "List ingresos",
                url: "ingreso",
                defaults: new { controller = "Ingreso", action = "ListIngresos"}
            );

            routes.MapRoute(
                name: "Add Ingreso",
                url: "ingreso/add",
                defaults: new { controller = "Ingreso", action = "AddIngreso" }
            );

            routes.MapRoute(
                name: "Detalle Ingreso",
                url: "ingreso/{id}",
                defaults: new { controller = "Ingreso", action = "DetalleIngreso", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Editar Ingreso",
                url: "ingreso/edit/{id}",
                defaults: new { controller = "Ingreso", action = "EditIngreso", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "delete ingreso",
                url: "ingreso/delete/{id}",
                defaults: new { controller = "Compra", action = "DeleteIngreso", id = UrlParameter.Optional }
            );


            /// cargar entidad

            routes.MapRoute(
                name: "Menu Cargar Entidad",
                url: "entidad",
                defaults: new { controller = "Entidad", action = "MenuCargarEntidad" }
            );

            routes.MapRoute(
                name: "Add Entidad Juridica",
                url: "entidad/entidad-juridica/add",
                defaults: new { controller = "Entidad", action = "AddEntidadJuridica" }
            );

            routes.MapRoute(
                name: "Add Entidad Base",
                url: "entidad/entidad-base/add",
                defaults: new { controller = "Entidad", action = "AddEntidadBaseAJuridica" }
            );

            routes.MapRoute(
               name: "Add criterio",
               url: "criterio",
               defaults: new { controller = "Compra", action = "criterios" }
           );


            routes.MapRoute(
              name: "Operaciones",
              url: "bitacora",
              defaults: new { controller = "ProyectoFinanciamiento", action = "DefinirOperacion" }
            );


            /// usuario

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
                name: "Registar usuario",
                url: "usuario/registrar",
                defaults: new { controller = "User", action = "Register" }
            );

            routes.MapRoute(
                name: "Listar Usuarios",
                url: "usuario/listaUsuarios",
                defaults: new { controller = "User", action = "ListarUsuarios" }
            );

            routes.MapRoute(
                name: "login",
                url: "usuario/login",
                defaults: new { controller = "User", action = "Login" }
            );

            routes.MapRoute(
                name: "Logout",
                url: "usuario/logout",
                defaults: new { controller = "User", action = "Logout" }
            );

            /// otros

            routes.MapRoute(
                name: "Vinculador",
                url: "vinculador",
                defaults: new { controller = "Ingreso", action = "Vinculador" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
