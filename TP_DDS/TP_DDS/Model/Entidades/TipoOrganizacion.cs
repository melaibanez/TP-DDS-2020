using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Entidades
{
    public abstract class TipoOrganizacion
    {
        [Key]
        public int idTipoOrganizacion { get; set; }
        public string actividad { get; set; }

        public TipoOrganizacion(string actividad)
        {
            this.actividad = actividad;
        }
    }
}
