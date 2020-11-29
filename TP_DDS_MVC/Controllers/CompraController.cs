using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_DDS_MVC.DAOs;
using TP_DDS.Model.Compras;

namespace TP_DDS_MVC.Controllers
{
    public class CompraController : Controller
    {
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
        public ActionResult AddCompra(int cant) // video 1:30:00
        {
            try
            {
                // Compra compra = new Compra(int cantMinimaPresupuestos, float criterio, Egreso egreso, List<Presupuesto> presupuestos, List<Usuario> revisores)
                // ViewBag.compra = CompraDAO.getInstancia().add();
                int cantidad = cant;
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AddEgreso()
        {
            List<MedioDePago> mediosPago = MedioDePagoDAO.getInstancia().getMediosDePago();
            ViewBag.mediosPago = mediosPago;
            return View();
        }

        // POST: Egreso/Create
        [HttpPost]
        public ActionResult AddEgreso(int hola) 
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

        public ActionResult AddMedioPago()
        {
           

            return View();
        }

        // POST: Egreso/Create
        [HttpPost]
        public ActionResult AddMedioPago(int hola)
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
