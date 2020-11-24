using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Entidades.TiposEmpresa
{
    [Table("tipos_empresas")]
    public abstract class TipoEmpresa
    {
        [Key]
        public int idTipoEmpresa { get; set; }
    }
}
