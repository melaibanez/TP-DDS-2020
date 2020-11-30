using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_DDS_MVC.Models.Entidades
{
    [Table("entidades_juridicas")]
    public class EntidadJuridica : Entidad
    {

        [StringLength(50)]
        public string codInscripDefinitiva { get; set; }

        [StringLength(20)]
        public string CUIT { get; set; }

        [ForeignKey("direccionPostal")]
        public int idDireccionPostal { get; set; }
        public DireccionPostal direccionPostal { get; set; }

        [StringLength(50)]
        public string razonSocial { get; set; }

        [ForeignKey("tipoOrganizacion")]
        public int idTipoOrganizacion { get; set; }
        public TipoOrganizacion tipoOrganizacion { get; set; }

        public List<EntidadBase> listaEntidadesBase;

        public EntidadJuridica() { }

        public EntidadJuridica(string nombreFicticio, string codInscripDefinitiva, string CUIT, DireccionPostal direccionPostal, List<EntidadBase> listaEntidadesBase, string razonSocial, string actividad) : base(nombreFicticio)
        {
            this.codInscripDefinitiva = codInscripDefinitiva;
            this.CUIT = CUIT;
            this.direccionPostal = direccionPostal;
            this.listaEntidadesBase = listaEntidadesBase;
            this.razonSocial = razonSocial;
            this.tipoOrganizacion = new OSC(actividad);
        }

        public EntidadJuridica(string nombreFicticio, string codInscripDefinitiva, string CUIT, DireccionPostal direccionPostal, List<EntidadBase> listaEntidadesBase, string razonSocial, string actividad, string sector, float promVentas, int cantPersonal) : base(nombreFicticio)
        {
            this.codInscripDefinitiva = codInscripDefinitiva;
            this.CUIT = CUIT;
            this.direccionPostal = direccionPostal;
            this.listaEntidadesBase = listaEntidadesBase;
            this.razonSocial = razonSocial;
            this.tipoOrganizacion = null;//CategorizadorOrg.categorizar(new Empresa(actividad, sector, promVentas, cantPersonal));
        }
    }
}