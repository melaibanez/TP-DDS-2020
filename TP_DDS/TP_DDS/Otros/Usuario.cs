﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Otros
{
    public class Usuario
    {
        private string usuario;
        private string tipo;
        private string contrasenia;
        private List<Notificacion> bandejaMensajes;

        public Usuario(string usuario, string tipo, string contrasenia)
        {
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