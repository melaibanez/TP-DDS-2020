using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Otros;

namespace TP_DDS.Model.Compras
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

        public MedioDePago() { }

        public MedioDePago(string instrumento, string numInstrumento)
        {
            this.instrumento = instrumento;
            this.numInstrumento = numInstrumento;
        }
    }
}
