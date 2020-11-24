using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS.Model.Compras;
using TP_DDS_MVC.Helpers.DB;

namespace TP_DDS_MVC.DAOs
{
    public class CompraDAO
    {
        public static CompraDAO instancia = null;
        public List<Compra> compras = new List<Compra>();

        private CompraDAO() { }

        public static CompraDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new CompraDAO();
            }
            return instancia;
        }

        public List<Compra> getCompras()
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.Compras.ToList();
            }
        }

        public Compra getCompra(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Compras.Find(id);
            }
        }

        public Compra add(Compra compra)
        {
            Compra added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.Compras.Add(compra);
            }

            return added;
        }
    }
}