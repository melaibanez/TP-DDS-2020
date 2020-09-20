using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Compras
{
    [Table("categoria")]
    public class Categoria
    {
        [Key]
        [Column("idCategoria")]
        public int idCategoria { get; set; }

        public Categoria subCategoria { get; set; }

        [Column("idCriterio")]
        public int idCriterio { get; set; }
        public Criterio criterio { get; set; }

        [Column("descripcion")]
        public string nombre { get; set; }
        
    }
}
