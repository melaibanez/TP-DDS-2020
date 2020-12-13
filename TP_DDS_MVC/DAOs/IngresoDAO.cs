using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Ingresos;
using TP_DDS_MVC.Helpers.DB;

namespace TP_DDS_MVC.DAOs
{
    public class IngresoDAO
    {
        public static IngresoDAO instancia = null;
        public List<Ingreso> ingresos = new List<Ingreso>();

        private IngresoDAO() { }

        public static IngresoDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new IngresoDAO();
            }
            return instancia;
        }

        public List<Ingreso> getIngresos()
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.Ingresos.ToList();
            }
        }

        public Ingreso getIngreso(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Ingresos.Find(id);
            }
        }

        public Ingreso add(Ingreso ingreso)
        {
            Ingreso added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.Ingresos.Add(ingreso);

            }

            return added;
        }
    }
}