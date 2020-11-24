using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS.Model.Entidades;
using TP_DDS_MVC.Helpers.DB;

namespace TP_DDS_MVC.DAOs
{
    public class OrganizacionDAO
    {
        public static OrganizacionDAO instancia = null;
        public List<TipoOrganizacion> organizaciones = new List<TipoOrganizacion>();

        private OrganizacionDAO() { }

        public static OrganizacionDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new OrganizacionDAO();
            }
            return instancia;
        }

        public List<TipoOrganizacion> getOrganizaciones()
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.Organizaciones.ToList();
            }
        }

        public TipoOrganizacion getOrganizacion(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Organizaciones.Find(id);
            }
        }

        public TipoOrganizacion add(TipoOrganizacion organizacion)
        {
            TipoOrganizacion added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.Organizaciones.Add(organizacion);
            }

            return added;
        }
    }
}