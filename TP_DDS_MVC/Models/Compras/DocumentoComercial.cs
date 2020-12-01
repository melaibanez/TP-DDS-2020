using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP_DDS_MVC.Models.Entidades;

namespace TP_DDS_MVC.Models.Compras
{
    [Table("documentos_comerciales")]
    public class DocumentoComercial
    {
        [Key]
        public int idDocComercial { get; set; }

        [StringLength(50)]
        public string nroIdentificacion { get; set; }

        [StringLength(50)]
        public string tipo_enlace { get; set; }

        [ForeignKey("egreso")]
        public int? idEgreso { get; set; }
        public Egreso egreso { get; set; }

        [ForeignKey("entidad")]
        public int? idEntidad { get; set; }
        public Entidad entidad { get; set; }

        public DocumentoComercial() { }
        public DocumentoComercial(string nroIdentificacion, string tipo_enlace)
        {
            this.nroIdentificacion = nroIdentificacion;
            this.tipo_enlace = tipo_enlace;
        }
    }
}