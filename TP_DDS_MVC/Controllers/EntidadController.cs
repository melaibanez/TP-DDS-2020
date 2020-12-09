using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TP_DDS_MVC.DAOs;
using TP_DDS_MVC.Helpers;
using TP_DDS_MVC.Helpers.Validadores;
using TP_DDS_MVC.Models.Entidades;
using TP_DDS_MVC.Models.Otros;

namespace TP_DDS_MVC.Controllers
{
    [EntityFilter]
    public class EntidadController : Controller
    {

        public ActionResult MenuCargarEntidad()
        {
            return View();
        }

        // GET: add entidad juridica
        public ActionResult AddEntidadJuridica(int cargarBase)
        {
            ViewBag.cargarBase = cargarBase;
            ViewBag.paises = PaisDAO.getInstancia().getPaises();
            ViewBag.provincias = ProvinciaDAO.getInstancia().getProvincias();
            ViewBag.ciudades = CiudadDAO.getInstancia().getCiudades();
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult AddEntidadJuridica(JsonEntidad req)
        {
            try
            {
                req.entidad.direccionPostal.validarDireccion();
                if (req.tipoOrganizacion == "OSC"){
                    req.entidad.tipoOrganizacion = new OSC(req.actividad);
                }
                else if (req.tipoOrganizacion == "Empresa"){
                    req.entidad.tipoOrganizacion = CategorizadorOrg.categorizar(new Empresa(req.actividad,req.sector ,req.promVentas, req.cantPersonal));
                }
                else{
                    throw new Exception("Tipo de organizacion no valido");
                }
                EntidadJuridica nuevaEnt = (EntidadJuridica)EntidadDAO.getInstancia().add(req.entidad);
                if (req.cargarBase == 1) {
                    
                    return Json(Url.Action("AddEntidadBaseAJuridica", "Entidad"));
                }

                Usuario user = (Usuario)Session["usuario"];
                Usuario updatedUser = UsuarioDAO.getInstancia().setIdEntidad(nuevaEnt.idEntidad, user.idUsuario);
                Session.Remove("usuario");
                Session.Add("usuario", updatedUser);
                return Json(Url.Action("PanelAdmin", "User"));
            }
            catch (Exception e)
            {
                ViewBag.paises = PaisDAO.getInstancia().getPaises();
                ViewBag.provincias = ProvinciaDAO.getInstancia().getProvincias();
                ViewBag.ciudades = CiudadDAO.getInstancia().getCiudades();
                ViewBag.errorMsg = e.Message;
                return View();
            }
        }


        public ActionResult AddEntidadBaseAJuridica(int conJuridica)
        {
            ViewBag.conJuridica = conJuridica;
            ViewBag.entidades = EntidadDAO.getInstancia().getEntidadesJuridicas();
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult AddEntidadBaseAJuridica(JsonEntidadBase req)
        {
            try
            {
                if (req.tipoOrganizacion == "OSC"){
                    req.entidad.tipoOrganizacion = new OSC(req.actividad);
                }
                else if (req.tipoOrganizacion == "Empresa"){
                    req.entidad.tipoOrganizacion = CategorizadorOrg.categorizar(new Empresa(req.actividad, req.sector, req.promVentas, req.cantPersonal));
                }
                else{
                    throw new Exception("Tipo de organizacion no valido");
                }

                EntidadBase nuevaEnt = (EntidadBase)EntidadDAO.getInstancia().add(req.entidad);
                Usuario user = (Usuario)Session["usuario"];
                Usuario updatedUser = UsuarioDAO.getInstancia().setIdEntidad(nuevaEnt.idEntidad, user.idUsuario);
                Session.Remove("usuario");
                Session.Add("usuario", updatedUser);
                return Json(Url.Action("PanelAdmin", "User"));
            }
            catch (Exception e)
            {
                ViewBag.entidades = EntidadDAO.getInstancia().getEntidadesJuridicas();
                ViewBag.errorMsg = e.Message;
                return View();
            }
        }

        // GET: Entidad/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        
    }
}
