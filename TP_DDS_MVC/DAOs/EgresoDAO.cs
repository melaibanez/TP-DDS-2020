using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS.Model.Compras;
using TP_DDS_MVC.Helpers.DB;

namespace TP_DDS_MVC.DAOs
{
    public class EgresoDAO
    {
        public static EgresoDAO instancia = null;
        public List<Egreso> egresos = new List<Egreso>();

        private EgresoDAO() { }

        public static EgresoDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new EgresoDAO();
            }
            return instancia;
        }

        public List<Egreso> getEgresos()
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.Egresos.ToList();
            }
        }

        public Egreso getEgreso(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Egresos.Find(id);
            }
        }

        public Egreso add(Egreso egreso)
        {
            Egreso added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.Egresos.Add(egreso);
            }

            return added;
        }
    }
}