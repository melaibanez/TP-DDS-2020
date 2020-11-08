using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Otros
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
