using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Compras
{
    public class ItemPresupuesto : Item
    {
        [ForeignKey("presupuesto")]
        public int idPresupuesto { get; set; }
        public Presupuesto presupuesto { get; set; }


        public ItemPresupuesto() { }

        public ItemPresupuesto (int cant, string descripcion, float valor) : base(cant, descripcion, valor) { }

    }
}
