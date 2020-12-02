using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_DDS_MVC.Models.Otros;
using TP_DDS_MVC.DAOs;

namespace TP_DDS_MVC.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Register()
        {

            var usuario = Session["usuario"];

            if (usuario != null)
            {
                return Redirect("/Home/Index");
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult Login(string usuario, string password)
        {

            var usuarioEncontrado = UsuarioDAO.getInstancia().getUsuario(usuario, password);

            if (usuarioEncontrado != null)
            {

                Session.Add("usuario", new Usuario(usuario, true, password, null));
                return Redirect("/Home/Index");

            }
            else
            {

                ViewBag.msg = "El usuario no existe";
                return View("Register");

            }

        }

        [HttpPost]

        public ActionResult Register(string usuario, string password, string esAdmin)
        {

            UsuarioDAO.getInstancia().add(new Usuario(usuario,true, password, null));
            ViewBag.msg = "El usuario fue creado correctamente";
            return View("Register");

        }

        public ActionResult Logout()
        {

            Session.Clear();
            return Redirect("/Home/Index");

        }


        public ActionResult panelAdmin()
        {

            var usuario = (Usuario)Session["usuario"];

            if (usuario != null)
            {

                ViewBag.usuario = usuario;
                return View("Private");

            }
            else
            {
                return View("Index");
            }

        }
    }
}
