using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_.Model.Compras
{
    public class Criterio
    {
        public int idCriterio { get; set; }

        public List<Categoria> categorias { get; set; }

        public List<Categoria> getCategorias() { return categorias; }
    }
}
