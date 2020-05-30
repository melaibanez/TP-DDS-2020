using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_
{
    class ValidadorPresupuestosEgreso
    {

        public bool validar (Compra compra)
        {
            return cantidadIndicadaPresupuestos(compra) && esMenorPresupuesto(compra) && compraUsaPresupuesto(compra);
        }

        private bool cantidadIndicadaPresupuestos(Compra compra)
        {

        }

        private bool esMenorPresupuesto(Compra compra)
        {

        }

        private bool compraUsaPresupuesto(Compra compra)
        {

        }
    }
}
