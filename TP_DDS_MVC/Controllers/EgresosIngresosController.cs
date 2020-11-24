using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP_DDS_MVC.Controllers
{
    public class EgresosIngresosController : Controller
    {
        // GET: EgresosIngresos
        public ActionResult Index()
        {
            return View("EgresosIngresos");
        }

        public ActionResult EgresosIngresos()
        {
            return View("EgresosIngresos");
        }
    }
}