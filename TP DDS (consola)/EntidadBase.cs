using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_
{
    class EntidadBase : Entidad
    {
        public string descripcion { get; set; }
        public EntidadJuridica entidadJuridica { get; set; }
        public string nombreFicticio { get; set; }
        public TipoOrganizacion tipoOrganizacion { get; set; }

    }
}
