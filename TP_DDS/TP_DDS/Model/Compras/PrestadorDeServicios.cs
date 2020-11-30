using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Entidades;

namespace TP_DDS.Model.Compras
{
    [Table("prestadores_de_servicios")]
    public class PrestadorDeServicios
    {
        [Key]
        public int idPrestador { get; set; }
        
        [ForeignKey("direccionPostal")]
        public int idDireccionPostal { get; set; }
        public DireccionPostal direccionPostal { get; set; }

        [StringLength(11)]
        public string numDoc { get; set; }
        
        [StringLength(50)]
        public string razonSocial { get; set; }

        [StringLength(10)]
        public string tipoDoc { get; set; }

        public PrestadorDeServicios() { }

        public PrestadorDeServicios(string razonSocial, DireccionPostal direccionPostal, string tipoDoc, string numDoc)
        {
            this.direccionPostal = direccionPostal;
            this.numDoc = numDoc;
            this.razonSocial = razonSocial;
            this.tipoDoc = tipoDoc;
        }
    }
}
