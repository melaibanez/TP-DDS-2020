using Quartz;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.DB;
using TP_DDS.Model.Compras;
using TP_DDS.Model.Entidades;
using TP_DDS.Model.Otros;
using TP_DDS.Scheduler;
using TP_DDS.Scheduler.Jobs;
using TP_DDS.Validadores;

namespace TP_DDS
{
    class Program
    {
        static void Main(string[] args)
        {
            
            pruebaDB();

            /*DireccionPostal dirPos = new DireccionPostal();
            ValidadorDireccionPostal.validarPais(dirPos);

            MyScheduler sched = MyScheduler.getInstance();

            sched.run();

            System.Threading.Thread.Sleep(2000);// duermo el hilo para que le lleguen los mensajes y mostrarlos por pantalla
            foreach (Notificacion mensaje in eze.bandejaMensajes)
            {
                Console.WriteLine(mensaje.ToString());
            }

            sched.stop();*/


            Console.ReadLine(); //para que no se salga la consola apenas ejecuta
            

        }

        private static void pruebaDB()
        {
            using (MyDBContext context = new MyDBContext())
            {
                DireccionPostal dirPos = new DireccionPostal();
                EntidadJuridica ent = new EntidadJuridica("Pepito y Asociados", null , "2201783276", dirPos, new List<EntidadBase>() , "Lo de Pepito", "asdf", "Comercio", 1502750800, 100);
                context.Entidades.Add(ent);

                Usuario eze = new Usuario("eze", "Admin", "utndds123", ent);
                context.Usuarios.Add(eze);

                MedioDePago mdp1 = new MedioDePago("Visa debito", "41764516725513");
                PrestadorDeServicios prest1 = new PrestadorDeServicios("proveedor 1", new DireccionPostal("calle falsa", "123",null, "Mar del Plata", "Buenos Aires", "Argentina"), "DNI", "4135123");
                List<ItemPresupuesto> listaDeItems1 = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 50, null), new ItemPresupuesto(1, "mesa", 100, null), new ItemPresupuesto(1, "lampara", 70, null) };
                Presupuesto pres1 = new Presupuesto("102734", "Presupuesto", listaDeItems1, prest1, mdp1);
                context.DocumentosComerciales.Add(pres1);

                PrestadorDeServicios prest2 = new PrestadorDeServicios("pepe", new DireccionPostal(), "DNI", "21065813");
                List<ItemPresupuesto> listaDeItems2 = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 90, null), new ItemPresupuesto(1, "mesa", 60, null), new ItemPresupuesto(1, "lampara", 4100, null) };
                Presupuesto pres2 = new Presupuesto("234165", "Presupuesto", listaDeItems2, prest2, new MedioDePago("Visa debito", "4513456134"));
                context.DocumentosComerciales.Add(pres2);

                PrestadorDeServicios prest3 = new PrestadorDeServicios("razonSocial2", new DireccionPostal(), "DNI", "41254632");
                List<ItemPresupuesto> listaDeItems3 = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 100, null), new ItemPresupuesto(1, "mesa", 85, null), new ItemPresupuesto(1, "lampara", 750, null) };
                Presupuesto pres3 = new Presupuesto("421567", "Presupuesto", listaDeItems3, prest3, new MedioDePago("Ticket", "526674516725513"));
                context.DocumentosComerciales.Add(pres3);


                List<ItemEgreso> listaDeItems4 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 50, null), new ItemEgreso(1, "mesa", 100, null), new ItemEgreso(1, "lampara", 70, null) };
                Egreso egre = new Egreso(listaDeItems4, new List<DocumentoComercial> { pres1 }, ent, DateTime.Now, null);
                Compra comp = new Compra(2, 678, egre, new List<Presupuesto> { pres1, pres2, pres3 }, new List<Usuario> { eze });
                context.Compras.Add(comp);

                context.SaveChanges();
            }
        }
    }
}