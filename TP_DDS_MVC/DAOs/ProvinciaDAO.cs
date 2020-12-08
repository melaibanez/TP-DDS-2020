using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Otros;
using TP_DDS_MVC.Helpers.DB;

namespace TP_DDS_MVC.DAOs
{
    public class ProvinciaDAO
    {
        public static ProvinciaDAO instancia = null;
        public List<Provincia> provincias = new List<Provincia>();

        private ProvinciaDAO() { }

        public static ProvinciaDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new ProvinciaDAO();
            }
            return instancia;
        }

        public List<Provincia> getProvincias()
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.Provincias.ToList();
            }
        }

        public Provincia getProvincia(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Provincias.Find(id);
            }
        }

        public Provincia getProvinciaByName(string nombre)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Provincias.Where(p=>p.nombre == nombre).FirstOrDefault<Provincia>();
               
            }
        }
        public Provincia add(Provincia provincia)
        {
            Provincia added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.Provincias.Add(provincia);
            }

            return added;
        }
    }
}