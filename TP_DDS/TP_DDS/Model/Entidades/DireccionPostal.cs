using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Entidades
{
    [Table("direcciones_postales")]
    public class DireccionPostal
    {
        [Key]
        public int idDireccionPostal { get; set; }

        [StringLength(50)]
        public string calle { get; set; }
        [StringLength(6)]
        public string numero { get; set; }
        [StringLength(20)]
        public string piso_depto { get; set; }
        [StringLength(50)]
        public string ciudad { get; set; }
        [StringLength(50)]
        public string provincia { get; set; }
        [StringLength(50)]
        public string pais { get; set; }

        public DireccionPostal() { }


    }
}
