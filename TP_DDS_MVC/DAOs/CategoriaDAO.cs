using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS.Model.Compras;
using TP_DDS_MVC.Helpers.DB;

namespace TP_DDS_MVC.DAOs
{
    public class CategoriaDAO
    {
        public static CategoriaDAO instancia = null;
        public List<Categoria> categorias = new List<Categoria>();

        private CategoriaDAO() { }

        public static CategoriaDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new CategoriaDAO();
            }
            return instancia;
        }

        public List<Categoria> getCategorias()
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.Categorias.ToList();
            }
        }

        public Categoria getCategoria(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Categorias.Find(id);
            }
        }

        public Categoria add(Categoria categoria)
        {
            Categoria added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.Categorias.Add(categoria);
            }

            return added;
        }
    }
}