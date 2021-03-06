﻿using Microsoft.Ajax.Utilities;
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
            {   if (PDS.razonSocial != null && PDS.numDoc != null)
                {
                    PDS.idEntidad = ((Usuario)Session["usuario"]).idEntidad;
                    PDS.direccionPostal.validarDireccion();
                    PrestadorDeServiciosDAO.getInstancia().add(PDS);
                    return RedirectToAction("Index", "Home");
                } else
                {
                    throw new Exception("Debe completar todos los campos para continuar");
                }
  
            }
            catch (Exception e)
            {
                ViewBag.paises = PaisDAO.getInstancia().getPaises();
                ViewBag.provincias = ProvinciaDAO.getInstancia().getProvincias();
                ViewBag.ciudades = CiudadDAO.getInstancia().getCiudades();
                MyLogger.log(e.Message);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return Json(e.Message);
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
                if(PDS.razonSocial == null && PDS.numDoc == null)
                    throw new Exception("Debe completar todos los campos para continuar");

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
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return Json(e.Message);
            }
        }

        ///////////////////////////////////////////////
        ///             Medio de Pago               ///
        ///////////////////////////////////////////////
        public ActionResult AddMedioDePago()
        {
            
            ViewBag.mediosDePago = (List<TipoMedioDePago>)TipoMedioDePagoDAO.getInstancia().getMediosDePago();
            return View();
        }

        [HttpPost]
        public ActionResult AddMedioDePago(MedioDePago MDP)
        {
            try
            {   if (MDP.idTipo != null & MDP.numero != null)
                {
                    MDP.idEntidad = ((Usuario)Session["usuario"]).idEntidad;
                    //MDP.tipo = TipoMedioDePagoDAO.getInstancia().getMedioDePago(MDP.tipo.id);
                    MedioDePagoDAO.getInstancia().add(MDP);
                    return RedirectToAction("Index", "Home");
                } else
                {
                    throw new Exception("Debe completar todos los campos para continuar");
                }
            }
            catch (Exception e)
            {   
                ViewBag.mediosDePago = TipoMedioDePagoDAO.getInstancia().getMediosDePago();
                MyLogger.log(e.Message);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                
                return Json(e.Message);
            }
        }

        
        public ActionResult ListMedioDePago()
        {
            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            List<MedioDePago> pres = MedioDePagoDAO.getInstancia().getMediosDePago(idEntidad);
            return View(pres);
        }

        public ActionResult DeleteMedioDePago(int id)
        {
            try
            {
                MedioDePagoDAO.getInstancia().deleteMedioDePago(id);
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
            ViewBag.compras = CompraDAO.getInstancia().getCompras(idEntidad);
            ViewBag.categorias = CategoriaDAO.getInstancia().getCategorias(idEntidad);
            ViewBag.egresos = EgresoDAO.getInstancia().getEgresos(idEntidad);
            ViewBag.monedas = MonedaDAO.getInstancia().getMonedas();
            return View();
        }

        [HttpPost]
        public ActionResult AddPresupuesto(JsonPresupuesto req)
        {
            try
            {
                
                int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
                if (req.presupuesto != null)
                {
                    if (req.presupuesto.idMedioDePago == 0 || req.presupuesto.idPrestadorDeServicios == 0 || req.presupuesto.items == null || req.presupuesto.idCompra == null || req.presupuesto.nroIdentificacion == null || req.presupuesto.tipo == null)
                    {
                        throw new Exception("Hubo un error. Revise los datos ingresados y vuelva a intentarlo.");
                    }

                    req.presupuesto.idEntidad = idEntidad; 
                    if (req.setEgreso && req.presupuesto.idCompra != null)
                    {
                        Compra comp = CompraDAO.getInstancia().getCompraConEgresoYDocumentos(req.presupuesto.idCompra.Value);
                        if (comp.egreso.docsComerciales.Exists(dc => dc.tipo == "Presupuesto"))
                        {
                            throw new Exception("La compra seleccionada ya tiene un presupuesto elegido para el egreso.");
                        }
                        req.presupuesto.idEgreso = comp.idEgreso;
                    }
                    PresupuestoDAO.getInstancia().add(req.presupuesto);
                } else if(req.documentoComercial != null){
                    if(req.documentoComercial.idEgreso == 0 || req.documentoComercial.tipo == null || req.documentoComercial.nroIdentificacion == null)
                        throw new Exception("Hubo un error. Revise los datos ingresados y vuelva a intentarlo.");
                    req.documentoComercial.idEntidad = idEntidad;
                    DocumentoComercialDAO.getInstancia().add(req.documentoComercial);
                    
                } else
                {
                    throw new Exception("Hubo un problema cargando el documento. Recargue la pagina y vuelva a intentarlo.");
                }


                //Mongo.MongoDB.insertarDocumento("Presupuesto", "alta", req.presupuesto.ToBsonDocument());
                //Mongo.MongoDB.insertarDocumento(req.documentoComercial.tipo_enlace, "alta", req.documentoComercial.ToBsonDocument()); //REVISAR


                return Json(Url.Action("Index", "Home"));
            }
            catch (Exception e)
            {
                int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
                ViewBag.mediosDePago = MedioDePagoDAO.getInstancia().getMediosDePago(idEntidad);
                ViewBag.proveedores = PrestadorDeServiciosDAO.getInstancia().getPrestadoresDeServicios(idEntidad);
                ViewBag.compras = CompraDAO.getInstancia().getCompras(idEntidad);
                ViewBag.categorias = CategoriaDAO.getInstancia().getCategorias(idEntidad);
                ViewBag.egresos = EgresoDAO.getInstancia().getEgresos(idEntidad);
                ViewBag.monedas = MonedaDAO.getInstancia().getMonedas();
                MyLogger.log(e.Message);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(e.Message);
            }
        }

        /*public ActionResult EditPresupuesto(int id)
        {
            //falta terminar
            return View();
        }*/

        public ActionResult DeletePresupuesto(int id)
        {
            try
            {
                PresupuestoDAO.getInstancia().deletePresupuesto(id);
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

       
        public ActionResult EditCompra(int id)
        {
            int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
            Compra pres = CompraDAO.getInstancia().getCompraConEgresoYDocumentos(id);
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
                /*if ()
                {
                    throw new Exception("Es necesario completar todos los campos para continuar");
                }*/
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
            ViewBag.monedas = MonedaDAO.getInstancia().getMonedas();
            return View();
        }

        [HttpPost]
        public ActionResult AddCompra(Compra compra)
        {
            
            try
            {


                if (compra.descripcion == null || compra.egreso.detalle == null || compra.egreso.idMedioDePago == 0 || compra.egreso.idPrestadorDeServicios == 0 || compra.cantMinimaPresupuestos < 0 || compra.egreso.fechaEgreso == null || compra.egreso.idMoneda == null){

                    throw new Exception("Es necesario completar todos los campos para continuar");
                }
                 compra.idEntidad = ((Usuario)Session["usuario"]).idEntidad;
                 compra.egreso.idEntidad = ((Usuario)Session["usuario"]).idEntidad;

                 CompraDAO.getInstancia().add(compra);

                //Mongo.MongoDB.insertarDocumento("Egreso", "alta", req.compra.egreso.ToBsonDocument());

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
        public ActionResult DeleteCompra(int id)

        {
            try
            {
                CompraDAO.getInstancia().deleteCompra(id);
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
            try
            {
                if(criterio == null || categorias == null)
                    throw new Exception("Es necesario completar todos los campos para continuar");

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
            catch(Exception e)
            {
                int idEntidad = ((Usuario)Session["usuario"]).idEntidad.Value;
                ViewBag.criterios = CriterioDAO.getInstancia().getCriterios(idEntidad);
                ViewBag.errorMsg = e.Message;
                return View();
            }
        }

    }
}
