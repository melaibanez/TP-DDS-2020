using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Helpers.DB;
using TP_DDS_MVC.Helpers;
using TP_DDS_MVC.Models.Otros;

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

        public List<Compra> getCompras(int idEntidad)
        {

            using (MyDBContext context = new MyDBContext())
            {

                return context.Compras.Where(i => i.idEntidad == idEntidad).ToList();
            }
        }

        public List<Compra> getComprasSinProyecto(int idEntidad)
        {

            using (MyDBContext context = new MyDBContext())
            {

                return context.Compras.Where(i => i.idEntidad == idEntidad && i.idProyecto==null).ToList();
            }
        }

        public void asociarCompraAProyecto(int idProyecto, int idCompra)
        {

            using (MyDBContext context = new MyDBContext())
            {
                Compra comp = context.Compras.Where(p => p.idCompra == idCompra).SingleOrDefault();
                if(comp.idProyecto != null)
                {
                    throw new Exception("Esta compra ya esta asociada a un proyecto");
                }
                comp.idProyecto = idProyecto;
                context.SaveChanges();
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
                return context.Compras.Include("revisores").Include("egreso.docsComerciales").Include("egreso.prestadorDeServicios").Include("egreso.medioDePago").Include("egreso.detalle.categorias").Where(x => x.idCompra == idCompra).FirstOrDefault();
            }
        }

        public Compra getCompraConEgreso(int idCompra)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Compras.Include("egreso.detalle").Where(x => x.idCompra == idCompra).FirstOrDefault();
            }

        }

        public Compra add (Compra compra)
        {
            Compra added;
            using (MyDBContext context = new MyDBContext())
            {
                for (int i = 0; i < compra.egreso.detalle.Count(); i++)
                {
                    if (compra.egreso.detalle.ElementAt(i).categorias != null)
                        compra.egreso.detalle.ElementAt(i).categorias = compra.egreso.detalle.ElementAt(i).categorias.Select(c => context.Categorias.Find(c.idCategoria)).ToList();
                }
                if (compra.revisores != null)
                    compra.revisores = compra.revisores.Select(c => context.Usuarios.Where(u => u.idUsuario == c.idUsuario).SingleOrDefault()).ToList();

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

        public void updateCompra(Compra compra)
        {
            using (MyDBContext context = new MyDBContext())
            {

                Compra comp = context.Compras.Include("egreso").Single(p => p.idCompra == compra.idCompra);
                if (comp != null)
                {
                    context.Entry(comp).CurrentValues.SetValues(compra);
                    context.Entry(comp.egreso).CurrentValues.SetValues(compra.egreso);
                    context.SaveChanges();
                }
            }
        }
    }
}