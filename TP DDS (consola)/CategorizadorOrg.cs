using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TP_DDS__consola_
{
    class CategorizadorOrg
    {
        public static int[,,] criterios = new int[4, 5, 2] {
            { {15230000, 12}, {8500000, 7}, {29740000, 7}, {26540000, 15}, {12890000, 5} },
            { {90310000, 45}, {50950000, 30}, {178860000, 35}, {190410000, 60}, {48480000, 10} },
            { {503880000, 200}, {425170000, 165}, {1502750000, 125}, {1190330000, 235}, {345430000, 50} },
            { {755740000, 590}, {607210000, 535}, {2146810000, 345}, {1739590000, 655}, {547890000, 215} }
        };

        public static Dictionary<string, int> sectores = new Dictionary<string, int> {
            {"Construccion", 0},
            {"servicios", 1},
            {"Comercio", 2},
            {"IndYMin", 3},
            {"Agropecuario", 4}
        };

        public static Dictionary<string, int> tipoEmpresa = new Dictionary<string, int> {
            {"Micro", 0},
            {"Pequenia", 1},
            {"Mediana Tramo 1", 2},
            {"Mediana Tramo 2", 3},
        };

        public static Empresa categorizar(Empresa emp)
        {
            int criterio;
            //aca hay que fijarse si el criterio
            //tiene que ser cant de empleados o promedio
            // de ventas en funcion de la actividad de la empresa
            criterio = criterioPorActividad(emp.actividad);
            return clasificarPorCriterio(emp, criterio);
        }

        private static Empresa clasificarPorCriterio(Empresa emp, int criterio)
        {
            int parametro;

            //seteo el parametro en funcion del criterio
            if (criterio == 1)
                parametro = emp.cantPersonal;
            else
                parametro = (int)emp.promedioVentas;

            switch (parametro)
            {
                case var expression when parametro < (criterios[0, sectores[emp.sector], criterio]):
                    return declaracionDeEmpresa(emp, tipoEmpresa["Micro"]);
                case var expression when parametro < (criterios[1, sectores[emp.sector], criterio]):
                    return declaracionDeEmpresa(emp, tipoEmpresa["Pequenia"]);
                case var expression when parametro < (criterios[2, sectores[emp.sector], criterio]):
                    return declaracionDeEmpresa(emp, tipoEmpresa["Mediana Tramo 1"]);
                case var expression when parametro < (criterios[3, sectores[emp.sector], criterio]):
                    return declaracionDeEmpresa(emp, tipoEmpresa["Mediana Tramo 2"]);
                default:
                    Console.WriteLine("Hubo un error");
                    return emp;
            }
        }

        private static Empresa declaracionDeEmpresa(Empresa emp, int categoria) //se fija si instanciar una nueva clase o devolver la original
                                                                               //dependiendo de si se cambio de categoria o no
        {
            switch (categoria)
            {
                case 0:
                    if (emp.GetType().Name == "Micro")
                        return emp;
                    return new Micro(emp.actividad, emp.sector, emp.promedioVentas, emp.cantPersonal);
                case 1:
                    if (emp.GetType().Name == "Pequenia")
                        return emp;
                    return new Pequenia(emp.actividad, emp.sector, emp.promedioVentas, emp.cantPersonal);
                case 2:
                    if (emp.GetType().Name == "MedianaTramo1")
                        return emp;
                    return new MedianaTramo1(emp.actividad, emp.sector, emp.promedioVentas, emp.cantPersonal);
                case 3:
                    if (emp.GetType().Name == "MedianaTramo2")
                        return emp;
                    return new MedianaTramo2(emp.actividad, emp.sector, emp.promedioVentas, emp.cantPersonal);
                default:
                    Console.WriteLine("Hay un error");
                    return emp;

            }
        }
        
        private static int criterioPorActividad (string actividad){
            return 0;
        }
}