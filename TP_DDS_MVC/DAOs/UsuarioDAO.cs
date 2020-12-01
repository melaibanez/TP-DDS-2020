using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Otros;
using TP_DDS_MVC.Helpers.DB;

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

        public List<Usuario> getUsuarios()
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.Usuarios.ToList();
            }
        }

        public Usuario getUsuario(string username, string password)
        {

            using (MyDBContext context = new MyDBContext())
            {
                return context.Usuarios.Where(usr => usr.nombreUsuario == username && usr.contrasenia == password).SingleOrDefault();
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
    }
}