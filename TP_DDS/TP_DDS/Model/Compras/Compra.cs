using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Otros;

namespace TP_DDS.Model.Compras
{
    public class Compra
    {
        public int idCompra { get; set; }
        public int cantMinimaPresupuestos { get; set; }//a definir
        private float criterio { get; set; }//a definir
        public Egreso egreso { get; set; }
        public List<Presupuesto> presupuestos { get; set; }
        public List<Usuario> revisores { get; set; }
        public bool fueVerificada { get; set; }
        public Compra(int cantMinimaPresupuestos, float criterio, Egreso egreso, List<Presupuesto> presupuestos, List<Usuario> revisores, bool fueVerificada)
        {
            this.cantMinimaPresupuestos = cantMinimaPresupuestos;
            this.criterio = criterio;
            this.egreso = egreso;
            this.presupuestos = presupuestos;
            this.revisores = revisores;
            this.fueVerificada = fueVerificada;
        }


        public int getCantPresupuestos() { return presupuestos.Count; }
    }
}
