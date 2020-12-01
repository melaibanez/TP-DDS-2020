using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS_MVC.Models.Entidades;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Models.Ingresos;
using TP_DDS_MVC.Helpers.VinculadorEgresoIngreso;

namespace TP_DDS_MVC.Helpers.VinculadorEgresoIngreso
{
    public static class Vinculador
    {
        public static List<EstrategiaVinculador> estrategias;

        public static void ejecutar(Entidad entidad)
        {
            int cantCriterios = estrategias.Count();
            for (int i = 1; i < cantCriterios; i++)
            {
                List<Egreso> egresosSinVincular = entidad.GetComprasSinIngresoAsignado().Select(compra => compra.egreso).ToList();
                List<Ingreso> ingresosDisponibles = entidad.GetIngresosDisponibles();
                estrategias.ElementAt(i).vincularCompras(egresosSinVincular, ingresosDisponibles);
            }
        }

        public static void AsignarCriterioAlVinculador(List<EstrategiaVinculador> unCriterio)
        {
            estrategias = unCriterio;
        }
    }
}
