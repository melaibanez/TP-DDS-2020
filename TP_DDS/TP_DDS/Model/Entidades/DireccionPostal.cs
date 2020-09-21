using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Entidades
{
    public class DireccionPostal
    {
        public string calle { get; set; }
        public string numero { get; set; }
        public string piso_depto { get; set; }
        public string ciudad { get; set; }
        public string provincia { get; set; }
        public string pais { get; set; }

        public DireccionPostal() { }


    }
}
