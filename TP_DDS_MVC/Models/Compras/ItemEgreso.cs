using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;

namespace TP_DDS_MVC.Models.Compras
{
    public class ItemEgreso : Item
    {

        [ForeignKey("egreso")] 
        public int idEgreso { get; set; }
        [BsonIgnore]
        public Egreso egreso { get; set; }

        public ItemEgreso() { }

        public ItemEgreso(int cant, string descripcion, float valor) : base(cant, descripcion, valor) { }

    }
}