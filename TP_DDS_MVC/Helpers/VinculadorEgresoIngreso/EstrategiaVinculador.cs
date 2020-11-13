using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS.Model.Entidades;
using TP_DDS.Model.Compras;
using TP_DDS.Model.Ingresos;
using TP_DDS_MVC.Helpers.VinculadorEgresoIngreso;

namespace TP_DDS_MVC.Helpers.VinculadorEgresoIngreso
{
    public class EstrategiaVinculador
    {
        public virtual void vincularCompras(List<Egreso> egresos, List<Ingreso> ingresos)
        {

        }

        public static void asignarEgresoIngreso(Egreso egreso, Ingreso ingreso)
        {
            egreso.ingresoAsociado = ingreso;
            ingreso.addEgresoAsociado(egreso);

        }

        /*
         * Justificacion de Diseño = si quiere agregar mas condiciones q agregue más métodos a cumpleCondiciones.
         */

        public static bool cumpleCondiciones(Egreso egreso, Ingreso ingreso)
        {
            return ingreso.EgresosNoTotalizanMonto() && EntraEnPeriodo(egreso, ingreso) && CubreMonto(egreso, ingreso);
        }

        private static bool EntraEnPeriodo(Egreso egreso, Ingreso ingreso)
        {
            return egreso.fechaEgreso.CompareTo(ingreso.fechaDesde) >= 0 && egreso.fechaEgreso.CompareTo(ingreso.fechaHasta) <= 0;
        }

        private static bool CubreMonto(Egreso egreso, Ingreso ingreso)
        {
            return (ingreso.monto - egreso.montoTotal) >= 0;
        }

    }
}