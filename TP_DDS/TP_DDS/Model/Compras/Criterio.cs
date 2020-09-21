using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Entidades;

namespace TP_DDS.Model.Compras
{

    public class Criterio
    {
        [Key]
        public int idCriterio { get; set; }

        [StringLength(50)]
        public string nombre { get; set; }

        [ForeignKey("entidad")]
        public int idEntidad { get; set; }
        public Entidad entidad { get; set; }

        public List<Categoria> categorias { get; set; }

        public Criterio() { }
    }
}
