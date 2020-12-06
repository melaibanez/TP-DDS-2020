﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Helpers.DB;

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

        public List<Presupuesto> getPresupuestos()
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.DocumentosComerciales.ToList().ConvertAll(x => (Presupuesto)x); ; //hay que ver como hacer para castear toda la lista al tipo Presupuesto porque esto devuelve una lista de documentos comerciales
            }
        }

        public Presupuesto getPresupuesto(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return (Presupuesto)context.DocumentosComerciales.Include("Presupuesto.items").Where(p=>p.idDocComercial == id);
            }
        }

        public Presupuesto add(Presupuesto presupuesto)
        {
            Presupuesto added;
            using (MyDBContext context = new MyDBContext())
            {
                added = (Presupuesto)context.DocumentosComerciales.Add(presupuesto);
                context.SaveChanges();
            }

            return added;
        }
    }
}