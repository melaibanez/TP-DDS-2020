using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_DDS_MVC.Helpers;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.DAOs;
using TP_DDS_MVC.Models.Otros;

namespace TP_DDS_MVC.Controllers
{
    [CustomAuthenticationFilter]
    public class EntidadController : Controller
    {
        // GET: Panel Entidad
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddEntidadJuridica()
        {
           //Si el usuario loggeado no es admin o si es admin pero ya tiene una entidad asociada se le deniega el acceso
            return View();
        }


        // GET: Entidad/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Entidad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entidad/Create
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

        public ActionResult criterios()
        {
            ViewBag.criterios = CriterioDAO.getInstancia().getCriterios();
            return View();
        }

        [HttpPost]
        public ActionResult criterios(string criterio, int? idPadre, string categorias)
        {

            //int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            int idEntidad = 1;

           

            string[] categoriasSeparadas = categorias.Split(',');

            int cant = categorias.Split(',').ToList().Count();

            List<Categoria> categoriasNuevas = new List<Categoria>();

            for (int i = 0; i < cant; i++)
            {
                Categoria categoriaNueva = new Categoria(categoriasSeparadas[i]);
                categoriasNuevas.Add(categoriaNueva);
            }

            Criterio criterioNuevo = new Criterio(criterio, idEntidad, idPadre, categoriasNuevas);

            var criterio1 = CriterioDAO.getInstancia().add(criterioNuevo);



            return RedirectToAction("Index","Home");
        }


        // GET: Entidad/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Entidad/Edit/5
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

        // GET: Entidad/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Entidad/Delete/5
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
