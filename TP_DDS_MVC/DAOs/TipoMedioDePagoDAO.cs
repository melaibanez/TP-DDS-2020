using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Helpers.DB;

namespace TP_DDS_MVC.DAOs
{
    public class TipoMedioDePagoDAO
    {
        public static TipoMedioDePagoDAO instancia = null;
        public List<TipoMedioDePago> TipoMedioDePagos = new List<TipoMedioDePago>();

        private TipoMedioDePagoDAO() { }

        public static TipoMedioDePagoDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new TipoMedioDePagoDAO();
            }
            return instancia;
        }
        public TipoMedioDePago getMedioDePago(string id)
        {
            using (MyDBContext context = new MyDBContext())
            {

                return context.tipoMediosDePago.Find(id);
            }
        }
        public List<TipoMedioDePago> getMediosDePago()
        {

            using (MyDBContext context = new MyDBContext())
            {

                return context.tipoMediosDePago.ToList();
            }
        }


        public TipoMedioDePago add(TipoMedioDePago tipoMedioDePago)
        {
            TipoMedioDePago added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.tipoMediosDePago.Add(tipoMedioDePago);
                context.SaveChanges();
            }

            return added;
        }

    }
}