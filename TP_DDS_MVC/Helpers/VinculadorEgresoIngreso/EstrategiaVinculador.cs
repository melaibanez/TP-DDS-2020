using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Entidades;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Models.Ingresos;
using TP_DDS_MVC.Helpers.VinculadorEgresoIngreso;
using TP_DDS_MVC.Helpers.DB;
using TP_DDS_MVC.DAOs;

namespace TP_DDS_MVC.Helpers.VinculadorEgresoIngreso
{
    public class EstrategiaVinculador
    {
        public virtual void vincularCompras(List<Egreso> egresos, List<Ingreso> ingresos)
        {

        }

        public static void asignarEgresoIngreso(Egreso egreso, Ingreso ingreso)
        {

            using(MyDBContext context = new MyDBContext())
            {
                var egresoDB = context.Egresos.SingleOrDefault(e => e.idEgreso == egreso.idEgreso);
                egresoDB.idIngresoAsociado = ingreso.idIngreso;
                context.SaveChanges();
            }
         

        }

        /*
         * Justificacion de Diseño = si quiere agregar mas condiciones q agregue más métodos a cumpleCondiciones.
         */

        public static bool cumpleCondiciones(Egreso egreso, Ingreso ingreso)
        {
            bool resultado = ingreso.EgresosNoTotalizanMonto() && EntraEnPeriodo(egreso, ingreso) && CubreMonto(egreso, ingreso); ;
            return resultado;
        }

        private static bool EntraEnPeriodo(Egreso egreso, Ingreso ingreso)
        {
            // return egreso.fechaEgreso.CompareTo(ingreso.fechaDesde) >= 0 && egreso.fechaEgreso.CompareTo(ingreso.fechaHasta) <= 0;
           bool resultado = DateTime.Compare(egreso.fechaEgreso, ingreso.fechaDesde) >= 0 && DateTime.Compare(egreso.fechaEgreso, ingreso.fechaHasta) <= 0;
            return resultado;
        }

        private static bool CubreMonto(Egreso egreso, Ingreso ingreso)
        {
            bool resultado = (ingreso.monto - ingreso.montoTotalEgresosAsociados() - egreso.montoTotal) >= 0;
            return resultado;
        }

    }
}