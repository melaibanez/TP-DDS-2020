using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Otros
{
    public class Notificacion
    {
        public DateTime fecha { get; set; }
        public string mensaje { get; set; }

        public Notificacion(string mensaje, DateTime fecha)
        {
            this.mensaje = mensaje;
            this.fecha = fecha;
        }

        override
        public string ToString()
        {
            return fecha.ToString() + " " + mensaje;
        }
    }
}
