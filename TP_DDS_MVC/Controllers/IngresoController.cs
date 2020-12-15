using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_DDS_MVC.DAOs;
using TP_DDS_MVC.Helpers.VinculadorEgresoIngreso;
using TP_DDS_MVC.Helpers;
using TP_DDS_MVC.Helpers.DB;
using TP_DDS_MVC.Models.Ingresos;
using TP_DDS_MVC.Models.Entidades;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson;
using TP_DDS_MVC.Models.Proyectos;
using TP_DDS_MVC.Models.Otros;

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
            /* Ingreso ingreso = new Ingreso();
             ingreso.descripcion = ing.descripcion;
             ingreso.monto = ing.monto;
             ingreso.fechaDesde = ing.fechaDesde;
             ingreso.fechaHasta = ing.fechaHasta;*/

            try
            {
                ing.idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
                IngresoDAO.getInstancia().add(ing);
                Mongo.MongoDB.insertarDocumento("Ingreso", "alta", ing.ToBsonDocument());
                return Json(Url.Action("Index", "Home"));
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
            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            ViewBag.egresos = EgresoDAO.getInstancia().getEgresos(idEntidad);
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

        public ActionResult ListIngresos()
        {
            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            List<Ingreso> ingresos = IngresoDAO.getInstancia().getIngresos(idEntidad);
            return View(ingresos);
        }

        public ActionResult DetalleIngreso (int id)
        {
            Ingreso ingreso = IngresoDAO.getInstancia().getIngreso(id);

            return View(ingreso);
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
            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            ViewBag.egresos = EgresoDAO.getInstancia().getEgresosSinVincular();
            ViewBag.ingresos = IngresoDAO.getInstancia().getIngresos(idEntidad);

            return View();
        }

        [HttpPost]
        public ActionResult Vinculador(JsonCriterio criterio)
        {
            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            var entidad = EntidadDAO.getInstancia().getEntidad(idEntidad);
            Vinculador vinculador = new Vinculador();

            if(criterio.idCriterio == 1)
            {
                OVPE ovpe = new OVPE();
                vinculador.AsignarCriterioAlVinculador(ovpe);
                vinculador.ejecutar(entidad);

            }
            if (criterio.idCriterio == 2)
            {
                OVPI ovpi = new OVPI();
                vinculador.AsignarCriterioAlVinculador(ovpi);
                vinculador.ejecutar(entidad);

            }
            if (criterio.idCriterio == 3)
            {
                OF of = new OF();
                vinculador.AsignarCriterioAlVinculador(of);
                vinculador.ejecutar(entidad);

            }

            ViewBag.egresos = EgresoDAO.getInstancia().getEgresos(idEntidad);
            ViewBag.ingresos = IngresoDAO.getInstancia().getIngresos(idEntidad);

            return Json(Url.Action("Index", "Home"));
        }
    }
}
