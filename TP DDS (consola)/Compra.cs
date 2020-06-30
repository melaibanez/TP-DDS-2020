using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace TP_DDS__consola_
{
    class Compra
    {
        public int cantMinimaPresupuestos { get; set; }//a definir
        private float criterio { get; set; }//a definir
        private Egreso egreso;
        public List<Presupuesto> presupuestos { get; set; }
        private List<Usuario> revisores;
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

        public List<Usuario> getRevisores() { return revisores; }
        public Egreso getEgreso() { return egreso; }
        public List<Presupuesto> getPresupuestos() { return presupuestos; }
        public int getCantPresupuestos() { return presupuestos.Count; }



    }
}
