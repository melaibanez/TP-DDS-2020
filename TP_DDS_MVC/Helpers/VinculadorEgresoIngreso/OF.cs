using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS.Model.Compras;
using TP_DDS.Model.Ingresos;
using TP_DDS_MVC.Helpers.VinculadorEgresoIngreso;

namespace TP_DDS_MVC.Helpers.VinculadorEgresoIngreso
{
    public class OF : EstrategiaVinculador
    {
         public override void vincularCompras(List<Egreso> egresos, List<Ingreso> ingresos)
        {
            int cantidadEgresos = egresos.Count();
            int cantidadIngresosDisponibles = ingresos.Count();

            List<Egreso> egresosSinVincularOrder = egresos.OrderBy(egreso => egreso.fechaEgreso).ToList();
            List<Ingreso> ingresosDisponiblesOrder = ingresos.OrderBy(ingreso => ingreso.fechaDesde).ToList();
            for (int i = 0; i < cantidadEgresos; i++)
            {
                for (int j = 0; j < cantidadIngresosDisponibles; j++)
                {
                    if (cumpleCondiciones(egresosSinVincularOrder.ElementAt(i), ingresosDisponiblesOrder.ElementAt(j)))
                    {
                        asignarEgresoIngreso(egresosSinVincularOrder.ElementAt(i), ingresosDisponiblesOrder.ElementAt(j));
                        break;
                    }
                }
            }
        }
    }
}