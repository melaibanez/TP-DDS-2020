using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Compras;

namespace TP_DDS_MVC.Helpers
{
    public class JsonEgreso
    {
        public Egreso egreso { get; set; }
        public string[] docsComerciales { get; set; }
    }


    public class JsonCompra
    {
        public Compra compra { get; set; }
        public int[] revisores { get; set; }
    }
}