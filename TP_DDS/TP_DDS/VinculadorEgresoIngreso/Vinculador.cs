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

            List<Egreso> egresosSinVincular = entidad.GetComprasSinIngresoAsignado().Select(compra=> compra.egreso).ToList();
            List<Ingreso> ingresosDisponibles = entidad.GetIngresosDispobibles();
            int cantidadEgresos = egresosSinVincular.Count();
            int cantidadIngresosDispobibles = ingresosDisponibles.Count();
            string criterio = criterios.First();
            /*
             *  
             */
            if (criterio == "PE")
            {
               List<Egreso> egresosSinVincularOrder = egresosSinVincular.OrderByDescending(egreso => egreso.montoTotal).ToList();
                for (int i = 0; i < cantidadEgresos; i++) {
                    for (int j = 0; j < cantidadIngresosDispobibles; j++) {
                        if (cumpleCondiciones(egresosSinVincularOrder.ElementAt(i), ingresosDisponibles.ElementAt(j)))
                        {
                            asignarEgresoIngreso(egresosSinVincularOrder.ElementAt(i), ingresosDisponibles.ElementAt(j));
                            break; //si ya asigno un egreso a un ingreso pasa al siguiente. Y vuelve a cero J para empezar de nuevo.
                        }
                    }
                }
            }

            if (criterio == "PI")
            {
                List<Ingreso> ingresosOrder = ingresosDisponibles.OrderByDescending(ingreso=> ingreso.montoTotal).ToList();
                for (int i = 0; i < cantidadIngresosDispobibles; i++)
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
            if (criterio == "F")
            {
                List<Egreso> egresosSinVincularOrder = egresosSinVincular.OrderByDescending(egreso => egreso.montoTotal).ThenBy(egreso => egreso.fechaEgreso).ToList();

            }
            if (criterio == "MIX")
            {
                List<Egreso> egresosSinVincularMix;

               // for
            }
        }

        private static void asignarEgresoIngreso(Egreso egreso, Ingreso ingreso)
        {
            egreso.ingresoAsociado = ingreso;
            ingreso.egresosAsociados.Add(egreso);
        }

        /*
         * Justificacion de Diseño = si quiere agregar mas condiciones q agregue más métodos a cumpleCondiciones.
         */

        private static bool cumpleCondiciones(Egreso egreso, Ingreso ingreso)
        {
            return EntraEnPeriodo(egreso, ingreso) && CubreMonto(egreso, ingreso);
        }

        private static bool EntraEnPeriodo(Egreso egreso, Ingreso ingreso)
        {
            return egreso.fechaEgreso.CompareTo(ingreso.fechaDesde) >= 0 && egreso.fechaEgreso.CompareTo(ingreso.fechaHasta) <= 0;
        }
        
        private static bool CubreMonto(Egreso egreso, Ingreso ingreso)
        {
            return (ingreso.montoTotal - egreso.montoTotal) >= 0; 
        }

    }
}
