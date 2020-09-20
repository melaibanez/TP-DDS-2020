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
    [Table("mediodepago")]
    public class MedioDePago
    {
        [Key]
        [Column("idMedioDePago")]
        public int idMedioPago { get; set; }

        [Column("numInstrumento")]
        public string numInstrumento { get; set; }

        [Column("instrumento")]
        public string instrumento { get; set; }

        public MedioDePago() { }
    }
}
