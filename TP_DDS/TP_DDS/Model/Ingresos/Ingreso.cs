using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Compras;

namespace TP_DDS.Model.Ingresos
{
    [Table("ingreso")]
    public class Ingreso
    {
        [Column("idIngreso")]
        public int idIngreso { get; set; }

        [Column("descripcion")]
        public string descripcion { get; set; }

        [Column("monto")]
        public float monto { get; set; }

        [Column("fechaIngreso")]
        public DateTime fechaDesde { get; set; }

        [Column("periodo")]
        public DateTime fechaHasta { get; set; }

        private List<Egreso> egresosAsociados;

        public Ingreso() { }
        public Ingreso(string descripcion, float montoTotal, List<Egreso> egresosAsociados)
        {
            this.descripcion = descripcion;
            this.monto = montoTotal;
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
