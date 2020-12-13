using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Proyectos;
using TP_DDS_MVC.Helpers.DB;
using TP_DDS_MVC.Models.Otros;

namespace TP_DDS_MVC.DAOs
{
    public class ProyectoFinanciamientoDAO
    {

        public static ProyectoFinanciamientoDAO instancia = null;
        public List<ProyectoFinanciamiento> categorias = new List<ProyectoFinanciamiento>();

        private ProyectoFinanciamientoDAO() { }

        public static ProyectoFinanciamientoDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new ProyectoFinanciamientoDAO();
            }
            return instancia;
        }

        public List<ProyectoFinanciamiento> getProyectos(int idEntidad)
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.Proyectos.Where(p => p.idEntidad == idEntidad).ToList();
            }
        }

        public ProyectoFinanciamiento getCategoria(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Proyectos.Find(id);
            }
        }

        public ProyectoFinanciamiento add(ProyectoFinanciamiento proyecto)
        {
            ProyectoFinanciamiento added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.Proyectos.Add(proyecto);
                context.SaveChanges();
            }

            return added;
        }

    }
}