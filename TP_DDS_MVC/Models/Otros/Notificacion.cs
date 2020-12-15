using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;

namespace TP_DDS_MVC.Models.Otros
{
    [Table("notificaciones")]
    public class Notificacion
    {

        [Key]
        public int idNotificacion { get; set; }

        public DateTime fecha { get; set; }

        [StringLength(300)]
        public string mensaje { get; set; }
        
        [ForeignKey("usuario")]
        public int idUsuario { get; set; }
        [BsonIgnore]
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