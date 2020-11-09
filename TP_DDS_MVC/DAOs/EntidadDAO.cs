using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using TP_DDS.Model.Entidades;
using TP_DDS.Model.Entidades.TiposEmpresa;
using TP_DDS_MVC.Helpers.DB;

namespace TP_DDS_MVC.DAOs
{
    public class EntidadDAO
    {
        public static EntidadDAO instancia = null;
        public List<Entidad> entidades = new List<Entidad>();

        private EntidadDAO() { }

        public static EntidadDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new EntidadDAO();
            }
            return instancia;
        }

        public Entidad add(Entidad entidad)
        {
            Entidad added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.Entidades.Add(entidad);
            }

            return added;
        }

        public void getEntidadByUserID(int id)
        {
            return;
        }
    }
}