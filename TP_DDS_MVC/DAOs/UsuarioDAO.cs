using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Otros;
using TP_DDS_MVC.Helpers.DB;
using TP_DDS_MVC.Models.Compras;

namespace TP_DDS_MVC.DAOs
{
    public class UsuarioDAO
    {
        public static UsuarioDAO instancia = null;
        public List<Usuario> usuarios = new List<Usuario>();

        private UsuarioDAO() { }

        public static UsuarioDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new UsuarioDAO();
            }
            return instancia;
        }

        public List<Usuario> getUsuarios(int idEntidad)
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.Usuarios.Include("comprasRevisadas").Where(u => u.idEntidad == idEntidad).ToList();
            }
        }

        public Usuario getUsuario(string username, string hashedPass)
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.Usuarios.Where(usr => usr.nombreUsuario == username && usr.contrasenia == hashedPass).SingleOrDefault();
            }
        }

        public Usuario getUsuario(int id)
        {
            using (MyDBContext context = new MyDBContext())
            {
                return context.Usuarios.Include("comprasRevisadas").Include("bandejaMensajes").Where(u=>u.idUsuario == id).SingleOrDefault();
            }
        }

        public Usuario add(Usuario usuario)
        {
            Usuario added;
            using (MyDBContext context = new MyDBContext())
            {
                added = context.Usuarios.Add(usuario);
            }

            return added;
        }

        public void agregarCompraRevisada(Compra compra, int idUsuario)
        {
            Usuario usu;
            using (MyDBContext context = new MyDBContext())
            {
                usu = context.Usuarios.Find(idUsuario);
                usu.comprasRevisadas.Add(compra);
                context.SaveChanges();
            }
        }

        public Usuario setIdEntidad(int idEntidad, int idUsuario)
        {
            Usuario usu;
            using (MyDBContext context = new MyDBContext())
            {
                usu = context.Usuarios.Find(idUsuario);
                usu.idEntidad = idEntidad;
                context.SaveChanges();
                return usu;
            }
        }

        public void enviarNotificacion(Notificacion Noti)
        {
            using(MyDBContext context = new MyDBContext())
            {
                context.Notificaciones.Add(Noti);
                context.SaveChanges();
            }
        }
    }
}