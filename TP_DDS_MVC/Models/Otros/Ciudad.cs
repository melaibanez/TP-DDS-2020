using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_DDS_MVC.Models.Otros
{
    [Table("ciudades")]
    public class Ciudad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string id { get; set; }

        public string nombre { get; set; }

        [ForeignKey("provincia")]
        public string idProvincia { get; set; }
        public Provincia provincia { get; set; }
    }
}