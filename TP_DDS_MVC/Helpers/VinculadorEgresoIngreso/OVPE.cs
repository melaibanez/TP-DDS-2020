using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Models.Ingresos;
using TP_DDS_MVC.Helpers.VinculadorEgresoIngreso;

namespace TP_DDS_MVC.Helpers.VinculadorEgresoIngreso
{
    public class OVPE : EstrategiaVinculador
    {
        public override void vincularCompras(List<Egreso> egresos, List<Ingreso> ingresos)
        {
         
            int cantidadEgresos = egresos.Count();
            int cantidadIngresosDisponibles = ingresos.Count();

            for (int i = 0; i < cantidadEgresos; i++)
            {
                for (int j = 0; j < cantidadIngresosDisponibles; j++)
                {
                    if (cumpleCondiciones(egresos.ElementAt(i), ingresos.ElementAt(j)))
                    {
                        asignarEgresoIngreso(egresos.ElementAt(i), ingresos.ElementAt(j));
                        break; //si ya asigno un egreso a un ingreso pasa al siguiente. Y vuelve a cero J para empezar de nuevo.
                    }
                }
            }
        }
    }
}