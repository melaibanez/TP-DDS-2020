using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Compras;

namespace TP_DDS.DB
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class MyDBContext : DbContext
    {

        public DbSet<Categoria> categorias { get; set; }

        // El string "dbConn" es el nombre del connection string definido en App.config
        public MyDBContext() : base("dbConn")
        {

            // Deshabilita la inicializacion mágica del ORM
            Database.SetInitializer<MyDBContext>(null);

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
           
        }
    }
}
