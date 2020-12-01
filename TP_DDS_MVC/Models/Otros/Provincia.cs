using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_DDS_MVC.Models.Otros
{
    [Table("provincias")]
    public class Provincia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string id { get; set; }

        public string nombre { get; set; }

        [ForeignKey("pais")]
        public string idPais { get; set; }
        public Pais pais { get; set; }

        public List<Ciudad> ciudades { get; set; }
    }
}