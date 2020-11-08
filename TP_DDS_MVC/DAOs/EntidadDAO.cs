using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using TP_DDS.Model.Entidades;
using TP_DDS.Model.Entidades.TiposEmpresa;
using TP_DDS.DB;

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

        public EntidadDAO add()
        {
            return this;
        }

        public void getEntidadByUserID(int id)
        {
            return;
        }
    }
}