using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_
{
    class Empresa : TipoOrganizacion
    {
        public string sector { get; set; }
        public float promedioVentas { get; set; }
        public int cantPersonal { get; set; }

    }
}
