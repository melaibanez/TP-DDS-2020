using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Compras
{
    public class Categoria
    {
        [Key]
        [Column("idCategoria")]
        public int idCategoria { get; set; }

        [Column("idCriterio")]
        public int idCriterio { get; set; }
        public Criterio criterio { get; set; }
        public string nombre { get; set; }
        public Categoria subCategoria { get; set; }
    }
}
