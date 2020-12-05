using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP_DDS_MVC.Models.Entidades;
using TP_DDS_MVC.Models.Otros;

namespace TP_DDS_MVC.Models.Compras
{
    [Table("compras")]
    public class Compra
    {
        [Key]
        public int idCompra { get; set; }

        public string descripcion { get; set; }

        public int cantMinimaPresupuestos { get; set; }//a definir

        [NotMapped]
        private float criterio { get; set; }//a definir esto no deberia ser un float

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
        public Compra(string descripcion, int cantMinimaPresupuestos, float criterio, Egreso egreso, List<Presupuesto> presupuestos, List<Usuario> revisores)
        {
            this.descripcion = descripcion;
            this.cantMinimaPresupuestos = cantMinimaPresupuestos;
            this.criterio = criterio;
            this.egreso = egreso;
            this.presupuestos = presupuestos;
            this.revisores = revisores;
            this.compraValidada = false;
            MvcApplication.comprasNoValidadas.Add(this);
        }


        public int getCantPresupuestos() { return presupuestos.Count; }
    }
}