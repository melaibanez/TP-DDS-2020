﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Helpers.DB;

namespace TP_DDS_MVC.DAOs
{
    public class CategoriaDAO
    {
        public static CategoriaDAO instancia = null;
        public List<Categoria> categorias = new List<Categoria>();

        private CategoriaDAO() { }

        public static CategoriaDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new CategoriaDAO();
            }
            return instancia;
        }

        public List<Categoria> getCategorias(int idEntidad)
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.Categorias.Include("criterio").Where(c => c.criterio.idEntidad == idEntidad).ToList();
            }
        }

        public Categoria getCategoria(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Categorias.Find(id);
            }
        }

        public Categoria add(Categoria categoria)
        {
            Categoria added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.Categorias.Add(categoria);
                context.SaveChanges();
            }

            return added;
        }
    }
}