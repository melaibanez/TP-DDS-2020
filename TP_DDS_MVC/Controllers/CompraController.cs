using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Quartz.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Models.Entidades;
using TP_DDS_MVC.DAOs;
using TP_DDS_MVC.Helpers;
using TP_DDS_MVC.Mongo;
using MongoDB.Driver;
using MongoDB.Bson;
using TP_DDS_MVC.Models.Otros;
using System.Net;

namespace TP_DDS_MVC.Controllers
{
    [CustomAuthenticationFilter]
    public class CompraController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        ///////////////////////////////////////////////
        ///         Prestador de servicios          ///
        ///////////////////////////////////////////////

        public ActionResult ListPrestadorDeServicios()
        {
            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            List<PrestadorDeServicios> pres = PrestadorDeServiciosDAO.getInstancia().getPrestadoresDeServicios(idEntidad);
            return View(pres);
        }

        public ActionResult AddPrestadorDeServicios()
        {
            ViewBag.paises = PaisDAO.getInstancia().getPaises();
            ViewBag.provincias = ProvinciaDAO.getInstancia().getProvincias();
            ViewBag.ciudades = CiudadDAO.getInstancia().getCiudades();
            return View();
        }

        [HttpPost]
        public ActionResult AddPrestadorDeServicios(PrestadorDeServicios PDS)
        {
            try
            {
                PDS.idEntidad = ((Usuario)Session["usuario"]).idEntidad;
                PDS.direccionPostal.validarDireccion();
                PrestadorDeServiciosDAO.getInstancia().add(PDS);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ViewBag.paises = PaisDAO.getInstancia().getPaises();
                ViewBag.provincias = ProvinciaDAO.getInstancia().getProvincias();
                ViewBag.ciudades = CiudadDAO.getInstancia().getCiudades();
                MyLogger.log(e.Message);
                ViewBag.errorMsg = e.Message;
                return View();            
            }
        }


        public ActionResult DetallePrestadorDeServicios(int id)
        {
            PrestadorDeServicios pres = PrestadorDeServiciosDAO.getInstancia().getPrestadorDeServicios(id);
            return View(pres);
        }


        public ActionResult DeletePrestadorDeServicios(int id)
        {
            try
            {
                PrestadorDeServiciosDAO.getInstancia().deletePrestador(id);
                return View("ListPrestadorDeServicios");
            }
            catch (Exception e)
            {
                MyLogger.log(e.Message);
                ViewBag.errorMsg = "Hubo un error al intentar eliminar el prestador de servicios";
                return View("ListPrestadorDeServicios");
            }
        }

        public ActionResult EditPrestadorDeServicios(int id)
        {
            PrestadorDeServicios pres = PrestadorDeServiciosDAO.getInstancia().getPrestadorDeServicios(id);
            ViewBag.paises = PaisDAO.getInstancia().getPaises();
            ViewBag.provincias = ProvinciaDAO.getInstancia().getProvincias();
            ViewBag.ciudades = CiudadDAO.getInstancia().getCiudades();
            return View(pres);
        }

        [HttpPost]
        public ActionResult EditPrestadorDeServicios(PrestadorDeServicios PDS)
        {
            try
            {
                PDS.direccionPostal.validarDireccion();
                PrestadorDeServiciosDAO.getInstancia().updatePrestadorDeServicios(PDS);
                return RedirectToAction("ListPrestadorDeServicios", "Compra");
            }
            catch (Exception e)
            {
                ViewBag.paises = PaisDAO.getInstancia().getPaises();
                ViewBag.provincias = ProvinciaDAO.getInstancia().getProvincias();
                ViewBag.ciudades = CiudadDAO.getInstancia().getCiudades();
                MyLogger.log(e.Message);
                ViewBag.errorMsg = e.Message;
                return View();
            }
        }

        ///////////////////////////////////////////////
        ///             Medio de Pago               ///
        ///////////////////////////////////////////////
        public ActionResult AddMedioDePago()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMedioDePago(MedioDePago MDP)
        {
            try
            {
                MDP.idEntidad = ((Usuario)Session["usuario"]).idEntidad;
                MedioDePagoDAO.getInstancia().add(MDP);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                MyLogger.log(e.Message);
                return View();
            }
        }

        public ActionResult ListMedioDePago()
        {
            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            List<MedioDePago> pres = MedioDePagoDAO.getInstancia().getMediosDePago(idEntidad);
            return View(pres);
        }

        public ActionResult DeleteMedioDePago(int idMedioDePago)
        {
            try
            {
                MedioDePagoDAO.getInstancia().deleteMedioDePago(idMedioDePago);
                return View("ListMedioDePago");
            }
            catch (Exception e)
            {
                MyLogger.log(e.Message);
                ViewBag.errorMsg = e.Message;
                return View("ListMedioDePago");
            }
        }

