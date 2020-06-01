using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_
{
    abstract class Entidad
    {
        public string nombreFicticio { get; set; }
        public List<Compra> comprasRealizadas { get; set; }

        public Entidad (string nombreFicticio)
        {
            this.nombreFicticio = nombreFicticio;
            this.comprasRealizadas = new List<Compra>();
        }
    }
}
