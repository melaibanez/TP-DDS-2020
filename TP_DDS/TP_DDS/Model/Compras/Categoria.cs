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
        public int idCategoria { get; set; }
        
        [NotMapped]
        public Categoria subCategoria { get; set; }

        [ForeignKey("criterio")]
        public int idCriterio { get; set; }
        public Criterio criterio { get; set; }

        [StringLength(50)]
        public string nombre { get; set; }
        
    }
}
