using System;
using System.Collections.Generic;
using System.Text;
using TP_DDS__consola_.Model.Otros;


namespace TP_DDS__consola_.Model.Compras
{
    public class Compra
    {
        public int idCompra { get; set; }
        public int cantMinimaPresupuestos { get; set; }//a definir
        private float criterio { get; set; }//a definir
        private Egreso egreso;
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

        public List<Usuario> getRevisores() { return revisores; }
        public Egreso getEgreso() { return egreso; }
        public List<Presupuesto> getPresupuestos() { return presupuestos; }
        public int getCantPresupuestos() { return presupuestos.Count; }



    }
}
