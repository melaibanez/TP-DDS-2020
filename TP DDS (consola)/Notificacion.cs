using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TP_DDS__consola_
{
    class Notificacion
    {
        private DateTime fecha;
        private string mensaje;

        public Notificacion (string mensaje, DateTime fecha)
        {
            this.mensaje = mensaje;
            this.fecha = fecha;
        }

        override
        public string ToString()
        {
            return fecha.ToString() +" "+ mensaje;
        }
    }
}
