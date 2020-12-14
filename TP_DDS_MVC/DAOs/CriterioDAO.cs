using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Helpers.DB;

namespace TP_DDS_MVC.DAOs
{
    public class CriterioDAO
    {
        public static CriterioDAO instancia = null;
        public List<Criterio> criterios = new List<Criterio>();

        private CriterioDAO() { }

        public static CriterioDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new CriterioDAO();
            }
            return instancia;
        }

        public List<Criterio> getCriterios(int idEntidad)
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.Criterios.Where(c=> c.idEntidad == idEntidad).ToList();
            }
        }

        public Criterio getCriterio(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Criterios.Find(id);
            }
        }

        public Criterio add(Criterio criterio)
        {
            Criterio added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.Criterios.Add(criterio);
                context.SaveChanges();
            }

            return added;
        }
    }
}