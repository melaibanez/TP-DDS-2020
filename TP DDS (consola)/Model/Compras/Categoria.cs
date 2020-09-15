using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_.Model.Compras
{
    public class Categoria
    {
        public int idCategoria { get; set; }
        public Criterio criterio { get; set; }
        public string nombre { get; set; }
        public Categoria subCategoria { get; set; }

        public Criterio getCriterio() { return criterio; }
    }
}
