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
    [Table("categoria")]
    public class Compra
    {
        [Key]
        [Column("idCompra")]
        public int idCompra { get; set; }

        [Column("cantMinimaPresupuestos")]
        public int cantMinimaPresupuestos { get; set; }//a definir
        
        private float criterio { get; set; }//a definir

        [Column("idEntidad")]
        public string idEntidad { get; set; }
        public Entidad entidad { get; set; }

        public List<Presupuesto> presupuestos { get; set; }

        [Column("idEgreso")]
        public int idEgreso { get; set; }
        public int egreso { get; set; }

        public List<Usuario> revisores { get; set; }

        [Column("copmraValidada")]
        public bool compraValidada { get; set; }

        public Compra() { }
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
