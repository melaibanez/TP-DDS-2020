using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Compras;

namespace TP_DDS.Model.Ingresos
{
    public class Ingreso
    {

        public string descripcion { get; set; }
        public float montoTotal { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }

        public List<Egreso> egresosAsociados;

        public Ingreso(string descripcion, float montoTotal, List<Egreso> egresosAsociados)
        {
            this.descripcion = descripcion;
            this.montoTotal = montoTotal;
            this.egresosAsociados = egresosAsociados;
        }

        public List<Egreso> getEgresoAsociado() { return egresosAsociados; }

        public void addEgresoAsociado(Egreso egreso) { this.egresosAsociados.Add(egreso); }

        public bool EgresosTotalizanMonto()
        {
            List<float> montosEgresos = egresosAsociados.Select(egreso => egreso.montoTotal).ToList();
            int montoTotalEgresos = montosEgresos.Sum(monto => Convert.ToInt32(monto));

            return montoTotal == montoTotalEgresos;

        }
    }
}
