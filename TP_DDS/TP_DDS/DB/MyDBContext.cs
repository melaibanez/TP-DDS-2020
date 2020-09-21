using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Compras;
using TP_DDS.Model.Ingresos;
using TP_DDS.Model.Otros;

namespace TP_DDS.DB
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class MyDBContext : DbContext
    {

        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Compra> compras { get; set; }
        public DbSet<Criterio> criterios { get; set; }
        public DbSet<DocumentoComercial> documentosComerciales { get; set; }
        public DbSet<Egreso> egresos { get; set; }
        public DbSet<ItemEgreso> itemsEgresos { get; set; }
        public DbSet<ItemPresupuesto> itemsPresupuestos { get; set; }
        public DbSet<MedioDePago> mediosDePago { get; set; }
        public DbSet<PrestadorDeServicios> prestadorDeServicios { get; set; }
        public DbSet<Ingreso> ingresos { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Notificacion> notificaciones { get; set; }


        // El string "dbConn" es el nombre del connection string definido en App.config
        public MyDBContext() : base("dbConn")
        {

            // Deshabilita la inicializacion mágica del ORM
            Database.SetInitializer<MyDBContext>(new DropCreateDatabaseAlways<MyDBContext>());

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


        }
    }
}
