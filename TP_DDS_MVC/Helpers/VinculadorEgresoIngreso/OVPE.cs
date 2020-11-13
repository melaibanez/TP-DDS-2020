using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS.Model.Compras;
using TP_DDS.Model.Ingresos;
using TP_DDS_MVC.Helpers.VinculadorEgresoIngreso;

namespace TP_DDS_MVC.Helpers.VinculadorEgresoIngreso
{
    public class OVPE : EstrategiaVinculador
    {
        public override void vincularCompras(List<Egreso> egresos, List<Ingreso> ingresos)
        {
            List<Egreso> egresosSinVincular = entidad.GetComprasSinIngresoAsignado().Select(compra => compra.egreso).OrderBy(egreso => egreso.montoTotal).ToList();
            List<Ingreso> ingresosDisponibles = entidad.GetIngresosDisponibles().OrderBy(ingreso => ingreso.monto).ToList();
            int cantidadEgresos = egresosSinVincular.Count();
            int cantidadIngresosDisponibles = ingresosDisponibles.Count();

            for (int i = 0; i < cantidadEgresos; i++)
            {
                for (int j = 0; j < cantidadIngresosDisponibles; j++)
                {
                    if (cumpleCondiciones(egresosSinVincular.ElementAt(i), ingresosDisponibles.ElementAt(j)))
                    {
                        asignarEgresoIngreso(egresosSinVincular.ElementAt(i), ingresosDisponibles.ElementAt(j));
                        break; //si ya asigno un egreso a un ingreso pasa al siguiente. Y vuelve a cero J para empezar de nuevo.
                    }
                }
            }
        }
    }
}