using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP_DDS_MVC.Models.Entidades;
using MongoDB.Bson.Serialization.Attributes;

namespace TP_DDS_MVC.Models.Compras
{
    [Table("medios_de_pago")]
    public class MedioDePago
    {
        [Key]
        public int idMedioPago { get; set; }
        [ForeignKey("tipo")]
        public string idTipo {get;set;}
        public TipoMedioDePago tipo { get; set; }
        public string numero { get; set; }
        [ForeignKey("entidad")] 
        public int? idEntidad { get; set; }
        public Entidad entidad { get; set; }

        public MedioDePago() { }

        public MedioDePago(string name, string numero)
        {
            this.tipo.name = name;
            this.numero = numero;
        }
    }
}