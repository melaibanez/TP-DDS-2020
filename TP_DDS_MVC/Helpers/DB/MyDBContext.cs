using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Models.Entidades;
using TP_DDS_MVC.Models.Ingresos;
using TP_DDS_MVC.Models.Otros;
using TP_DDS_MVC.Models.Proyectos;

namespace TP_DDS_MVC.Helpers.DB
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class MyDBContext : DbContext
    {

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Criterio> Criterios { get; set; }
        public DbSet<DocumentoComercial> DocumentosComerciales { get; set; }
        public DbSet<DireccionPostal> DireccionesPostales { get; set; }
        public DbSet<Egreso> Egresos { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<MedioDePago> MediosDePago { get; set; }
        public DbSet<PrestadorDeServicios> PrestadoresDeServicios { get; set; }
        public DbSet<Ingreso> Ingresos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Entidad> Entidades { get; set; }
        public DbSet<TipoOrganizacion> Organizaciones { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<ProyectoFinanciamiento> Proyectos { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<Moneda> Moneda { get; set; }
        public DbSet<TipoMedioDePago> tipoMediosDePago { get; set; }


        // El string "dbConn" es el nombre del connection string definido en App.config
        public MyDBContext() : base("dbConn")
        {

            // Inicializacion seteada para que cada vez que se inicia borre la DB y la vuelva a crear
            Database.SetInitializer(new CreateDatabaseIfNotExists<MyDBContext>());

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

        }
    }
}
