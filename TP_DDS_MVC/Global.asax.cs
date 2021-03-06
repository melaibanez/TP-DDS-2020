using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TP_DDS_MVC.DAOs;
using TP_DDS_MVC.Helpers.DB;
using TP_DDS_MVC.Helpers.Scheduler;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Models.Entidades;
using TP_DDS_MVC.Models.Otros;

namespace TP_DDS_MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {

        public static List<Compra> comprasNoValidadas = new List<Compra>();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            PersistenciaMedioDePago.persistirDatosMedioDePago();
            PersistenciaMoneda.persistirMonedas();
            PersistenciaDireccionPostal.persistirDatosAPI();

            //MyScheduler sched = MyScheduler.getInstance();
            //sched.run();
            //sched.agregarJobValidador();
        }
    }
}