        ///////////////////////////////////////////////
        ///              Presupuesto                ///
        ///////////////////////////////////////////////


        public ActionResult ListPresupuestos()
        {
            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            List<Presupuesto> pres = PresupuestoDAO.getInstancia().getPresupuestos(idEntidad);
            return View(pres);
        }

        public ActionResult AddPresupuesto()
        {
            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            ViewBag.mediosDePago = MedioDePagoDAO.getInstancia().getMediosDePago(idEntidad);
            ViewBag.proveedores = PrestadorDeServiciosDAO.getInstancia().getPrestadoresDeServicios(idEntidad);
            ViewBag.compras = CompraDAO.getInstancia().getCompras();
            ViewBag.categorias = CategoriaDAO.getInstancia().getCategorias(idEntidad);
            ViewBag.egresos = EgresoDAO.getInstancia().getEgresos(idEntidad);
            return View();
        }

        [HttpPost]
        public ActionResult AddPresupuesto(JsonPresupuesto req)
        {
            try
            {
                if (req.presupuesto != null)
                {
                    req.presupuesto.idEntidad = ((Usuario)Session["usuario"]).idEntidad;
                    if (req.setEgreso && req.presupuesto.idCompra != null)
                    {
                        Compra comp = CompraDAO.getInstancia().getCompraConEgresoYDocumentos(req.presupuesto.idCompra.Value);
                        if (comp.egreso.docsComerciales.Exists(dc => dc.tipo_enlace == "Presupuesto"))
                        {
                            throw new Exception("La compra seleccionada ya tiene un presupuesto elegido para el egreso");
                        }
                        req.presupuesto.idEgreso = comp.idEgreso;
                    }
                    PresupuestoDAO.getInstancia().add(req.presupuesto);
                } else if(req.documentoComercial != null){
                    req.documentoComercial.idEntidad = ((Usuario)Session["usuario"]).idEntidad;
                    if (req.setEgreso && req.documentoComercial.idEgreso != null)
                    {
                        Compra comp = CompraDAO.getInstancia().getCompraConEgresoYDocumentos(req.documentoComercial.idEgreso.Value);
                        req.documentoComercial.idEgreso = comp.idEgreso;
                    }
                    
                } else
                {
                    throw new Exception("Hay problemas con los documentos");
                }

                PresupuestoDAO.getInstancia().add(req.presupuesto);


                //Mongo.MongoDB.insertarDocumento("Presupuesto", "alta", req.presupuesto.ToBsonDocument());
                //Mongo.MongoDB.insertarDocumento(req.documentoComercial.tipo_enlace, "alta", req.documentoComercial.ToBsonDocument()); //REVISAR


                return Json(Url.Action("Index", "Home"));
            }
            catch (Exception e)
            {
                int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
                ViewBag.mediosDePago = MedioDePagoDAO.getInstancia().getMediosDePago(idEntidad);
                ViewBag.proveedores = PrestadorDeServiciosDAO.getInstancia().getPrestadoresDeServicios(idEntidad);
                ViewBag.compras = CompraDAO.getInstancia().getCompras();
                ViewBag.categorias = CategoriaDAO.getInstancia().getCategorias(idEntidad);
                ViewBag.egresos = EgresoDAO.getInstancia().getEgresos(idEntidad);
                MyLogger.log(e.Message);
                ViewBag.errorMsg = e.Message;
                return View();
            }
        }

        public ActionResult DeletePresupuesto(int idPresupuesto)
        {
            try
            {
                PresupuestoDAO.getInstancia().deletePresupuesto(idPresupuesto);
                return View("ListPresupuestos");
            }
            catch (Exception e)
            {
                MyLogger.log(e.Message);
                ViewBag.errorMsg = e.Message;
                return View("ListPresupuestos");
            }
        }

        public ActionResult DetallePresupuesto(int id)
        {
            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            Presupuesto pres = PresupuestoDAO.getInstancia().getPresupuesto(id);
            ViewBag.categorias = CategoriaDAO.getInstancia().getCategorias(idEntidad);
            return View(pres);
        }



        ///////////////////////////////////////////////
        ///              Compra                     ///
        ///////////////////////////////////////////////

        // GET: Compras
        public ActionResult ListCompras()
        {
            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            List<Compra> compras = CompraDAO.getInstancia().getComprasConEgreso(idEntidad);
            return View(compras);
        }

