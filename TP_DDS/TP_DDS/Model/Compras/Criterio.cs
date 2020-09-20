using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Compras
{
    [Table("criterio")]
    public class Criterio
    {
        [Key]
        [Column("idCriterio")]
        public int idCriterio { get; set; }

        [Column("descripcion")]
        public int nombre { get; set; }
        public List<Categoria> categorias { get; set; }

        public Criterio() { }
    }
}
