using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Entidades;
using TP_DDS.Model.Compras;
using TP_DDS.Model.Ingresos;

namespace TP_DDS.VinculadorEgresoIngreso
{
    class Vinculador
    {
        /*
         *La Entidad hace compras en forma desordenada y el unico limite que tiene son sus ingresos.
         *Entidad tiene Ingresos[] y comprasRealizadas[]
         * Compra tiene un egreso Asociado
         * Egreso tiene ingresoAsociado
         */

        public static void vincularCompras(Entidad entidad, List<string> criterios) {

            string criterio = criterios.First();
           
            if (criterio == "PE")
            {
                OrdenValorPrimeroEgreso(entidad);
            }

            if (criterio == "PI")
            {
                OrdenValorPrimeroIngreso(entidad);

            }
            if (criterio == "F")
            {
                OrdenFecha(entidad);
                
            }
            if (criterio == "MIX")
            {
                OrdenMix(entidad,criterios);
            }
        }
        /*----------------------------------*/

        private void OrdenValorPrimeroEgreso(Entidad entidad)
        {
            List<Egreso> egresosSinVincular = entidad.GetComprasSinIngresoAsignado().Select(compra => compra.egreso).ToList();
            List<Ingreso> ingresosDisponibles = entidad.GetIngresosDisponibles();
            int cantidadEgresos = egresosSinVincular.Count();
            int cantidadIngresosDisponibles = ingresosDisponibles.Count();

            List<Egreso> egresosSinVincularOrder = egresosSinVincular.OrderByDescending(egreso => egreso.montoTotal).ToList();

            for (int i = 0; i < cantidadEgresos; i++)
            {
                for (int j = 0; j < cantidadIngresosDisponibles; j++)
                {
                    if (cumpleCondiciones(egresosSinVincularOrder.ElementAt(i), ingresosDisponibles.ElementAt(j)))
                    {
                        asignarEgresoIngreso(egresosSinVincularOrder.ElementAt(i), ingresosDisponibles.ElementAt(j));
                        break; //si ya asigno un egreso a un ingreso pasa al siguiente. Y vuelve a cero J para empezar de nuevo.
                    }
                }
            }
        }

        private void OrdenValorPrimeroIngreso(Entidad entidad)
        {
            List<Egreso> egresosSinVincular = entidad.GetComprasSinIngresoAsignado().Select(compra => compra.egreso).ToList();
            List<Ingreso> ingresosDisponibles = entidad.GetIngresosDisponibles();
            int cantidadEgresos = egresosSinVincular.Count();
            int cantidadIngresosDisponibles = ingresosDisponibles.Count();

            //List<Egreso> egresosSinVincularOrder = egresosSinVincular.OrderByDescending(egreso => egreso.montoTotal).ToList();

            List<Ingreso> ingresosOrder = ingresosDisponibles.OrderByDescending(ingreso => ingreso.montoTotal).ToList();

            for (int i = 0; i < cantidadIngresosDisponibles; i++)
            {
                for (int j = 0; j < cantidadEgresos; j++)
                {
                    if (cumpleCondiciones(egresosSinVincular.ElementAt(j), ingresosDisponibles.ElementAt(i)))
                    {
                        asignarEgresoIngreso(egresosSinVincular.ElementAt(j), ingresosDisponibles.ElementAt(i));
                        break;
                    }
                }
            }
        }

        private void OrdenFecha(List<Egreso> egresosSinVincular, List<Ingreso> ingresosDisponibles)
        {
            List<Egreso> egresosSinVincular = entidad.GetComprasSinIngresoAsignado().Select(compra => compra.egreso).ToList();
            List<Ingreso> ingresosDisponibles = entidad.GetIngresosDisponibles();
            int cantidadEgresos = egresosSinVincular.Count();
            int cantidadIngresosDisponibles = ingresosDisponibles.Count();

            List<Egreso> egresosSinVincularOrder = egresosSinVincular.OrderBy(egreso => egreso.fechaEgreso).ToList();
            List<Ingreso> ingresosDisponiblesOrder = ingresosDisponibles.OrderBy(ingreso => ingreso.fechaDesde).ToList();
            for (int i = 0; i < cantidadEgresos; i++)
            {
                for (int j = 0; j < cantidadIngresosDisponibles; j++)
                {
                    if (cumpleCondiciones(egresosSinVincularOrder.ElementAt(i), ingresosDisponiblesOrder.ElementAt(j)))
                    {
                        asignarEgresoIngreso(egresosSinVincularOrder.ElementAt(i), ingresosDisponibles.ElementAt(j));
                        break;
                    }
                }
            }
        }

        private void OrdenMix(Entidad entidad, List<string> criterios)
        {
            int cantCriterios = criterios.Count();
            for (int i = 1; i < cantCriterios; i++)
            {
                if (criterios.ElementAt(i) == "PE") OrdenValorPrimeroEgreso(entidad);
                if (criterios.ElementAt(i) == "PI") OrdenValorPrimeroIngreso(entidad);
                if (criterios.ElementAt(i) == "F") OrdenFecha(entidad);
               // if (criterios.ElementAt(i) == "MIX") OrdenMix(entidad); ((((?
            }
        }

        private static void asignarEgresoIngreso(Egreso egreso, Ingreso ingreso)
        {
            egreso.ingresoAsociado = ingreso;
            ingreso.addEgresoAsociado(egreso);
        }

        /*
         * Justificacion de Diseño = si quiere agregar mas condiciones q agregue más métodos a cumpleCondiciones.
         */

        private static bool cumpleCondiciones(Egreso egreso, Ingreso ingreso)
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
