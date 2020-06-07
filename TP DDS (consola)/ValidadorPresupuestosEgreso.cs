using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_DDS__consola_
{
    class ValidadorPresupuestosEgreso
    {
        public static bool validar (Compra compra)
        { 

            if (compra.cantMinimaPresupuestos > 0)
            {

                if (cantidadIndicadaPresupuestos(compra) && esMenorPresupuesto(compra) && compraUsaPresupuesto(compra))
                {
                    enviarMensajes(compra.getRevisores(), "Todo bien");
                    return true;
                }
                else
                {
                    enviarMensajes(compra.getRevisores(), "Hubo un error");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("La compra no requiere presupuestos");
                return true;
            }

     
        }

        public static void enviarMensajes(List<Usuario> usuarios, string mensaje)
        {
            foreach (Usuario usuario in usuarios)
            {
                usuario.recibirMensaje(new Notificacion(mensaje, DateTime.Now));
            }
        }

        private static bool cantidadIndicadaPresupuestos(Compra compra)
        {
            return compra.cantMinimaPresupuestos <= compra.presupuestos.Count;
        }

        private static bool esMenorPresupuesto(Compra compra)
        {
            //return !(compra.presupuestos.Any(presupuesto => compra.getEgreso().getPresupuestoElegido()!= presupuesto && presupuesto.getMontoTotal() <= compra.getEgreso().getPresupuestoElegido().getMontoTotal()));
            return compra.presupuestos.OrderBy(p => p.getMontoTotal()).First() == compra.getEgreso().getPresupuestoElegido();
        }

        private static bool compraUsaPresupuesto(Compra compra)
        {
            return compra.getPresupuestos().Contains(compra.getEgreso().getPresupuestoElegido());
            //buscamos en la lista de presupuestos de la compra, si alguna tiene el mismo prestador de servicios y además veo si tienen el mismo valorTotal
        }
    }
}
