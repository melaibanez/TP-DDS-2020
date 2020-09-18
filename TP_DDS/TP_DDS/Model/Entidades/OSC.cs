using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Entidades
{
    public class OSC : TipoOrganizacion
    {
        public int idOSC { get; set; }
        public OSC(string actividad) : base(actividad) { }

    }
}
