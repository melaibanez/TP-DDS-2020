using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_DDS_MVC.Models.Entidades
{
    [Table("entidades_base")]
    public class EntidadBase : Entidad
    {

        [StringLength(50)]
        public string descripcion { get; set; }

        [ForeignKey("entidadJuridica")]
        public int? idEntidadJuridica { get; set; }
        public virtual EntidadJuridica entidadJuridica { get; set; }

        [ForeignKey("tipoOrganizacion")]
        public int idTipoOrganizacion { get; set; }
        public TipoOrganizacion tipoOrganizacion { get; set; }

        public EntidadBase() { }
        public EntidadBase(string nombreFicticio, string descripcion, EntidadJuridica entidadJuridica, string actividad) : base(nombreFicticio)
        {
            this.descripcion = descripcion;
            this.entidadJuridica = entidadJuridica;
            this.tipoOrganizacion = new OSC(actividad);
        }
        public EntidadBase(string nombreFicticio, string descripcion, EntidadJuridica entidadJuridica, string actividad, string sector, float promVentas, int cantPersonal) : base(nombreFicticio)
        {
            this.descripcion = descripcion;
            this.entidadJuridica = entidadJuridica;
            this.nombreFicticio = nombreFicticio;
            this.tipoOrganizacion = null;//CategorizadorOrg.categorizar(new Empresa(actividad, sector, promVentas, cantPersonal));
        }
    }
}