using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_DDS_MVC.DAOs;

namespace TP_DDS_MVC.Controllers
{
    public class EgresosPresupuestosController : Controller
    {
        // GET: AddEgreso
        public ActionResult Index()
        {
            return View("EgresosPresupuestos");
        }

        public ActionResult EgresosPresupuestos()
        {
            return View("EgresosPresupuestos");
        }
    }
}