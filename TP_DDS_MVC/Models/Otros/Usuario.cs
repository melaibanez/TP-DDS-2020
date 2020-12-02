using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Models.Entidades;

namespace TP_DDS_MVC.Models.Otros
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }

        [StringLength(50)]
        public string nombreUsuario { get; set; }

        public bool esAdmin { get; set; }

        [StringLength(50)]
        public string contrasenia { get; set; }

        public List<Compra> comprasRevisadas { get; set; }

        public List<Notificacion> bandejaMensajes { get; set; }

        [ForeignKey("entidad")]
        public int idEntidad { get; set; }
        public Entidad entidad { get; set; }

        public Usuario(string nombreUsuario, bool esAdmin, string contrasenia, Entidad entidad)
        {
            this.nombreUsuario = nombreUsuario;
            this.esAdmin = esAdmin;
            this.contrasenia = contrasenia;
            this.bandejaMensajes = new List<Notificacion>();
            this.entidad = entidad;
        }

        public void recibirMensaje(Notificacion noti)
        {
            this.bandejaMensajes.Add(noti);
        }

    }
}