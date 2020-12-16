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
using Antlr.Runtime.Tree;

namespace TP_DDS_MVC.Controllers
{
    public class ProyectoFinanciamientoController : Controller
    {

        public ActionResult AddProyectoFinanciamiento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProyectoFinanciamiento(ProyectoFinanciamiento proyecto)
        {
            try
            {
                if (proyecto.propuesta != null && proyecto.cantidadPresupuestos != 0 && proyecto.limiteErogacion != 0 && proyecto.fechaCierre != null)
                {
                    proyecto.idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
                    proyecto.director = (Usuario)Session["usuario"];
                    ProyectoFinanciamientoDAO.getInstancia().add(proyecto);
                    return Json(Url.Action("Index", "Home"));
                } else
                {
                    throw new Exception("Debe completar todos los campos para continuar");
                }
            }
            catch (Exception e)
            {
                MyLogger.log(e.Message);
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


        public ActionResult ListProyectos()
        {
            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            List<ProyectoFinanciamiento> listaProyectos = ProyectoFinanciamientoDAO.getInstancia().getProyectos(idEntidad);
            return View(listaProyectos);
        }

        public ActionResult DeleteProyecto(int id)
        {
            try
            {
                ProyectoFinanciamientoDAO.getInstancia().deleteProyecto(id);
                return View("ListProyectos");
            }
            catch (Exception e)
            {
                MyLogger.log(e.Message);
                ViewBag.errorMsg = e.Message;
                return View("ListProyectos");
            }
        }

        public ActionResult DetalleProyectos(int id)
        {
            try
            {
                ProyectoFinanciamiento proyecto = ProyectoFinanciamientoDAO.getInstancia().getProyecto(id);
                return View(proyecto);
            }
            catch (Exception e)
            {
                MyLogger.log(e.Message);
                ViewBag.errorMsg = e.Message;
                return View("ListProyectos");
            }
        }

        public ActionResult AsociarEgreso(int idProyecto)
        {
            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            ViewBag.listaEgresos = CompraDAO.getInstancia().getCompras(idEntidad);
            ViewBag.idProyecto = idProyecto;
            return View();
        }

        [HttpPost]
        public ActionResult AsociarEgreso(int idCompra, int idProyecto)
        {
            try
            {
                if(idCompra == 0)
                {
                    throw new Exception("Seleccione una compra");
                }
                CompraDAO.getInstancia().asociarCompraAProyecto(idProyecto, idCompra);
                return RedirectToAction("DetalleProyectos", "ProyectoFinanciamiento", new {id=idProyecto });
            }
            catch (Exception e)
            {
                int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
                MyLogger.log(e.Message);
                ViewBag.idProyecto = idProyecto;
                ViewBag.listaEgresos = CompraDAO.getInstancia().getCompras(idEntidad);
                ViewBag.errorMsg = e.Message;
                return View();
            }
        }


        public ActionResult AsociarIngreso(int idProyecto)
        {
            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            ViewBag.ingresos = IngresoDAO.getInstancia().getIngresos(idEntidad);
            ViewBag.idProyecto = idProyecto;
            return View();
        }

        [HttpPost]
        public ActionResult AsociarIngreso(int idIngreso, int idProyecto)
        {
            try
            {
                if (idIngreso == 0)
                {
                    throw new Exception("Seleccione un ingreso");
                }
                IngresoDAO.getInstancia().asociarIngresoAProyecto(idProyecto, idIngreso);
                return RedirectToAction("DetalleProyectos", "ProyectoFinanciamiento", new { id = idProyecto });
            }
            catch (Exception e)
            {
                int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
                MyLogger.log(e.Message);
                ViewBag.ingresos = IngresoDAO.getInstancia().getIngresos(idEntidad);
                ViewBag.idProyecto = idProyecto;
                ViewBag.errorMsg = e.Message;
                return View();
            }
        }




        //[HttpPost]
        //public ActionResult Holaa(string[] egresosAsociados)
        //{
        //    try
        //    {
        //        int propuesta2 = Int32.Parse(Request.Form["idProyecto"]);
        //        //string name = Request["propuesta2"];

        //        //string id = Request.Params.Cast<string>().Where(p => !p.StartsWith("egresosAsociados")).First();
        //        //int idProyecto = Int32.Parse(name);
        //        List<Compra> listaEgresos = CompraDAO.getInstancia().getCompras();
        //        ProyectoFinanciamiento proyecto = ProyectoFinanciamientoDAO.getInstancia().getProyecto(propuesta2);
        //        int i = 0;
        //        if (proyecto.compras == null)
        //        {
        //            proyecto.compras = new List<Compra>();
        //        }

        //        foreach (string egreso in egresosAsociados)
        //        {
        //            if (egreso == "on")
        //            {
        //                //proyecto.compras.
        //                proyecto.compras.Add(listaEgresos[i]);
        //            }

        //            i++;

        //        }

        //        return View();
        //    }
        //    catch (Exception e)
        //    {
        //        int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
        //        MyLogger.log(e.Message);
        //        ViewBag.errorMsg = e.Message;
        //        return View("AsociarEgreso");
        //    }
        //}

        //public ActionResult AsociarIngreso(int id)
        //{
        //    try
        //    {
        //        ProyectoFinanciamiento proyecto = ProyectoFinanciamientoDAO.getInstancia().getProyecto(id);
        //        return View(proyecto);
        //    }
        //    catch (Exception e)
        //    {
        //        MyLogger.log(e.Message);
        //        ViewBag.errorMsg = e.Message;
        //        return View("DetalleProyectos");
        //    }
        //}

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