using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_DDS_MVC.DAOs;

namespace TP_DDS_MVC.Controllers
{
    public class AutenticacionController : Controller
    {
        // GET: Autenticacion
        public ActionResult Index()
        {
            return View("Autenticacion");
        }

        public ActionResult Autenticacion()
        {
            return View("Autenticacion");
        }
        
    }
}