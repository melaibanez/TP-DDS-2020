using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Helpers.DB;

namespace TP_DDS_MVC.DAOs
{
    public class MedioDePagoDAO
    {
        public static MedioDePagoDAO instancia = null;
        public List<MedioDePago> medioDePagos = new List<MedioDePago>();

        private MedioDePagoDAO() { }

        public static MedioDePagoDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new MedioDePagoDAO();
            }
            return instancia;
        }

        public List<MedioDePago> getMediosDePago()
        {

            using (MyDBContext context = new MyDBContext())
            {

                return context.MediosDePago.ToList();
            }
        }

        public MedioDePago getMedioDePago(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.MediosDePago.Find(id);
            }
        }

        public MedioDePago add(MedioDePago medioDePago)
        {
            MedioDePago added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.MediosDePago.Add(medioDePago);
                context.SaveChanges();
            }

            return added;
        }

        public void deleteMedioDePago(int idMedioDePago)
        {
            using (MyDBContext context = new MyDBContext())
            {
                var itemToRemove = context.MediosDePago.SingleOrDefault(x => x.idMedioPago == idMedioDePago); //returns a single item.

                if (itemToRemove != null)
                {
                    context.MediosDePago.Remove(itemToRemove);

                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("El medio de pago que quiere eliminar, no existe");
                }
            }
        }
    }
}