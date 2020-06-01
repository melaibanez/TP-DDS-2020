using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_
{
    class Notificador
    {
        public static void enviarMensajes(List<Usuario> usuarios, string mensaje)
        {
            foreach (Usuario usuario in usuarios) {
                usuario.recibirMensaje(new Notificacion(mensaje, DateTime.Now));
            }
        }
    }
}
