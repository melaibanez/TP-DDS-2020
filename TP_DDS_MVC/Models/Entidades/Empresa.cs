using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP_DDS_MVC.Models.Entidades.TiposEmpresa;

namespace TP_DDS_MVC.Models.Entidades
{
    public class Empresa : TipoOrganizacion
    {
        [StringLength(50)]
        public string sector { get; set; }
        public float promedioVentas { get; set; }
        public int cantPersonal { get; set; }

        [ForeignKey("tipoEmpresa")]
        public int idTipoEmpresa { get; set; }
        public TipoEmpresa tipoEmpresa { get; set; }


        public Empresa() { }

        public Empresa(string actividad, string sector, float promVentas, int cantPersonal) : base(actividad)
        {
            this.sector = sector;
            this.promedioVentas = promVentas;
            this.cantPersonal = cantPersonal;
        }

    }
}