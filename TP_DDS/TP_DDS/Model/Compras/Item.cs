using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Compras
{
    [Table("item")]
    public class Item
    {
        [Key]
        [Column("idItem")]
        public int idItem { get; set; }

        [Column("cant")]
        public int cant { get; set; }

        [Column("descripcion")]
        public string descripcion { get; set; }

        [Column("valor")]
        public float valor { get; set; }

        [Column("idJerarquiaCategorias")]
        public int idJerarquiaCategorias { get; set; }

        [NotMapped]
        public Categoria categorias { get; set; }

        public Item() { }

        public Item(int cant, string descripcion, float valor, Categoria categorias) //recibe las categorias ya anidadas abajo de la categoria raiz
        {
            this.cant = cant;
            this.descripcion = descripcion;
            this.valor = valor;
            this.categorias = categorias;
        }
    }
}
