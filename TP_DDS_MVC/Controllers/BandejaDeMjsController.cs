using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP_DDS_MVC.Controllers
{
    public class BandejaDeMjsController : Controller
    {
        // GET: BandejaDeMjs
        public ActionResult Index()
        {
            return View("BandejaDeMjs");
        }

        public ActionResult BandejaDeMjs()
        {
            return View("BandejaDeMjs");
        }
       
    }
}