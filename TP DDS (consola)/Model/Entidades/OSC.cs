using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_.Model.Entidades
{
    public class OSC : TipoOrganizacion
    {
        public int idOSC { get; set; }
        public OSC(string actividad) : base(actividad){ }

    }
}
