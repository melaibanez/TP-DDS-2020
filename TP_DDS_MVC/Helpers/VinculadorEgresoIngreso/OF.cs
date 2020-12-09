using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Models.Ingresos;
using TP_DDS_MVC.Helpers.VinculadorEgresoIngreso;

namespace TP_DDS_MVC.Helpers.VinculadorEgresoIngreso
{
    public class OF : EstrategiaVinculador
    {
        public override void vincularCompras(List<Egreso> egresos, List<Ingreso> ingresos)
        {

            List<Egreso> egresosOrdenado = egresos.OrderBy(egre => egre.fechaEgreso).ToList();
            List<Ingreso> ingresosOrdenado = ingresos.OrderBy(ingre => ingre.fechaHasta).ToList();

            for (int j = 0; j < ingresosOrdenado.Count(); j++)
            {
                for (int i = 0; i < egresosOrdenado.Count(); i++)
                {

                    if (cumpleCondiciones(egresosOrdenado.ElementAt(i), ingresosOrdenado.ElementAt(j)))
                    {
                        asignarEgresoIngreso(egresosOrdenado.ElementAt(i), ingresosOrdenado.ElementAt(j));
                        egresosOrdenado.RemoveAt(i);
                        break; //si ya asigno un egreso a un ingreso pasa al siguiente. Y vuelve a cero J para empezar de nuevo.
                    }
                }
            }

        }
    }
}