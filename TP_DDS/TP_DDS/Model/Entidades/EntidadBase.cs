using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Validadores;

namespace TP_DDS.Model.Entidades
{
    [Table("entidades_base")]
    public class EntidadBase : Entidad
    {
        [Key]
        public int idEntidadBase { get; set; }

        [StringLength(50)]
        public string descripcion { get; set; }

        [ForeignKey("entidadJuridica")]
        public int idEntidadJuridica { get; set; }
        public EntidadJuridica entidadJuridica { get; set; }

        [ForeignKey("tipoOrganizacion")]
        public int idTipoOrganizacion { get; set; }
        public TipoOrganizacion tipoOrganizacion { get; set; }
        
        public EntidadBase() { }
        public EntidadBase(string nombreFicticio, string descripcion, EntidadJuridica entidadJuridica, string actividad) : base(nombreFicticio)
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
