using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_DDS_MVC.Models.Entidades.TiposEmpresa
{
    [Table("tipos_empresas")]
    public abstract class TipoEmpresa
    {
        [Key]
        public int idTipoEmpresa { get; set; }
    }
}