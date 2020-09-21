using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Entidades;
using TP_DDS.Model.Entidades.TiposEmpresa;

namespace TP_DDS.Validadores
{
    public class CategorizadorOrg
    {
        public static int[,,] valoresCriterios = new int[4, 5, 2] {
            { {12, 15230000}, {7, 8500000}, {7, 29740000}, {15, 26540000}, {5, 12890000} },
            { {45, 90310000}, {30, 50950000}, {35, 178860000}, {60, 190410000}, {10, 48480000} },
            { {200, 503880000}, {165, 425170000}, {125, 1502750000}, {235, 1190330000}, {50, 345430000} },
            { {590, 755740000}, {535, 607210000}, {345, 2146810000}, {655, 1739590000}, {215, 547890000} }
        };

        public static Dictionary<string, int> sectores = new Dictionary<string, int> {
            {"Construccion", 0},
            {"Servicios", 1},
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
            int clasificacionElegida = 0;
            criterio = criterioPorActividad(emp.actividad);
            for (int i = 0; i <= criterio; i++)
            {
                if (clasificarPorCriterio(emp, i) > clasificacionElegida)
                {
                    clasificacionElegida = clasificarPorCriterio(emp, i);
                }
            }
            return declaracionDeEmpresa(emp, clasificacionElegida);
        }

        private static int clasificarPorCriterio(Empresa emp, int criterio)
        {
            int parametro;

            //seteo el parametro en funcion del criterio
            if (criterio == 0)
                parametro = emp.cantPersonal;
            else
                parametro = (int)emp.promedioVentas;

            switch (parametro)
            {
                case var expression when parametro < (valoresCriterios[0, sectores[emp.sector], criterio]):
                    return 0;
                case var expression when parametro < (valoresCriterios[1, sectores[emp.sector], criterio]):
                    return 1;
                case var expression when parametro < (valoresCriterios[2, sectores[emp.sector], criterio]):
                    return 2;
                case var expression when parametro < (valoresCriterios[3, sectores[emp.sector], criterio]):
                    return 3;
                default:
                    Console.WriteLine("Hubo un error");
                    return -1;
            }
        }

        private static Empresa declaracionDeEmpresa(Empresa emp, int categoria) //se fija si instanciar un nuevo objeto del tipo de la nueva categoria o devolver el original
                                                                                //dependiendo de si se cambio de categoria o no
        {
            switch (categoria)
            {
                case 0:
                    if (emp.tipoEmpresa.GetType().Name != "Micro")
                        emp.tipoEmpresa= new Micro();
                    return emp;
                case 1:
                    if (emp.tipoEmpresa.GetType().Name != "Pequenia")
                        emp.tipoEmpresa = new Pequenia();
                    return emp;
                case 2:
                    if (emp.tipoEmpresa.GetType().Name != "MedianaTramo1")
                        emp.tipoEmpresa = new MedianaTramo1();
                    return emp;
                case 3:
                    if (emp.tipoEmpresa.GetType().Name != "MedianaTramo2")
                        emp.tipoEmpresa = new MedianaTramo2();
                    return emp;
                default:
                    Console.WriteLine("Hay un error");
                    return emp;

            }
        }

        private static int criterioPorActividad(string actividad)
        {
            return 0;
        }
    }
}
