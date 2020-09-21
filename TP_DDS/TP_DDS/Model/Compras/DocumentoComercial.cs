using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Compras
{
    public class DocumentoComercial
    {
        [Key]
        public int idDocComercial { get; set; }

        [StringLength(50)]
        public string nroIdentificacion { get; set; }

        [StringLength(50)]
        public string tipo_enlace { get; set; }

        [ForeignKey("egreso")]
        public int idEgreso { get; set; }
        public Egreso egreso { get; set; }

        public DocumentoComercial() { }
        public DocumentoComercial(string nroIdentificacion, string tipo_enlace)
        {
            this.nroIdentificacion = nroIdentificacion;
            this.tipo_enlace = tipo_enlace;
        }
    }
}
