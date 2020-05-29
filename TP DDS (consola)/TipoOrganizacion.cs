using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_
{
    abstract class TipoOrganizacion
    {
        public string actividad { get; set; }

        public TipoOrganizacion(string actividad)
        {
            this.actividad = actividad;
        }
    }
}
