using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS.Model.Otros;
using TP_DDS_MVC.Helpers.DB;

namespace TP_DDS_MVC.DAOs
{
    public class PaisDAO
    {
        public static PaisDAO instancia = null;
        public List<Pais> paises = new List<Pais>();

        private PaisDAO() { }

        public static PaisDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new PaisDAO();
            }
            return instancia;
        }

        public List<Pais> getPaises()
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.Paises.ToList();
            }
        }

        public Pais getPais(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Paises.Find(id);
            }
        }

        public Pais add(Pais pais)
        {
            Pais added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.Paises.Add(pais);
            }

            return added;
        }
    }
}