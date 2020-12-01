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
            int cantidadEgresos = egresos.Count();
            int cantidadIngresosDisponibles = ingresos.Count();


            for (int i = 0; i < cantidadIngresosDisponibles; i++)
            {
                for (int j = 0; j < cantidadEgresos; j++)
                {
                    if (egresos.Count()>0 && cumpleCondiciones(egresos.ElementAt(j), ingresos.ElementAt(i)))
                    {
                        asignarEgresoIngreso(egresos.ElementAt(j), ingresos.ElementAt(i));
                        egresos = egresos.FindAll(egreso => egreso.ingresoAsociado != null).ToList();
                        break;
                    }
                }
            }
        }
    }
}