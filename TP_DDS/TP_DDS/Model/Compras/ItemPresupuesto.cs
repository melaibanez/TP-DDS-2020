using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Compras
{
    [Table("item_presupuesto")]
    public class ItemPresupuesto
    {
        [Key]
        public int idItemPresupuesto { get; set; }

        public int cant { get; set; }

        [StringLength(200)]
        public string descripcion { get; set; }

        public float valor { get; set; }

        [ForeignKey("presupuesto")]
        public int idPresupuesto { get; set; }
        public Presupuesto presupuesto { get; set; }


        [NotMapped]
        public int idJerarquiaCategorias { get; set; }

        [NotMapped]
        public Categoria categorias { get; set; }



        public ItemPresupuesto() { }

        public ItemPresupuesto(int cant, string descripcion, float valor, Categoria categorias) //recibe las categorias ya anidadas abajo de la categoria raiz
        {
            this.cant = cant;
            this.descripcion = descripcion;
            this.valor = valor;
            this.categorias = categorias;
        }
    }
}
