using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_DDS_MVC.DAOs;
using TP_DDS_MVC.Helpers;
using TP_DDS_MVC.Models.Ingresos;
using TP_DDS_MVC.Models.Proyectos;

namespace TP_DDS_MVC.Controllers
{
    public class ProyectoFinanciamientoController : Controller
    {
        // GET: ProyectoFinanciamiento
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProyectoFinanciamiento()
        {
            ViewBag.ingresos = IngresoDAO.getInstancia().getIngresos();            
            ViewBag.presupuestos = PresupuestoDAO.getInstancia().getPresupuestos();

            return View();
        }

        [HttpPost]
        public ActionResult AddProyectoFinanciamiento(ProyectoFinanciamiento proyecto)
        {
            try
            {
                int proyId = ProyectoFinanciamientoDAO.getInstancia().add(proyecto).idProyecyo;
                //falta vincular los ingresos y presupuestos al proyecto que se esta cargando!!
                return Json(Url.Action("Index", "Home"));
            }
            catch (Exception e)
            {
                MyLogger.log(e.Message);
                return View();
            }
        }


    }
}