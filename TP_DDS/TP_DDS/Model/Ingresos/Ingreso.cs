using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        public int idIngreso { get; set; }
        
        [StringLength(200)]
        public string descripcion { get; set; }

        public float monto { get; set; }

        public DateTime fechaDesde { get; set; }

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

        public bool EgresosNoTotalizanMonto()
        {
              return this.montoTotalEgresosAsociados() > 0;

        }

        public float montoTotalEgresosAsociados()
        {
            List<float> montosEgresos = egresosAsociados.Select(egreso => egreso.montoTotal).ToList();
            return montosEgresos.Sum(monto => Convert.ToInt32(monto));
        }
    }
}
