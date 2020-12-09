using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_DDS_MVC.DAOs;
using TP_DDS_MVC.Helpers.VinculadorEgresoIngreso;
using TP_DDS_MVC.Helpers;
using TP_DDS_MVC.Models.Ingresos;
using TP_DDS_MVC.Models.Entidades;
using Newtonsoft.Json;

namespace TP_DDS_MVC.Controllers
{
    public class IngresoController : Controller
    {


        public ActionResult AddIngreso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddIngreso(Ingreso ing)
        {
            try
            {
                IngresoDAO.getInstancia().add(ing);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                MyLogger.log(e.Message);
                return View();
            }
        }






        // GET: Ingreso
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ingreso/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ingreso/Create
        public ActionResult Create()
        {
            ViewBag.egresos = EgresoDAO.getInstancia().getEgresos();
            return View();
        }

        // POST: Ingreso/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ingreso/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ingreso/Edit/5
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

        // GET: Ingreso/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ingreso/Delete/5
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

        public ActionResult Vinculador()
        {
            ViewBag.egresos = EgresoDAO.getInstancia().getEgresos();
            ViewBag.ingresos = IngresoDAO.getInstancia().getIngresos();

            return View();
        }

        [HttpPost]
        public ActionResult Vinculador(JsonCriterio criterio)
        {
            var entidad = EntidadDAO.getInstancia().getEntidad(1);
            Vinculador vinculador = new Vinculador();

            if(criterio.idCriterio == 1)
            {
                OVPE ovpe = new OVPE();
                vinculador.AsignarCriterioAlVinculador(ovpe);
                vinculador.ejecutar(entidad);
            }


            ViewBag.egresos = EgresoDAO.getInstancia().getEgresos();
            ViewBag.ingresos = IngresoDAO.getInstancia().getIngresos();

            return View();
        }
    }
}
