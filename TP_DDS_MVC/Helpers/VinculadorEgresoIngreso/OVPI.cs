using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Models.Ingresos;
using TP_DDS_MVC.Helpers.VinculadorEgresoIngreso;

namespace TP_DDS_MVC.Helpers.VinculadorEgresoIngreso
{
    public class OVPI : EstrategiaVinculador
    {
        public override void vincularCompras(List<Egreso> egresos, List<Ingreso> ingresos)
        {


            List<Egreso> egresosOrdenado = egresos.OrderBy(egre => egre.montoTotal).ToList();
            List<Ingreso> ingresosOrdenado = ingresos.OrderBy(ingre => ingre.monto).ToList();

            for (int i = 0; i < egresosOrdenado.Count(); i++)
            {
                    for (int j = 0; j < ingresosOrdenado.Count(); j++)
                    {

                    if (cumpleCondiciones(egresosOrdenado.ElementAt(i), ingresosOrdenado.ElementAt(j)))
                    {
                        asignarEgresoIngreso(egresosOrdenado.ElementAt(i), ingresosOrdenado.ElementAt(j));
                        ingresosOrdenado.RemoveAt(j);
                        //j++;
                        break; //si ya asigno un egreso a un ingreso pasa al siguiente. Y vuelve a cero J para empezar de nuevo.
                    }
                }
            }



        }
    }
}