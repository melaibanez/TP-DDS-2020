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
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Models.Entidades;
using TP_DDS_MVC.DAOs;
using TP_DDS_MVC.Helpers;
using TP_DDS_MVC.Models.Otros;

namespace TP_DDS_MVC.Controllers
{
    [CustomAuthenticationFilter]
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
                PDS.direccionPostal.validarDireccion();
                PrestadorDeServiciosDAO.getInstancia().add(PDS);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                MyLogger.log(e.Message);
                ViewBag.errorMsg = e.Message;
                return View();
            }
        }

        public ActionResult ListPrestadorDeServicios()
        {
            List<PrestadorDeServicios> pres = PrestadorDeServiciosDAO.getInstancia().getPrestadoresDeServicios();
            return View(pres);
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
                return RedirectToAction("Index", "Home");
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


        public ActionResult ListPresupuestos()
        {
            List<Presupuesto> pres = PresupuestoDAO.getInstancia().getPresupuestos();
            return View(pres);
        }

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
                return Json(Url.Action("Index", "Home"));
            }
            catch (Exception e)
            {
                MyLogger.log(e.Message);
                return View();
            }
        }

        public ActionResult DetallePresupuesto(int id)
        {
            Presupuesto pres = PresupuestoDAO.getInstancia().getPresupuesto(id);
            return View(pres);
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
                int idEgreso = EgresoDAO.getInstancia().add(req.egreso).idEgreso;
                foreach (string nroId in req.docsComerciales)
                {
                    DocumentoComercialDAO.getInstancia().setEgresoId(idEgreso, nroId);
                }

                return Json(Url.Action("Index", "Home"));
            }
            catch (Exception e)
            {
                ViewBag.docsComerciales = DocumentoComercialDAO.getInstancia().getDocumentosComerciales();
                ViewBag.mediosDePago = MedioDePagoDAO.getInstancia().getMediosDePago();
                ViewBag.proveedores = PrestadorDeServiciosDAO.getInstancia().getPrestadoresDeServicios();
                MyLogger.log(e.Message);
                ViewBag.errorMsg = e.Message;
                return View();
            }
        }


        ///////////////////////////////////////////////
        ///              Compra                     ///
        ///////////////////////////////////////////////

        // GET: Compras
        public ActionResult ListCompras()
        {
            //List<Compra> compras = CompraDAO.getInstancia().getCompras();
            Egreso e = new Egreso();
            e.montoTotal = 214254;
            List<Compra> compras = new List<Compra>() { new Compra("La compra del mes", 5, 235,e,new List<Presupuesto>(),null), new Compra("Otra compra", 12, 235, e, new List<Presupuesto>(), null), new Compra("La ultima compra", 20, 125, e, new List<Presupuesto>(), null) };
            return View(compras);
        }

        public ActionResult AddCompra()
        {
            ViewBag.mediosDePago = MedioDePagoDAO.getInstancia().getMediosDePago();
            ViewBag.proveedores = PrestadorDeServiciosDAO.getInstancia().getPrestadoresDeServicios();
            ViewBag.usuarios = UsuarioDAO.getInstancia().getUsuarios();
            return View();
        }

        [HttpPost]
        public ActionResult AddCompra(JsonCompra req)
        {

            try
            {
                foreach (int idUsuario in req.revisores)
                {
                    req.compra.revisores.Add(UsuarioDAO.getInstancia().getUsuario(idUsuario));
                }

                Compra compra = CompraDAO.getInstancia().add(req.compra);

                return Json(Url.Action("Index", "Home"));
            }
            catch (Exception e)
            {
                ViewBag.mediosDePago = MedioDePagoDAO.getInstancia().getMediosDePago();
                ViewBag.proveedores = PrestadorDeServiciosDAO.getInstancia().getPrestadoresDeServicios();
                ViewBag.usuarios = UsuarioDAO.getInstancia().getUsuarios();
                MyLogger.log(e.Message);
                ViewBag.errorMsg = e.Message;
                return View();
            }
        }








        // GET: Presupuestos
        public ActionResult Presupuesto()
        {
            return View();
        }


        // GET: Compra/Details/5
        public ActionResult DetailCompra(int id)
        {
            ViewBag.compra = CompraDAO.getInstancia().getCompra(id);
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
