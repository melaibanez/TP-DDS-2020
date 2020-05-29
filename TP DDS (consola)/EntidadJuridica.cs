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

        public EntidadJuridica (string condInscripDefinitiva, string CUIT, string direccionPostal, List<EntidadBase> listaEntidadesBase, string nombreFicticio, string razonSocial, string actividad)
        {
            this.condInscripDefinitiva = condInscripDefinitiva;
            this.CUIT = CUIT;
            this.direccionPostal = direccionPostal;
            this.listaEntidadesBase = listaEntidadesBase;
            this.nombreFicticio = nombreFicticio;
            this.razonSocial = razonSocial;
            this.tipoOrganizacion = new OSC(actividad);           
        }

        public EntidadJuridica(string condInscripDefinitiva, string CUIT, string direccionPostal, List<EntidadBase> listaEntidadesBase, string nombreFicticio, string razonSocial, string actividad, string sector, float promVentas, int cantPersonal)
        {
            this.condInscripDefinitiva = condInscripDefinitiva;
            this.CUIT = CUIT;
            this.direccionPostal = direccionPostal;
            this.listaEntidadesBase = listaEntidadesBase;
            this.nombreFicticio = nombreFicticio;
            this.razonSocial = razonSocial;
            this.tipoOrganizacion = CategorizadorOrg.categorizar(new Empresa(actividad, sector, promVentas, cantPersonal));
        }

    }
}
