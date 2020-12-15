using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP_DDS_MVC.Models.Ingresos;
using TP_DDS_MVC.Models.Entidades;
using MongoDB.Bson.Serialization.Attributes;

namespace TP_DDS_MVC.Models.Compras
{
    [Table("egresos")]
    public class Egreso
    {
        [Key] 
        public int idEgreso { get; set; }

        public DateTime fechaEgreso { get; set; }

        [ForeignKey("medioDePago")] 
        public int idMedioDePago { get; set; }
        public MedioDePago medioDePago { get; set; }

        public float montoTotal { get; set; }

        [ForeignKey("prestadorDeServicios")] 
        public int idPrestadorDeServicios { get; set; }
        
        public PrestadorDeServicios prestadorDeServicios { get; set; }

        [ForeignKey("ingresoAsociado")] 
        public int? idIngresoAsociado { get; set; }
        [BsonIgnore]
        public Ingreso ingresoAsociado { get; set; }

        [ForeignKey("entidad")] 
        public int? idEntidad { get; set; }
        public Entidad entidad { get; set; }
        [BsonIgnore]
        public List<ItemEgreso> detalle { get; set; }
        
        public List<DocumentoComercial> docsComerciales { get; set; }

        public Egreso() { }
        public Egreso(List<ItemEgreso> detalle, List<DocumentoComercial> docsComerciales, Entidad entidad, DateTime fechaEgreso, Ingreso ingresoAsociado)
        {
            this.detalle = detalle;
            this.docsComerciales = docsComerciales;
            this.fechaEgreso = fechaEgreso;
            this.medioDePago = ((Presupuesto)docsComerciales.Find(d => d.tipo_enlace == "Presupuesto")).medioDePago;
            this.montoTotal = detalle.Sum(i => i.valor * i.cant);
            this.prestadorDeServicios = ((Presupuesto)docsComerciales.Find(d => d.tipo_enlace == "Presupuesto")).prestadorDeServicios;
            this.ingresoAsociado = ingresoAsociado;
        }


        public Presupuesto getPresupuestoElegido()
        {
            return (Presupuesto)docsComerciales.Find(doc => doc.tipo_enlace == "Presupuesto");
        }

        public bool tieneIngresoAsociado()
        {
            return ingresoAsociado != null;
        }
    }
}