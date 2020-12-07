using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_DDS_MVC.DAOs;
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
<<<<<<< HEAD
            //public Ingreso(string descripcion, float montoTotal, List<Egreso> egresosAsociados)
            /*ViewBag.docsComerciales = DocumentoComercialDAO.getInstancia().getDocumentosComerciales();
            ViewBag.mediosDePago = MedioDePagoDAO.getInstancia().getMediosDePago();
            ViewBag.proveedores = PrestadorDeServiciosDAO.getInstancia().getPrestadoresDeServicios();*/

            ViewBag.ingresos = IngresoDAO.getInstancia().getIngresos();
=======
            
            ViewBag.Ingreso = IngresoDAO.getInstancia().getIngresos();
>>>>>>> f5dc8776958d40bd02c82a620272a89a453b6de8

            return View();
        }

        [HttpPost]
        public ActionResult AddProyectoFinanciamiento(ProyectoFinanciamiento proyecto)
        {
            try
            {
                ProyectoFinanciamientoDAO.getInstancia().add(proyecto);
                return Json(Url.Action("Index", "ProyectoFinanciamiento"));
            }
            catch (Exception e)
            {
                MyLogger.log(e.Message);
                return View();
            }
        }


    }
}