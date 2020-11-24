using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Otros
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
