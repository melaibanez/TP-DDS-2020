using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Helpers.DB;
using System.Data.Entity;

namespace TP_DDS_MVC.DAOs
{
    public class PresupuestoDAO
    {
        public static PresupuestoDAO instancia = null;
        public List<Presupuesto> Presupuestos = new List<Presupuesto>();

        private PresupuestoDAO() { }

        public static PresupuestoDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new PresupuestoDAO();
            }
            return instancia;
        }

        public List<Presupuesto> getPresupuestos(int idEntidad)
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.DocumentosComerciales.OfType<Presupuesto>().Where(x=>x.idEntidad == idEntidad).ToList();
            }
        }

        public Presupuesto getPresupuesto(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.DocumentosComerciales.OfType<Presupuesto>().Include("items.categorias").Include("prestadorDeServicios").Include("medioDePago").Where(s => s.idDocComercial == id).FirstOrDefault<Presupuesto>();
                //return (Presupuesto)context.DocumentosComerciales.OfType<Presupuesto>().Include(p => p.items).Where(p => p.idDocComercial == id);
            }
        }

        public Presupuesto add(Presupuesto presupuesto)
        {
            Presupuesto added;
            using (MyDBContext context = new MyDBContext())
            {
                for (int i = 0; i < presupuesto.items.Count(); i++)
                {
                    if (presupuesto.items.ElementAt(i).categorias != null)
                        presupuesto.items.ElementAt(i).categorias = presupuesto.items.ElementAt(i).categorias.Select(c =>  context.Categorias.Find(c.idCategoria)).ToList();
                }

                added = (Presupuesto)context.DocumentosComerciales.Add(presupuesto);
                context.SaveChanges();
            }

            return added;
        }


        public void deletePresupuesto(int idPresupuesto)
        {
            using (MyDBContext context = new MyDBContext())
            {
                var itemToRemove = context.DocumentosComerciales.SingleOrDefault(x => x.idDocComercial == idPresupuesto); //returns a single item.

                if (itemToRemove != null)
                {
                    context.DocumentosComerciales.Remove(itemToRemove);

                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("El presupuesto que quiere eliminar, no existe");
                }
            }
        }

        //public void setProyectoId(idProyecto, idDoc){}

        public void setCompraId(int idCompra, int idPres) {
            Presupuesto pres;

            using (MyDBContext context = new MyDBContext())
            {
                pres = (Presupuesto)context.DocumentosComerciales.Where(dc => dc.idDocComercial == idPres).FirstOrDefault();
                pres.idCompra = idCompra;
                context.SaveChanges();
            }

        }
    }
}