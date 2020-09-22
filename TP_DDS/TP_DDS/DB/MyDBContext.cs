using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Compras;
using TP_DDS.Model.Entidades;
using TP_DDS.Model.Entidades.TiposEmpresa;
using TP_DDS.Model.Ingresos;
using TP_DDS.Model.Otros;

namespace TP_DDS.DB
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class MyDBContext : DbContext
    {

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Criterio> Criterios { get; set; }
        public DbSet<DocumentoComercial> DocumentosComerciales { get; set; }
        public DbSet<Egreso> Egresos { get; set; }
        public DbSet<ItemEgreso> ItemsEgresos { get; set; }
        public DbSet<ItemPresupuesto> ItemsPresupuestos { get; set; }
        public DbSet<MedioDePago> MediosDePago { get; set; }
        public DbSet<PrestadorDeServicios> PrestadoresDeServicios { get; set; }
        public DbSet<Ingreso> Ingresos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Entidad> Entidades { get; set; }
        public DbSet<TipoOrganizacion> Organizaciones { get; set; }
        public DbSet<TipoEmpresa> TiposEmpresas { get; set; }
    



        // El string "dbConn" es el nombre del connection string definido en App.config
        public MyDBContext() : base("dbConn")
        {

            // Inicializacion seteada para que cada vez que se inicia borre la DB y la vuelva a crear
            Database.SetInitializer(new DropCreateDatabaseAlways<MyDBContext>());

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


        }
    }
}
