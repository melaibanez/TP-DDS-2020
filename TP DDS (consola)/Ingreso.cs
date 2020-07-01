using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_
{
    class Ingreso
    {

        public string descripcion { get; set; }
        public float montoTotal { get; set; }

        private Egreso egresoAsociado;

        public Ingreso (string descripcion, float montoTotal, Egreso egresoAsociado)
        {
            this.descripcion = descripcion;
            this.montoTotal = montoTotal;
            this.egresoAsociado = egresoAsociado;
        }

        public Egreso getEgresoAsociado() { return egresoAsociado; }

        public void setEgresoAsociado(Egreso egreso) { this.egresoAsociado = egreso; } 
    }
}
