using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TP_DDS__consola_
{
    class Usuario
    {
        private string usuario;
        private string tipo;
        private string contrasenia;
        private List<Notificacion> bandejaMensajes;

        public Usuario(string usuario, string tipo, string contrasenia){
            this.usuario = usuario;
            this.tipo = tipo;
            this.contrasenia = contrasenia;
            this.bandejaMensajes = new List<Notificacion>();
        }

        public void recibirMensaje(Notificacion noti)
        {
            this.bandejaMensajes.Add(noti);
        }

        public List<Notificacion> getBandejaMensajes()
        {
            return bandejaMensajes;
        }

    }
}
