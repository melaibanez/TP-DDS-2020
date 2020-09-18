using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Validadores;

namespace TP_DDS.Model.Entidades
{
    public class EntidadJuridica : Entidad
    {
        public int idEntidadJuridica { get; set; }
        public string condInscripDefinitiva { get; set; }
        public string CUIT { get; set; }
        public string direccionPostal { get; set; }
        public List<EntidadBase> listaEntidadesBase;
        public string razonSocial { get; set; }
        public TipoOrganizacion tipoOrganizacion { get; set; }

        public EntidadJuridica(string nombreFicticio, string condInscripDefinitiva, string CUIT, string direccionPostal, List<EntidadBase> listaEntidadesBase, string razonSocial, string actividad) : base(nombreFicticio)
        {
            this.condInscripDefinitiva = condInscripDefinitiva;
            this.CUIT = CUIT;
            this.direccionPostal = direccionPostal;
            this.listaEntidadesBase = listaEntidadesBase;
            this.razonSocial = razonSocial;
            this.tipoOrganizacion = new OSC(actividad);
        }

        public EntidadJuridica(string nombreFicticio, string condInscripDefinitiva, string CUIT, string direccionPostal, List<EntidadBase> listaEntidadesBase, string razonSocial, string actividad, string sector, float promVentas, int cantPersonal) : base(nombreFicticio)
        {
            this.condInscripDefinitiva = condInscripDefinitiva;
            this.CUIT = CUIT;
            this.direccionPostal = direccionPostal;
            this.listaEntidadesBase = listaEntidadesBase;
            this.razonSocial = razonSocial;
            this.tipoOrganizacion = CategorizadorOrg.categorizar(new Empresa(actividad, sector, promVentas, cantPersonal));
        }
    }
}
