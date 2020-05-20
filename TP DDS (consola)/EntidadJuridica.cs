using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_
{
    class EntidadJuridica : Entidad
    {
        public string condInscripDefinitiva { get; set; }
        public string CUIT { get; set; }
        public string direccionPostal { get; set; }
        public List<EntidadBase> listaEntidadesBase;
        public string nombreFicticio { get; set; }
        public string razonSocial { get; set; }
        public TipoOrganizacion tipoOrganizacion { get; set; }

    }
}
