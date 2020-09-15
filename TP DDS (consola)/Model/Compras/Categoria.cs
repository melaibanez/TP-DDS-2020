using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_
{
    public class Categoria
    {
        private Criterio criterio;

        public string nombre { get; set; }

        public Criterio getCriterio() { return criterio; }
    }
}
