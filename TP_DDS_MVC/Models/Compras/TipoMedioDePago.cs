using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_DDS_MVC.Models.Compras
{
    [Table("tipoMedioDePago")]
    public class TipoMedioDePago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string id { get; set; }
        public string name { get; set; }
        public string payment_type_id { get; set; }
        public string status { get; set; }
        public string deferred_capture { get; set; }
        

    }
}