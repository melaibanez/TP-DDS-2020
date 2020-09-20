using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Otros
{
    [Table("notificacion")]
    public class Notificacion
    {

        [Key]
        [Column("idNotificacion")]
        public int idNotificacion { get; set; }

        [Column("fecha")]
        public DateTime fecha { get; set; }

        [Column("mensaje")]   
        public string mensaje { get; set; }

        [Column("idUsuario")]
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
