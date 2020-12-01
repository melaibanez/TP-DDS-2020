using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TP_DDS_MVC.Models.Compras
{
    [Table("categorias")]
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