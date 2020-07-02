using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TP_DDS__consola_
{
    class Egreso
    {
        private Entidad entidad;
        private List<Item> detalle;
        private List<DocumentoComercial> docsComerciales;
        private DateTime fechaEgreso;
        private MedioDePago medioDePago;
        private float montoTotal;
        private PrestadorDeServicios prestadorDeServicios;
        private Ingreso ingresoAsociado;

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
