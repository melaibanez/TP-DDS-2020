using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Quartz.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TP_DDS.Model.Compras;
using TP_DDS.Model.Entidades;
using TP_DDS_MVC.DAOs;
using TP_DDS_MVC.Helpers;

namespace TP_DDS_MVC.Controllers
{
    public class CompraController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        ///////////////////////////////////////////////
        ///         Prestador de servicios          ///
        ///////////////////////////////////////////////
        
        public JsonResult PrestadorDeServicios()
        {
            List<PrestadorDeServicios> PDSs = PrestadorDeServiciosDAO.getInstancia().getPrestadoresDeServicios();
            return Json(JsonConvert.SerializeObject(PDSs));
        }

        public ActionResult AddPrestadorDeServicios()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPrestadorDeServicios(PrestadorDeServicios PDS)
        {
            try
            {
                PDS.direccionPostal = new DireccionPostal();
                PrestadorDeServiciosDAO.getInstancia().add(PDS);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                MyLogger.log(e.Message);
                return View();
            }
        }


        ///////////////////////////////////////////////
        ///             Medio de Pago               ///
        ///////////////////////////////////////////////
        public ActionResult AddMedioDePago()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMedioDePago(MedioDePago MDP)
        {
            try
            {
                MedioDePagoDAO.getInstancia().add(MDP);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                MyLogger.log(e.Message);
                return View();
            }
        }

        ///////////////////////////////////////////////
        ///              Presupuesto                ///
        ///////////////////////////////////////////////
        public ActionResult AddPresupuesto()
        {
            ViewBag.mediosDePago = MedioDePagoDAO.getInstancia().getMediosDePago();
            ViewBag.proveedores = PrestadorDeServiciosDAO.getInstancia().getPrestadoresDeServicios();
            return View();
        }

        [HttpPost]
        public ActionResult AddPresupuesto(Presupuesto pres)
        {
            try
            {
                PresupuestoDAO.getInstancia().add(pres);
                return Json(Url.Action("Index", "Compra"));
            }
            catch (Exception e)
            {
                MyLogger.log(e.Message);
                return View();
            }
        }

        ///////////////////////////////////////////////
        ///              Egreso                     ///
        ///////////////////////////////////////////////
        public ActionResult AddEgreso()
        {
            ViewBag.docsComerciales = DocumentoComercialDAO.getInstancia().getDocumentosComerciales();
            ViewBag.mediosDePago = MedioDePagoDAO.getInstancia().getMediosDePago();
            ViewBag.proveedores = PrestadorDeServiciosDAO.getInstancia().getPrestadoresDeServicios();
            return View();
        }

        [HttpPost]
        public ActionResult AddEgreso(JsonEgreso req)
        {
            
            try
            {
                int idEgreso = EgresoDAO.getInstancia().add(req.model).idEgreso;
                foreach (string nroId in req.docsComerciales)
                {
                    DocumentoComercialDAO.getInstancia().setEgresoId(idEgreso, nroId);
                }

                return Json(Url.Action("Index", "Compra"));
            }
            catch (Exception e)
            {
                MyLogger.log(e.Message);
                return View();
            }
        }

        public class JsonEgreso
        {
            public Egreso model { get; set; }
            public string[] docsComerciales { get; set; }
        }


        // GET: Compra
        public ActionResult ListCompras()
        {
            ViewBag.compras = CompraDAO.getInstancia().getCompras();
            return View();
        }


        // GET: Presupuestos
        public ActionResult Presupuesto()
        {
            return View();
        }

        // Get: prestadorDeServicios

        


        // GET: Compra/Details/5
        public ActionResult DetailCompra(int id)
        {
            ViewBag.compra = CompraDAO.getInstancia().getCompra(id);
            return View();
        }

        // GET: Compra/Create
        public ActionResult AddCompra()
        {
            
            return View();
        }

        // POST: Compra/Create
        [HttpPost]
        public ActionResult AddCompra(FormCollection collection) // video 1:30:00
        {
            try
            {
               // Compra compra = new Compra(int cantMinimaPresupuestos, float criterio, Egreso egreso, List<Presupuesto> presupuestos, List<Usuario> revisores)
               // ViewBag.compra = CompraDAO.getInstancia().add();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compra/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Compra/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compra/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Compra/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
