﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Entidades;
using TP_DDS_MVC.Models.Entidades.TiposEmpresa;
using TP_DDS_MVC.Helpers.DB;

namespace TP_DDS_MVC.DAOs
{
    public class EntidadDAO
    {
        public static EntidadDAO instancia = null;
        public List<Entidad> entidades = new List<Entidad>();

        private EntidadDAO() { }

        public static EntidadDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new EntidadDAO();
            }
            return instancia;
        }

        public Entidad add(Entidad entidad)
        {
            Entidad added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.Entidades.Add(entidad);
                context.SaveChanges();
            }

            return added;
        }

        public void getEntidadByUserID(int id)
        {
            return;
        }

        public Entidad getEntidad(int id)
        {
            using(MyDBContext context = new MyDBContext())
            {
                return context.Entidades.Include("comprasRealizadas").Include("ingresos").Include("egresos").Where(e=>e.idEntidad == id).FirstOrDefault();
            }
           
        }

        public Entidad getEntidadBase(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Entidades.Include("comprasRealizadas").Include("ingresos").Include("egresos").Where(e => e.idEntidad == id).FirstOrDefault();
            }

        }

        public Entidad getEntidadJuridica(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Entidades.Include("comprasRealizadas").Include("ingresos").Include("egresos").Include("direccionPostal").Where(e => e.idEntidad == id).FirstOrDefault();
            }
        }

        public List<EntidadJuridica> getEntidadesJuridicas()
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Entidades.OfType<EntidadJuridica>().ToList();
            }
        }
    }
}