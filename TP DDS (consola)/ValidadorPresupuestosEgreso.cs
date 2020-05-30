using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_
{
    class ValidadorPresupuestosEgreso
    {

        public bool validar (Compra compra)
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

        private bool cantidadIndicadaPresupuestos(Compra compra)
        {
            return compra.cantMinimaPresupuestos == compra.presupuestos.Count;
        }

        private bool esMenorPresupuesto(Compra compra)
        {

        }

        private bool compraUsaPresupuesto(Compra compra)
        {

        }
    }
}
