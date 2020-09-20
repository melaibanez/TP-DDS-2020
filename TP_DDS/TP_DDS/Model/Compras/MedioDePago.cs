using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Otros;

namespace TP_DDS.Model.Compras
{
    public class MedioDePago
    {
        [Column("idMedioDePago")]
        public int idMedioPago { get; set; }

        [NotMapped]
        public string identificador { get; set; }

        [Column("tipo")?]
        public string tipo { get; set; }
    }
}
