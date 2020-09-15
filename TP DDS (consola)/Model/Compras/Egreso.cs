using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using TP_DDS__consola_.Model;

namespace TP_DDS__consola_.Model.Compras
{
    public class Egreso
    {
        public int idEgreso { get; set; }
        public Entidad entidad;
        public List<Item> detalle;
        public List<DocumentoComercial> docsComerciales;
        public DateTime fechaEgreso;
        public MedioDePago medioDePago;
        public float montoTotal;
        public PrestadorDeServicios prestadorDeServicios;
        public Ingreso ingresoAsociado;

        public Egreso(List<Item> detalle, List<DocumentoComercial> docsComerciales, Entidad entidad, DateTime fechaEgreso, MedioDePago medioDePago, PrestadorDeServicios prestadorDeServicios, Ingreso ingresoAsociado)
        {
            this.detalle = detalle;
            this.docsComerciales = docsComerciales;
            this.entidad = entidad;
            this.fechaEgreso = fechaEgreso;
            this.medioDePago = medioDePago;
            this.montoTotal = detalle.Sum(i => i.getValor() * i.getCant());
            this.prestadorDeServicios = prestadorDeServicios;
            this.ingresoAsociado = ingresoAsociado;
        }

        public float getMontoTotal() { return montoTotal; }
        public PrestadorDeServicios getPrestadorDeServicios() { return prestadorDeServicios; }
        public List<DocumentoComercial> getDocsComerciales() { return docsComerciales; }

        public Presupuesto getPresupuestoElegido()
        {
            return (Presupuesto)getDocsComerciales().Find(doc => doc.getTipo_Enlace() == "Presupuesto");
        }
    }
}
