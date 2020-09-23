using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Compras;
using TP_DDS.Model.Entidades;

namespace TP_DDS
{
    public static class Global
    {
        public static List<Compra> comprasNoValidadas = new List<Compra>();

        public static List<Entidad> entidades { get; set; } 


    }
}
