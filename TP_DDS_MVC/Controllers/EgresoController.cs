using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_DDS_MVC.DAOs;

namespace TP_DDS_MVC.Controllers
{
    public class EgresoController : Controller
    {
        // GET: AddEgreso
        public ActionResult Index()
        {
            return View("AddEgreso");
        }

        public ActionResult AddEgreso()
        {
            return View("AddEgreso");
        }
        
    }
}