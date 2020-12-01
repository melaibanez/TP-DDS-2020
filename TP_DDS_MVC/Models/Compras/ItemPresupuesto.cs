using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_DDS_MVC.Models.Compras
{
    public class ItemPresupuesto : Item
    {
        [ForeignKey("presupuesto")]
        public int idPresupuesto { get; set; }
        public Presupuesto presupuesto { get; set; }


        public ItemPresupuesto() { }

        public ItemPresupuesto(int cant, string descripcion, float valor) : base(cant, descripcion, valor) { }

    }
}