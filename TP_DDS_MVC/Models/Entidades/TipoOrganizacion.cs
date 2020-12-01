using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_DDS_MVC.Models.Entidades
{
    [Table("organizaciones")]
    public abstract class TipoOrganizacion
    {
        [Key]
        public int idTipoOrganizacion { get; set; }
        public string actividad { get; set; }

        public TipoOrganizacion() { }
        public TipoOrganizacion(string actividad)
        {
            this.actividad = actividad;
        }
    }
}