using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS.Model.Entidades;
using TP_DDS_MVC.Helpers.DB;

namespace TP_DDS_MVC.DAOs
{
    public class DireccionPostalDAO
    {
        public static DireccionPostalDAO instancia = null;
        public List<DireccionPostal> direccionesPostales = new List<DireccionPostal>();

        private DireccionPostalDAO() { }

        public static DireccionPostalDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new DireccionPostalDAO();
            }
            return instancia;
        }

        public List<DireccionPostal> getdireccionesPostales()
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.DireccionesPostales.ToList();
            }
        }

        public DireccionPostal getDireccionPostal(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.DireccionesPostales.Find(id);
            }
        }

        public DireccionPostal add(DireccionPostal direccionPostal)
        {
            DireccionPostal added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.DireccionesPostales.Add(direccionPostal);
            }

            return added;
        }
    }
}