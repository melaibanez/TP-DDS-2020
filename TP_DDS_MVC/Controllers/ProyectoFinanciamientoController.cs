using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_DDS_MVC.DAOs;
using TP_DDS_MVC.Models.Ingresos;

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
            //public Ingreso(string descripcion, float montoTotal, List<Egreso> egresosAsociados)
            /*ViewBag.docsComerciales = DocumentoComercialDAO.getInstancia().getDocumentosComerciales();
            ViewBag.mediosDePago = MedioDePagoDAO.getInstancia().getMediosDePago();
            ViewBag.proveedores = PrestadorDeServiciosDAO.getInstancia().getPrestadoresDeServicios();*/

            ViewBag.ingresos = IngresoDAO.getInstancia().getIngresos();

            /*Ingreso ingreso1 = new Ingreso("hola1", 1, null);
            Ingreso ingreso2 = new Ingreso("hola2", 2, null);
            Ingreso[] ingresos = { ingreso1, ingreso2 };
            ViewBag.Ingreso = ingresos;*/
            return View();
        }
    }
}