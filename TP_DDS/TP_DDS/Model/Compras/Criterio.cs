using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Compras
{
    public class Criterio
    {
        [Key]
        [Column("idCriterio")]
        public int idCriterio { get; set; }

        [Column("idCategoria")?]
        public int idCategoria { get; set; }
        public List<Categoria> categorias { get; set; }
        public List<Categoria> getCategorias() { return categorias; }
    }
}
