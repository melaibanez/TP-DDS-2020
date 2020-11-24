using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Entidades.TiposEmpresa;

namespace TP_DDS.Model.Entidades
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
