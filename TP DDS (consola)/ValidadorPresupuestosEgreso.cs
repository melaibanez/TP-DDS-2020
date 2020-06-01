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
            if(compra.cantMinimaPresupuestos > 0)
            {
                return cantidadIndicadaPresupuestos(compra) && esMenorPresupuesto(compra) && compraUsaPresupuesto(compra);
                //habria que poner los resultados en la bandeja de mensajes
            }
            else
            {
                Console.WriteLine("La compra no requiere presupuestos");
                return true;
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