        public ActionResult DetalleCompra(int id)
        {
            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            Compra pres = CompraDAO.getInstancia().getCompraConEgresoYDocumentos(id);
            ViewBag.categorias = CategoriaDAO.getInstancia().getCategorias(idEntidad);
            return View(pres);
        }

       
        public ActionResult EditCompra(int idCompra)
        {
            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            Compra pres = CompraDAO.getInstancia().getCompraConEgresoYDocumentos(idCompra);
            ViewBag.usuarios = UsuarioDAO.getInstancia().getUsuarios(idEntidad);
            ViewBag.proveedores = PrestadorDeServiciosDAO.getInstancia().getPrestadoresDeServicios(idEntidad);
            ViewBag.mediosDePago = MedioDePagoDAO.getInstancia().getMediosDePago(idEntidad);
            ViewBag.items = pres.egreso.detalle;
            return View(pres);
        }

        [HttpPost]
        public ActionResult EditCompra(Compra compra)
        {
            try
            {
                CompraDAO.getInstancia().updateCompra(compra);
                return RedirectToAction("ListCompras", "Compra");
            }
            catch (Exception e)
            {
                int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
                Compra pres = CompraDAO.getInstancia().getCompraConEgresoYDocumentos(compra.idCompra);
                ViewBag.usuarios = UsuarioDAO.getInstancia().getUsuarios(idEntidad);
                ViewBag.proveedores = PrestadorDeServiciosDAO.getInstancia().getPrestadoresDeServicios(idEntidad);
                ViewBag.mediosDePago = MedioDePagoDAO.getInstancia().getMediosDePago(idEntidad);
                ViewBag.items = pres.egreso.detalle;
                MyLogger.log(e.Message);
                ViewBag.errorMsg = e.Message;
                return View();
            }
        }

        public ActionResult AddCompra()
        {
            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            ViewBag.mediosDePago = MedioDePagoDAO.getInstancia().getMediosDePago(idEntidad);
            ViewBag.proveedores = PrestadorDeServiciosDAO.getInstancia().getPrestadoresDeServicios(idEntidad);
            ViewBag.usuarios = UsuarioDAO.getInstancia().getUsuarios(idEntidad);
            ViewBag.categorias = CategoriaDAO.getInstancia().getCategorias(idEntidad);
            return View();
        }

        [HttpPost]
        public ActionResult AddCompra(Compra compra)
        {
            
            try
            {

                compra.idEntidad = ((Usuario)Session["usuario"]).idEntidad;

                CompraDAO.getInstancia().add(compra);

               // Mongo.MongoDB.insertarDocumento("Compra", "alta", compra.ToBsonDocument());

                Mongo.MongoDB.insertarDocumento("Egreso", "alta", req.compra.egreso.ToBsonDocument());


                return Json(Url.Action("Index", "Home"));
            }
            catch (Exception e)
            {
                int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
                ViewBag.mediosDePago = MedioDePagoDAO.getInstancia().getMediosDePago(idEntidad);
                ViewBag.proveedores = PrestadorDeServiciosDAO.getInstancia().getPrestadoresDeServicios(idEntidad);
                ViewBag.usuarios = UsuarioDAO.getInstancia().getUsuarios(idEntidad);
                ViewBag.categorias = CategoriaDAO.getInstancia().getCategorias(idEntidad);
                MyLogger.log(e.Message);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(e.Message);
            }
        }

        // GET: Compra/Delete/5
        public ActionResult DeleteCompra(int idCompra)

        {
            try
            {
                CompraDAO.getInstancia().deleteCompra(idCompra);
                return RedirectToAction("ListCompras");
            }
            catch (Exception e)
            {
                MyLogger.log(e.Message);
                ViewBag.errorMsg = e.Message;
                return RedirectToAction("ListCompras");
                 
            }

        }


        ///////////////////////////////////////////////
        ///              Criterio                   ///
        ///////////////////////////////////////////////


        public ActionResult criterios()
        {
            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            ViewBag.criterios = CriterioDAO.getInstancia().getCriterios(idEntidad);
            return View();
        }

        [HttpPost]
        public ActionResult criterios(string criterio, int? idPadre, string categorias)
        {

            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            
            List<string> categoriasSeparadas = categorias.Split(',').ToList();

            List<Categoria> categoriasNuevas = new List<Categoria>();

            for (int i = 0; i < categoriasSeparadas.Count; i++)
            {
                Categoria categoriaNueva = new Categoria(categoriasSeparadas[i].Trim());
                categoriasNuevas.Add(categoriaNueva);
            }

            Criterio criterioNuevo = new Criterio(criterio, idEntidad, idPadre, categoriasNuevas);

            var criterio1 = CriterioDAO.getInstancia().add(criterioNuevo);
            

            return RedirectToAction("Index", "Home");
        }

    }
}
