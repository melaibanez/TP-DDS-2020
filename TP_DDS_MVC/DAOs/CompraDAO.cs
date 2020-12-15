using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Compras;
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

        public List<Compra> getComprasConEgreso(int idEntidad)
        {

            using (MyDBContext context = new MyDBContext())
            {

                return context.Compras.Include("egreso").Where(i => i.idEntidad == idEntidad).ToList();
            }
        }

        public Compra getCompra(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Compras.Find(id);
            }
        }

        public Compra getCompraConEgresoYDocumentos(int idCompra)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Compras.Include("egreso.docsComerciales").Where(x => x.idCompra == idCompra).FirstOrDefault();
            }
        }

        public Compra getCompraConEgreso(int idCompra)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Compras.Include("egreso.detalle").Where(x => x.idCompra == idCompra).FirstOrDefault();
            }

        }

        public Compra add(Compra compra)
        {
            Compra added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.Compras.Add(compra);
                context.SaveChanges();
            }

            return added;
        }

        public void deleteCompra(int idCompra)
        {
            using (MyDBContext context = new MyDBContext())
            {
                var itemToRemove = context.Compras.Include("egreso").SingleOrDefault(x => x.idCompra == idCompra); //returns a single item.

                if (itemToRemove != null)
                {
                    context.Egresos.Remove(itemToRemove.egreso); //Elimino la compra y el egreso asociado
                    context.Compras.Remove(itemToRemove);
                   
                    context.SaveChanges();
                } else
                {
                    throw new Exception("La compra que quiere eliminar, no existe");
                }
            }
            
        }
    }
}