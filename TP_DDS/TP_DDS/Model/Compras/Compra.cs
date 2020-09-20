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
        [Key]
        [Column("idCompra")]
        public int idCompra { get; set; }

        [Column("cantMinimaPresupuestos")]
        public int cantMinimaPresupuestos { get; set; }//a definir
        [Column("idCriterio")?]
        private float criterio { get; set; }//a definir

        [Column("idEgreso")]
        public string idEgreso { get; set; }
        [Column("idEgreso")?]
        public Egreso egreso { get; set; }
        [Column("idPresupuesto")?]
        public int idPresupuesto { get; set; }
        public List<Presupuesto> presupuestos { get; set; }

        [Column("idUsuario")]
        public int idUsuario { get; set; }
        public List<Usuario> revisores { get; set; }

        [Column("fueVerificada")?]
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
