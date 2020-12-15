using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_DDS_MVC.Models.Otros;
using TP_DDS_MVC.DAOs;
using TP_DDS_MVC.Helpers.Validadores;

namespace TP_DDS_MVC.Controllers
{

    public class UserController : Controller
    {
        public ActionResult Register()
        {
            Usuario usuario = (Usuario)Session["usuario"];

            if(usuario != null && usuario.esAdmin)
            {
                return View();
            }
            else
            {
                return Redirect("/Home/Index");
            }
        }

        [HttpPost]
        public ActionResult Register(string usuario, string password, string esAdmin)
        {
            try
            {
                ValidadorContrasenia validador = new ValidadorContrasenia();
                validador.validarContrasenia(password);

                if (esAdmin == "administrador")
                {
                    UsuarioDAO.getInstancia().add(new Usuario(usuario, true, password, null));
                }
                else
                {
                    UsuarioDAO.getInstancia().add(new Usuario(usuario, false, password, null));
                }

                ViewBag.msg = "El usuario fue creado correctamente";
                return View("Register");
            }
            catch(Exception e)
            {
                ViewBag.errorMsg = e.Message;
                return View("Register");
            }
        }


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string usuario, string password)
        {
            Usuario usuarioEncontrado = UsuarioDAO.getInstancia().getUsuario(usuario, password);

            if (usuarioEncontrado != null)
            {
                Session.Add("usuario", usuarioEncontrado);
                return RedirectToAction("Index", "Home");
            }
            else
            {

                ViewBag.msg = "Nombre de usuario o contraseña incontrrecto";
                return View();

            }

        }

        public ActionResult Logout()
        {

            Session.Clear();
            return Redirect("/User/Login");
        }


        public ActionResult PanelAdmin()
        {

            var usuario = (Usuario)Session["usuario"];

            if (usuario != null && usuario.esAdmin)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult ListarUsuarios()
        {
            var usuario = (Usuario)Session["usuario"];
            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            if (usuario != null && usuario.esAdmin)
            {
                List<Usuario> usuarios = UsuarioDAO.getInstancia().getUsuarios(idEntidad);
                return View(usuarios);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult comprasRevisadas(int id)
        {
            Usuario usr = UsuarioDAO.getInstancia().getUsuario(id);
            return View(usr);
        }

        public ActionResult BandejaDeMensajes(int id)
        {
            Usuario usr = UsuarioDAO.getInstancia().getUsuario(id);
            return View(usr);
        }


    }
}
