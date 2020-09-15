using System;
using System.Collections.Generic;
using System.Text;
using TP_DDS__consola_.Validadores;

namespace TP_DDS__consola_.Model.Entidades
{
    public class EntidadBase : Entidad
    {
        public int idEntidadBase { get; set; }
        public string descripcion { get; set; }
        public EntidadJuridica entidadJuridica { get; set; }
        public TipoOrganizacion tipoOrganizacion { get; set; }

        public EntidadBase(string nombreFicticio, string descripcion, EntidadJuridica entidadJuridica, string actividad) : base (nombreFicticio)
        {
            this.descripcion = descripcion;
            this.entidadJuridica = entidadJuridica;
            this.nombreFicticio = nombreFicticio;
            this.tipoOrganizacion = new OSC(actividad);
        }
        public EntidadBase(string nombreFicticio, string descripcion, EntidadJuridica entidadJuridica, string actividad, string sector, float promVentas, int cantPersonal) : base(nombreFicticio)
        {
            this.descripcion = descripcion;
            this.entidadJuridica = entidadJuridica;
            this.nombreFicticio = nombreFicticio;
            this.tipoOrganizacion = CategorizadorOrg.categorizar(new Empresa(actividad, sector, promVentas, cantPersonal));
        }
    }
}
