using System;
using System.Collections.Generic;
using System.Text;
using TP_DDS__consola_.Model.Compras;

namespace TP_DDS__consola_
{
    public class Ingreso
    {

        public string descripcion { get; set; }
        public float montoTotal { get; set; }

        private List<Egreso> egresosAsociados;

        public Ingreso (string descripcion, float montoTotal, List<Egreso> egresosAsociados)
        {
            this.descripcion = descripcion;
            this.montoTotal = montoTotal;
            this.egresosAsociados = egresosAsociados;
        }

        public List<Egreso> getEgresoAsociado() { return egresosAsociados; }

        public void addEgresoAsociado(Egreso egreso) { this.egresosAsociados.Add(egreso); } 
    }
}
