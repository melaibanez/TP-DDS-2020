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

        public List<Ingreso> getIngresos(int idEntidad)
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.Ingresos.Where(i => i.idEntidad == idEntidad).ToList();
            }
        }

        public List<Ingreso> getIngresosSinProyecto(int idEntidad)
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.Ingresos.Where(i => i.idEntidad == idEntidad && i.idProyecto==null).ToList();
            }
        }

        public Ingreso getIngreso(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Ingresos.Include("egresosAsociados").Include("proyecto").Where(i=>i.idIngreso == id).FirstOrDefault();
            }
        }

        public void asociarIngresoAProyecto(int idProyecto, int idIngreso)
        {

            using (MyDBContext context = new MyDBContext())
            {
                Ingreso comp = context.Ingresos.Where(p => p.idIngreso == idIngreso).SingleOrDefault();
                comp.idProyecto = idProyecto;
                context.SaveChanges();
            }
        }

        public Ingreso add(Ingreso ingreso)
        {
            Ingreso added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.Ingresos.Add(ingreso);
                context.SaveChanges();
            }

            return added;
        }

        public void updateIngreso(Ingreso ingreso){
            {
                using (MyDBContext context = new MyDBContext())
                {

                    Ingreso ing = context.Ingresos.Single(p => p.idIngreso == ingreso.idIngreso);
                    if (ing != null)
                    {
                        context.Entry(ing).CurrentValues.SetValues(ingreso);
                        context.SaveChanges();
                    }
                }
            }
        }

        public void deleteIngreso(int idIngreso)
        {
            using (MyDBContext context = new MyDBContext())
            {
                var itemToRemove = context.Ingresos.SingleOrDefault(x => x.idIngreso == idIngreso); //returns a single item.

                if (itemToRemove != null)
                {
                    context.Ingresos.Remove(itemToRemove);

                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("El ingreso que quiere eliminar, no existe");
                }
            }

        }
    }
}