using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_DDS_MVC.Models.Otros
{
    [Table("paises")]
    public class Pais
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string id { get; set; }

        public string nombre { get; set; }

        //[ForeignKey("moneda")]
        public string idMoneda { get; set; }
        //public Moneda moneda {get; set;}

        public List<Provincia> provincias { get; set; }

    }
}