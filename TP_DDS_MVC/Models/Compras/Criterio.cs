using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP_DDS_MVC.Models.Entidades;

namespace TP_DDS_MVC.Models.Compras
{
    [Table("criterios")]
    public class Criterio
    {
        [Key]
        public int idCriterio { get; set; }

        [StringLength(50)]
        public string nombre { get; set; }

        [ForeignKey("entidad")]
        public int idEntidad { get; set; }
        public Entidad entidad { get; set; }

        [ForeignKey("criterioPadre")]
        public int? idCriterioPadre { get; set; }
        public Criterio criterioPadre { get; set; }

        public List<Categoria> categorias { get; set; }

        public Criterio(string nombre, int idEntidad, int? idCriterioPadre, List<Categoria> categorias)
        {
            this.nombre = nombre;
            this.idEntidad = idEntidad;
            this.idCriterioPadre = idCriterioPadre;
            this.categorias = categorias;
        }

        public Criterio() { }
    }
}