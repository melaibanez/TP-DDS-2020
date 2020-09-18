using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Compras
{
    public class Criterio
    {
        public int idCriterio { get; set; }

        public List<Categoria> categorias { get; set; }

        public List<Categoria> getCategorias() { return categorias; }
    }
}
