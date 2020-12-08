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
    public class Vinculador
    {
        public static List<EstrategiaVinculador> estrategias;
        public static EstrategiaVinculador estrategia {get; set; }

        public void ejecutar(Entidad entidad)
        {
            //int cantCriterios = estrategias.Count();
           // for (int i = 1; i < cantCriterios; i++)
            //{
                List<Egreso> egresosSinVincular = entidad.GetComprasSinIngresoAsignado().Select(compra => compra.egreso).ToList();
                List<Ingreso> ingresosDisponibles = entidad.GetIngresosDisponibles();
            estrategia.vincularCompras(egresosSinVincular, ingresosDisponibles);
               // estrategias.ElementAt(i).vincularCompras(egresosSinVincular, ingresosDisponibles);
            //}
        }

        public void AsignarCriterioAlVinculador(EstrategiaVinculador unCriterio)
        {
            estrategia = unCriterio;
        }
    }
}
