using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP_DDS_MVC.Models.Proyectos;
using MongoDB.Bson.Serialization.Attributes;

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

        [ForeignKey("moneda")]
        public string idMoneda { get; set; }
        public Moneda moneda { get; set; }
        public List<ItemPresupuesto> items { get; set; }


        public Presupuesto() { }

        public Presupuesto(string nroIdentificacion, string tipo, List<ItemPresupuesto> items, PrestadorDeServicios prestadorDeServicios, MedioDePago medioDePago) : base(nroIdentificacion, tipo)
        {
            this.items = items;
            this.prestadorDeServicios = prestadorDeServicios;
            this.montoTotal = items.Sum(i => i.valor * i.cant);
            this.medioDePago = medioDePago;
        }

    }
}