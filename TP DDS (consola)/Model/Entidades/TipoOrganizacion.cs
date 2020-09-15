using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_.Model.Entidades
{
    public abstract class TipoOrganizacion
    {
        public int idTipoOrganizacion { get; set; }
        public string actividad { get; set; }

        public TipoOrganizacion(string actividad)
        {
            this.actividad = actividad;
        }
    }
}
