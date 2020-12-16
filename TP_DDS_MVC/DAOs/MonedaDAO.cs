using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Helpers.DB;

namespace TP_DDS_MVC.DAOs
{
    public class MonedaDAO
    {
        public static MonedaDAO instancia = null;
        public List<Moneda> monedas = new List<Moneda>();

        private MonedaDAO() { }

        public static MonedaDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new MonedaDAO();
            }
            return instancia;
        }

        public List<Moneda> getMonedas()
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.Moneda.ToList();
            }
        }

        public Moneda getMoneda (string id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Moneda.Find(id);
            }
        }

        public Moneda add(Moneda moneda)
        {
            Moneda added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.Moneda.Add(moneda);
                context.SaveChanges();
            }

            return added;
        }
    }
}