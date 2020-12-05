using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_DDS_MVC.Models.Compras
{
    public class Presupuesto : DocumentoComercial
    {
        [ForeignKey("medioDePago")]
        public int idMedioDePago { get; set; }
        public MedioDePago medioDePago { get; set; }

        [ForeignKey("prestadorDeServicios")]
        public int idPrestadorDeServicios { get; set; }
        public PrestadorDeServicios prestadorDeServicios { get; set; }

        public float montoTotal { get; set; }

        [ForeignKey("compra")]
        public int? idCompra { get; set; }
        public Compra compra { get; set; }

        public List<ItemPresupuesto> items { get; set; }

        public Presupuesto() { }

        public Presupuesto(string nroIdentificacion, string tipo_enlace, List<ItemPresupuesto> items, PrestadorDeServicios prestadorDeServicios, MedioDePago medioDePago) : base(nroIdentificacion, tipo_enlace)
        {
            this.items = items;
            this.prestadorDeServicios = prestadorDeServicios;
            this.montoTotal = items.Sum(i => i.valor * i.cant);
            this.medioDePago = medioDePago;
        }

        public void altaPresupuesto() { }
        public void bajaPresupuesto() { }
        public void modificacionPresupuesto() { }

    }
}