using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Compras
{
    public class PrestadorDeServicios
    {
        [Column("idPrestadorDeServicios")]
        public int idPrestador { get; set; }
        [Column("direccionPostal")?]
        public string direccionPostal { get; set; }
        [Column("numDoc")]
        public string numDoc { get; set; }
        [Column("razonSocial")]
        public string razonSocial { get; set; }
        [Column("tipoDoc")]
        public string tipoDoc { get; set; }

        public PrestadorDeServicios(string direccionPostal, string razonSocial, string tipoDoc, string numDoc)
        {
            this.direccionPostal = direccionPostal;
            this.numDoc = numDoc;
            this.razonSocial = razonSocial;
            this.tipoDoc = tipoDoc;
        }
    }
}
