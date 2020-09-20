using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Compras;

namespace TP_DDS.Model.Ingresos
{
    public class Ingreso
    {
        [Column("descripcion")]
        public string descripcion { get; set; }

        [Column("monto")]
        public float monto { get; set; }

        [Column("idEgreso")?]
        private int idEgreso { get; set; }
        private List<Egreso> egresosAsociados;

        public Ingreso(string descripcion, float montoTotal, List<Egreso> egresosAsociados)
        {
            this.descripcion = descripcion;
            this.monto = montoTotal;
            this.egresosAsociados = egresosAsociados;
        }

        public List<Egreso> getEgresoAsociado() { return egresosAsociados; }

        public void addEgresoAsociado(Egreso egreso) { this.egresosAsociados.Add(egreso); }
    }
}
