using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Entidades;
using TP_DDS.Model.Otros;

namespace TP_DDS.Model.Compras
{
    [Table("compras")]
    public class Compra
    {
        [Key]
        public int idCompra { get; set; }

        public int cantMinimaPresupuestos { get; set; }//a definir
        
        [NotMapped]
        private float criterio { get; set; }//a definir

        [ForeignKey("entidad")]
        public int idEntidad { get; set; }
        public Entidad entidad { get; set; }

        [ForeignKey("egreso")]
        public int idEgreso { get; set; }
        public Egreso egreso { get; set; }

        public bool compraValidada { get; set; }

        public List<Usuario> revisores { get; set; }
        public List<Presupuesto> presupuestos { get; set; }

        public Compra() { }
        public Compra(int cantMinimaPresupuestos, float criterio, Egreso egreso, List<Presupuesto> presupuestos, List<Usuario> revisores)
        {
            this.cantMinimaPresupuestos = cantMinimaPresupuestos;
            this.criterio = criterio;
            this.egreso = egreso;
            this.presupuestos = presupuestos;
            this.revisores = revisores;
            this.compraValidada = false;
        }


        public int getCantPresupuestos() { return presupuestos.Count; }
    }
}
