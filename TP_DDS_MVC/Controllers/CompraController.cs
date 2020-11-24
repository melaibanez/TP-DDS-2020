using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_DDS_MVC.DAOs;

namespace TP_DDS_MVC.Controllers
{
    public class CompraController : Controller
    {
        // GET: /compra
        public ActionResult ListCompras()
        {
            ViewBag.compras = CompraDAO.getInstancia().getCompras();
            return View();
        }

        // GET: /compra/add
        public ActionResult AddCompra()
        {
            return View();
        }

        // POST: compra/add
        [HttpPost]
        public ActionResult AddCompra(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("ListCompras");
            }
            catch
            {
                return View();
            }
        }




        // GET: presupuesto
        public ActionResult ListPresupuestos()
        {
            return View();
        }

        // GET: Compra/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.compra = CompraDAO.getInstancia().getCompra(id);
            return View();
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
