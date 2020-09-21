using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Otros
{
    public class Notificacion
    {

        [Key]
        public int idNotificacion { get; set; }

        public DateTime fecha { get; set; }

        [StringLength(300)]  
        public string mensaje { get; set; }

        [ForeignKey("usuario")]
        public int idUsuario { get; set; }
        public Usuario usuario { get; set; }

        public Notificacion() { }

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
