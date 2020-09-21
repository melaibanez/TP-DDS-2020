using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Compras
{
    [Table("prestadores_de_servicios")]
    public class PrestadorDeServicios
    {
        [Key]
        public int idPrestador { get; set; }
        
        //public string direccionPostal { get; set; }
        
        [StringLength(10)]
        public string numDoc { get; set; }
        
        [StringLength(50)]
        public string razonSocial { get; set; }

        [StringLength(10)]
        public string tipoDoc { get; set; }

        public PrestadorDeServicios(string direccionPostal, string razonSocial, string tipoDoc, string numDoc)
        {
            //this.direccionPostal = direccionPostal;
            this.numDoc = numDoc;
            this.razonSocial = razonSocial;
            this.tipoDoc = tipoDoc;
        }
    }
}
