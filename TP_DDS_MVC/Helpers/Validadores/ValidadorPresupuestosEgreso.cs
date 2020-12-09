﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Models.Otros;

namespace TP_DDS_MVC.Helpers.Validadores
{
    public class ValidadorPresupuestosEgreso
    {
        public static async Task validar(Compra compra)
        {
            compra.compraValidada = true;
            if (compra.cantMinimaPresupuestos > 0)
            {

                if (cantidadIndicadaPresupuestos(compra) && esMenorPresupuesto(compra) && compraUsaPresupuesto(compra))
                {
                    enviarMensajes(compra.revisores, "Todo bien");
                }
                else
                {
                    enviarMensajes(compra.revisores, "Hubo un error");
                }
            }
            else
            {
                Console.WriteLine("La compra no requiere presupuestos");
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
            return compra.cantMinimaPresupuestos <= compra.getCantPresupuestos();
        }

        private static bool esMenorPresupuesto(Compra compra)
        {
            //return !(compra.presupuestos.Any(presupuesto => compra.getEgreso().getPresupuestoElegido()!= presupuesto && presupuesto.getMontoTotal() <= compra.getEgreso().getPresupuestoElegido().getMontoTotal()));
            return compra.presupuestos.OrderBy(p => p.montoTotal).First() == compra.egreso.getPresupuestoElegido();
        }

        private static bool compraUsaPresupuesto(Compra compra)
        {
            return compra.presupuestos.Contains(compra.egreso.getPresupuestoElegido());
            //buscamos en la lista de presupuestos de la compra, si esta el presupuesto elegido
        }
    }
}
