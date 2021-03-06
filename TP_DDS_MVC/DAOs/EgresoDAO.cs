﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Helpers.DB;

namespace TP_DDS_MVC.DAOs
{
    public class EgresoDAO
    {
        public static EgresoDAO instancia = null;
        public List<Egreso> egresos = new List<Egreso>();

        private EgresoDAO() { }

        public static EgresoDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new EgresoDAO();
            }
            return instancia;
        }

        public List<Egreso> getEgresos(int idEntidad)
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.Egresos.Where(e=>e.idEntidad == idEntidad).ToList();
            }
        }

        public List<Egreso> getEgresosSinVincular()
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Egresos.Where(e=>e.idIngresoAsociado == null).ToList();
            }
        }

        public DocumentoComercial getDocComercial(int idEgreso)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.DocumentosComerciales.Where(e => e.idEgreso == idEgreso && e.tipo != "Presupuesto").SingleOrDefault();
            }
        }

        public Egreso getEgreso(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Egresos.Find(id);
            }
        }

        public Egreso add(Egreso egreso)
        {
            Egreso added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.Egresos.Add(egreso);
                context.SaveChanges();
            }

            return added;
        }
    }
}