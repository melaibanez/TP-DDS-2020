using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS.Model.Otros;
using TP_DDS_MVC.Helpers.DB;

namespace TP_DDS_MVC.DAOs
{
    public class CiudadDAO
    {
        public static CiudadDAO instancia = null;
        public List<Ciudad> ciudades = new List<Ciudad>();

        private CiudadDAO() { }

        public static CiudadDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new CiudadDAO();
            }
            return instancia;
        }

        public List<Ciudad> getCiudades()
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.Ciudades.ToList();
            }
        }

        public Ciudad getCiudad(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Ciudades.Find(id);
            }
        }

        public Ciudad add(Ciudad ciudad)
        {
            Ciudad added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.Ciudades.Add(ciudad);
            }

            return added;
        }
    }
}