using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_DDS_MVC.DAOs;
using TP_DDS_MVC.Helpers;
using TP_DDS_MVC.Models.Ingresos;
using TP_DDS_MVC.Models.Otros;
using TP_DDS_MVC.Models.Proyectos;
using TP_DDS_MVC.Mongo;
using TP_DDS_MVC.Models.Compras;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Security.Policy;

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
                ProyectoFinanciamientoDAO.getInstancia().add(proyecto);
                return Json(Url.Action("Index", "ProyectoFinanciamiento"));
            }
            catch (Exception e)
            {
                //MyLogger.log(e.Message);
                return View();
            }
        }

        [HttpPost]
        public ActionResult VerOperaciones(string tipoOperacion, string tipoEntidad)
        {
            try
            {
                var docs = Mongo.MongoDB.leerDeMongo();

                String[] listaStrings = new string[docs.Count * 3];
                int i = 0;
                int c = 0;
                int d = 0;

                foreach (var doc in docs)
                {
                    if (tipoOperacion == doc["tipoOperacion"].AsString)
                    {
                        if (tipoEntidad == doc["tipoEntidad"].AsString)
                        {
                            switch (tipoEntidad)
                            {
                                case "Egreso":
                                    listaStrings[i] = doc["idEgreso"].ToInt32().ToString();
                                    i++;
                                    listaStrings[i] = doc["montoTotal"].ToDouble().ToString();
                                    i++;
                                    listaStrings[i] = doc["fechaEgreso"].ToLocalTime().ToString();
                                    i++;
                                    c = 3;
                                    d++;
                                    break;
                                case "Presupuesto":
                                    listaStrings[i] = doc["idPrestadorDeServicios"].ToInt32().ToString();
                                    i++;
                                    listaStrings[i] = doc["montoTotal"].ToDouble().ToString();
                                    i++;
                                    c = 2;
                                    d++;
                                    break;
                                case "Ingreso":
                                    listaStrings[i] = doc["idIngreso"].ToInt32().ToString();
                                    i++; 
                                    listaStrings[i] = doc["descripcion"].AsString;
                                    i++;
                                    listaStrings[i] = doc["monto"].ToDouble().ToString();
                                    i++;
                                    c = 3;
                                    d++;
                                    break;
                                case "Compra":
                                    listaStrings[i] = doc["idCompra"].ToInt32().ToString();
                                    i++;
                                    listaStrings[i] = doc["descripcion"].AsString;
                                    i++;
                                    c = 2;
                                    d++;
                                    break;
                                default:
                                    
                                    break;
                            }
                        }
                    }
                }

                ViewBag.listaStrings = listaStrings;
                ViewBag.c = c;
                ViewBag.d = d;

                return View("ListOperaciones");
            }
            catch (Exception e)
            {
                MyLogger.log(e.Message);
                return View();
            }

        }

        public ActionResult VerOperaciones()
        {
            
            return View();
        }

        public ActionResult ListOperaciones()
        {
            return View();
        }
        /*
        [HttpPost]
        public ActionResult ListOperaciones()
        {
            try
            {
                return RedirectToAction("VerOperaciones");
            }
            catch (Exception e)
            {
                //MyLogger.log(e.Message);
                return View();
            }
        }
        */
    }
}