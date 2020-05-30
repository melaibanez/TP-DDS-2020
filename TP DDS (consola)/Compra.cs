using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_
{
    class Compra
    {
        public int cantMinimaPresupuestos { get; set; }//a definir
        private float criterio { get; set; }//a definir
        private Egreso egreso;
        public List<Presupuesto> presupuestos { get; set; }
        
        private Usuario revisores;

    }
}
