using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Otros;
using TP_DDS.Model.Ingresos;
using TP_DDS.Model.Entidades;

namespace TP_DDS.Model.Proyectos
{
    class ProyectoFinanciamiento
    {
        public string propuesta { get; set; }
        public int montoTotal { get; set; }
        public Usuario director { get; set; }
        public List<Ingreso> ingresos { get; set; }
        public int limiteErrogacion { get; set; }
        public int cantidadPresupuestos { get; set; }
        public DateTime apertura { get; set; }
        public string evalucion { get; set; }
        public string resultado { get; set; }
        public DateTime fechaEjecucion { get; set; }
        public DateTime fechaCierre { get; set; }

        public void rendirCuenta(Entidad Entidad, Ingreso ingreso) //en cuotas supongo que es 1 ingreso a la vez
        {
            if (fechaEjecucion.CompareTo(fechaCierre) <= 0 && fechaEjecucion.CompareTo(ingreso.fechaDesde) >= 0 && fechaEjecucion.CompareTo(ingreso.fechaHasta) <= 0)
            {
                ingresos.Add(ingreso);
            }
        }
        //hola
    }
}
