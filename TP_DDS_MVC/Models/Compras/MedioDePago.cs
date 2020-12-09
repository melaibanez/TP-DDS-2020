using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP_DDS_MVC.Models.Entidades;

namespace TP_DDS_MVC.Models.Compras
{
    [Table("medios_de_pago")]
    public class MedioDePago
    {
        [Key]
        public int idMedioPago { get; set; }

        [StringLength(50)]
        public string numInstrumento { get; set; }

        [StringLength(50)]
        public string instrumento { get; set; }

        [ForeignKey("entidad")]
        public int? idEntidad { get; set; }
        public Entidad entidad { get; set; }

        public MedioDePago() { }

        public MedioDePago(string instrumento, string numInstrumento)
        {
            this.instrumento = instrumento;
            this.numInstrumento = numInstrumento;
        }
    }
}