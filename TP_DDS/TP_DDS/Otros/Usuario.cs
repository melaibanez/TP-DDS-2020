using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Compras;

namespace TP_DDS.Model.Otros
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }

        [StringLength(50)]
        private string nombreUsuario { get; set; }

        [StringLength(50)]
        private string tipo { get; set; }

        [StringLength(50)]
        private string contrasenia { get; set; }

        public List<Compra> comprasRevisadas { get; set; }

        private List<Notificacion> bandejaMensajes { get; set; }

        public Usuario(string numbreUsuario, string tipo, string contrasenia)
        {
            this.nombreUsuario = nombreUsuario;
            this.tipo = tipo;
            this.contrasenia = contrasenia;
            this.bandejaMensajes = new List<Notificacion>();
        }

        public void recibirMensaje(Notificacion noti)
        {
            this.bandejaMensajes.Add(noti);
        }

    }
}
