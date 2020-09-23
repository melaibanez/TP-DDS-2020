using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Compras
{
    public class ItemEgreso : Item
    {

        [ForeignKey("egreso")]
        public int idEgreso { get; set; }
        public Egreso egreso { get; set; }

        public ItemEgreso() { }

        public ItemEgreso(int cant, string descripcion, float valor) : base(cant, descripcion, valor) { }

    }
}
