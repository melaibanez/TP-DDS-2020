using Quartz;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Compras;
using TP_DDS.Model.Entidades;
using TP_DDS.Model.Otros;
using TP_DDS.Model.Ingresos;

namespace TP_DDS
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            PersistenciaDireccionPostal.persistirDatosAPI();

            pruebaDB();

            pruebaSched();

            DireccionPostal dirPos = new DireccionPostal("calle falsa", "123", null, "Mar del Plata", "Bs.As. Costa Atlántica", "Argentina");
            Console.WriteLine( ValidadorDireccionPostal.validarDireccionPostal(dirPos));
            


            System.Threading.Thread.Sleep(2000);

            Console.WriteLine("Fin");
            Console.ReadLine(); //para que no se salga la consola apenas ejecuta

            */
        }
        /*
        private static void pruebaDB()
        {
            using (MyDBContext context = new MyDBContext())
            {

                DireccionPostal dirPos = new DireccionPostal("Santa Rosa", "1622", "-", "Vicente López", "Buenos Aires", "Argentina");
                Console.WriteLine(ValidadorDireccionPostal.validarDireccionPostal(dirPos));

                EntidadJuridica ent = new EntidadJuridica("Pepito y Asociados", null , "2201783276", dirPos, new List<EntidadBase>() , "Lo de Pepito", "asdf", "Comercio", 1502750800, 100);

                context.Entidades.Add(ent);
                Usuario eze = new Usuario("eze", "Admin", "utndds123", ent);
                context.Usuarios.Add(eze);

                MedioDePago mdp1 = new MedioDePago("Visa debito", "41764516725513");
                PrestadorDeServicios prest1 = new PrestadorDeServicios("proveedor 1", new DireccionPostal("calle falsa", "123", null, "Mar del Plata", "Buenos Aires", "Argentina"), "DNI", "4135123");
                List<ItemPresupuesto> listaDeItems1 = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 50), new ItemPresupuesto(1, "mesa", 100), new ItemPresupuesto(1, "lampara", 70) };
                Presupuesto pres1 = new Presupuesto("102734", "Presupuesto", listaDeItems1, prest1, mdp1);
                context.DocumentosComerciales.Add(pres1);

                PrestadorDeServicios prest2 = new PrestadorDeServicios("pepe", new DireccionPostal(), "DNI", "21065813");
                List<ItemPresupuesto> listaDeItems2 = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 90), new ItemPresupuesto(1, "mesa", 60), new ItemPresupuesto(1, "lampara", 4100) };
                Presupuesto pres2 = new Presupuesto("234165", "Presupuesto", listaDeItems2, prest2, new MedioDePago("Visa debito", "4513456134"));
                context.DocumentosComerciales.Add(pres2);

                PrestadorDeServicios prest3 = new PrestadorDeServicios("razonSocial2", new DireccionPostal(), "DNI", "41254632");
                List<ItemPresupuesto> listaDeItems3 = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 100), new ItemPresupuesto(1, "mesa", 85), new ItemPresupuesto(1, "lampara", 750) };
                Presupuesto pres3 = new Presupuesto("421567", "Presupuesto", listaDeItems3, prest3, new MedioDePago("Ticket", "526674516725513"));
                context.DocumentosComerciales.Add(pres3);


                List<ItemEgreso> listaDeItems4 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 50), new ItemEgreso(1, "mesa", 100), new ItemEgreso(1, "lampara", 70) };
                Egreso egre = new Egreso(listaDeItems4, new List<DocumentoComercial> { pres1 }, ent, DateTime.Now, null);
                Compra comp = new Compra(2, 678, egre, new List<Presupuesto> { pres1, pres2, pres3 }, new List<Usuario> { eze });
                context.Compras.Add(comp);

                context.SaveChanges();
                Console.WriteLine("Presione enter para terminar la prueba");


                List<ItemEgreso> listaDeItems11 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 126312) };
                List<ItemPresupuesto> listaDeItems1p = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 126312) };
                List<ItemEgreso> listaDeItems22 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 1263) };
                List<ItemPresupuesto> listaDeItems2p = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 1263) };
                List<ItemEgreso> listaDeItems33 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 4365) };
                List<ItemPresupuesto> listaDeItems3p = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 4365) };
                List<ItemEgreso> listaDeItems44 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 126) };
                List<ItemPresupuesto> listaDeItems4p = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 126) };
                List<ItemEgreso> listaDeItems5 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 1248) };
                List<ItemPresupuesto> listaDeItems5p = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 1248) };
                List<ItemEgreso> listaDeItems6 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 12687) };
                List<ItemPresupuesto> listaDeItems6p = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 12687) };
                List<ItemEgreso> listaDeItems7 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 16348) };
                List<ItemPresupuesto> listaDeItems7p = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 16348) };
                List<ItemEgreso> listaDeItems8 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 1267) };
                List<ItemPresupuesto> listaDeItems8p = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 1267) };
                List<ItemEgreso> listaDeItems9 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 13) };
                List<ItemPresupuesto> listaDeItems9p = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 13) };
                List<ItemEgreso> listaDeItems10 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 48) };
                List<ItemPresupuesto> listaDeItems10p = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 48) };

                Presupuesto pres11 = new Presupuesto("1234", "Presupuesto", listaDeItems1p, prest1,mdp1);
                Presupuesto pres22 = new Presupuesto("1234", "Presupuesto", listaDeItems2p, prest1, mdp1);
                Presupuesto pres33 = new Presupuesto("1234", "Presupuesto", listaDeItems3p, prest1, mdp1);
                Presupuesto pres4 = new Presupuesto("1234", "Presupuesto", listaDeItems4p, prest1, mdp1);
                Presupuesto pres5 = new Presupuesto("1234", "Presupuesto", listaDeItems5p, prest1, mdp1);
                Presupuesto pres6 = new Presupuesto("1234", "Presupuesto", listaDeItems6p, prest1, mdp1);
                Presupuesto pres7 = new Presupuesto("1234", "Presupuesto", listaDeItems7p, prest1, mdp1);
                Presupuesto pres8 = new Presupuesto("1234", "Presupuesto", listaDeItems8p, prest1, mdp1);
                Presupuesto pres9 = new Presupuesto("1234", "Presupuesto", listaDeItems9p, prest1, mdp1);
                Presupuesto pres10 = new Presupuesto("1234", "Presupuesto", listaDeItems10p, prest1, mdp1);

                Egreso egre1 = new Egreso(listaDeItems11, new List<DocumentoComercial> { pres1 }, ent, DateTime.Now, null);
                Compra comp1 = new Compra(1, 678, egre1, new List<Presupuesto> { pres1 }, new List<Usuario> { eze });
                Egreso egre2 = new Egreso(listaDeItems22, new List<DocumentoComercial> { pres2 }, ent, DateTime.Now, null);
                Compra comp2 = new Compra(1, 678, egre2, new List<Presupuesto> { pres2 }, new List<Usuario> { eze });
                Egreso egre3 = new Egreso(listaDeItems33, new List<DocumentoComercial> { pres3 }, ent, DateTime.Now, null);
                Compra comp3 = new Compra(1, 678, egre3, new List<Presupuesto> { pres3 }, new List<Usuario> { eze });
                Egreso egre4 = new Egreso(listaDeItems44, new List<DocumentoComercial> { pres4 }, ent, DateTime.Now,  null);
                Compra comp4 = new Compra(1, 678, egre4, new List<Presupuesto> { pres4 }, new List<Usuario> { eze });
                Egreso egre5 = new Egreso(listaDeItems5, new List<DocumentoComercial> { pres5 }, ent, DateTime.Now,  null);
                Compra comp5 = new Compra(1, 678, egre5, new List<Presupuesto> { pres5 }, new List<Usuario> { eze });
                Egreso egre6 = new Egreso(listaDeItems6, new List<DocumentoComercial> { pres6 }, ent, DateTime.Now,   null);
                Compra comp6 = new Compra(1, 678, egre6, new List<Presupuesto> { pres6 }, new List<Usuario> { eze });
                Egreso egre7 = new Egreso(listaDeItems7, new List<DocumentoComercial> { pres7 }, ent, DateTime.Now,   null);
                Compra comp7 = new Compra(1, 678, egre7, new List<Presupuesto> { pres7 }, new List<Usuario> { eze });
                Egreso egre8 = new Egreso(listaDeItems8, new List<DocumentoComercial> { pres8 }, ent, DateTime.Now,  null);
                Compra comp8 = new Compra(1, 678, egre8, new List<Presupuesto> { pres8 }, new List<Usuario> { eze });
                Egreso egre9 = new Egreso(listaDeItems9, new List<DocumentoComercial> { pres9 }, ent, DateTime.Now,  null);
                Compra comp9 = new Compra(1, 678, egre9, new List<Presupuesto> { pres9 }, new List<Usuario> { eze });
                Egreso egre10 = new Egreso(listaDeItems10, new List<DocumentoComercial> { pres10 }, ent, DateTime.Now, null);
                Compra comp10 = new Compra(1, 678, egre10, new List<Presupuesto> { pres10 }, new List<Usuario> { eze });

                Ingreso ingre1 = new Ingreso("prestamo", 7842, null);
                Ingreso ingre2 = new Ingreso("prestamo", 23734, null);
                Ingreso ingre3 = new Ingreso("prestamo", 127623, null);
                Ingreso ingre4 = new Ingreso("prestamo", 1273, null);
                Ingreso ingre5 = new Ingreso("prestamo", 12673, null);
                Ingreso ingre6 = new Ingreso("prestamo", 27, null);
                Ingreso ingre7 = new Ingreso("prestamo", 1632, null);
                Ingreso ingre8 = new Ingreso("prestamo", 1554, null);
                Ingreso ingre9 = new Ingreso("prestamo", 16327, null);
                Ingreso ingre10 = new Ingreso("prestamo", 1563, null);

                ent.AgregarCompra(comp1);
                ent.AgregarCompra(comp2);
                ent.AgregarCompra(comp3);
                ent.AgregarCompra(comp4);
                ent.AgregarCompra(comp5);
                ent.AgregarCompra(comp6);
                ent.AgregarCompra(comp7);
                ent.AgregarCompra(comp8);
                ent.AgregarCompra(comp9);
                ent.AgregarCompra(comp10);

                ent.AgregarIngreso(ingre1);
                ent.AgregarIngreso(ingre2);
                ent.AgregarIngreso(ingre3);
                ent.AgregarIngreso(ingre4);
                ent.AgregarIngreso(ingre5);
                ent.AgregarIngreso(ingre6);
                ent.AgregarIngreso(ingre7);
                ent.AgregarIngreso(ingre8);
                ent.AgregarIngreso(ingre9);
                ent.AgregarIngreso(ingre10);


                List<string> primeroEgreso = new List<string>();
                primeroEgreso.Add( "PE");
                Vinculador.vincularCompras(ent, primeroEgreso);

                Console.WriteLine(ent.comprasRealizadas.ElementAt(8).egreso.montoTotal + " " + ent.comprasRealizadas.ElementAt(8).egreso.ingresoAsociado.monto);
                Console.WriteLine("Termino el programa");
                Console.ReadLine();

                
            }


        }

       private static void pruebaSched()
        {
            DireccionPostal dirPos = new DireccionPostal();
            EntidadJuridica ent = new EntidadJuridica("Pepito y Asociados", null, "2201783276", dirPos, new List<EntidadBase>(), "Lo de Pepito", "asdf", "Comercio", 1502750800, 100);
        

            Usuario eze = new Usuario("eze", "Admin", "utndds123", ent);

            MedioDePago mdp1 = new MedioDePago("Visa debito", "41764516725513");
            PrestadorDeServicios prest1 = new PrestadorDeServicios("proveedor 1", new DireccionPostal("calle falsa", "123", null, "Mar del Plata", "Buenos Aires", "Argentina"), "DNI", "4135123");
            List<ItemPresupuesto> listaDeItems1 = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 50), new ItemPresupuesto(1, "mesa", 100), new ItemPresupuesto(1, "lampara", 70) };
            Presupuesto pres1 = new Presupuesto("102734", "Presupuesto", listaDeItems1, prest1, mdp1);

            PrestadorDeServicios prest2 = new PrestadorDeServicios("pepe", new DireccionPostal(), "DNI", "21065813");
            List<ItemPresupuesto> listaDeItems2 = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 90), new ItemPresupuesto(1, "mesa", 60), new ItemPresupuesto(1, "lampara", 4100) };
            Presupuesto pres2 = new Presupuesto("234165", "Presupuesto", listaDeItems2, prest2, new MedioDePago("Visa debito", "4513456134"));

            PrestadorDeServicios prest3 = new PrestadorDeServicios("razonSocial2", new DireccionPostal(), "DNI", "41254632");
            List<ItemPresupuesto> listaDeItems3 = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 100), new ItemPresupuesto(1, "mesa", 85), new ItemPresupuesto(1, "lampara", 750) };
            Presupuesto pres3 = new Presupuesto("421567", "Presupuesto", listaDeItems3, prest3, new MedioDePago("Ticket", "526674516725513"));

            List<ItemEgreso> listaDeItems4 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 50), new ItemEgreso(1, "mesa", 100), new ItemEgreso(1, "lampara", 70) };
            Egreso egre = new Egreso(listaDeItems4, new List<DocumentoComercial> { pres1 }, ent, DateTime.Now, null);
            Compra comp = new Compra(2, 678, egre, new List<Presupuesto> { pres1, pres2, pres3 }, new List<Usuario> { eze });

            MyScheduler sched = MyScheduler.getInstance();

            sched.run();

            MyScheduler.agregarJobValidador();

            /* System.Threading.Thread.Sleep(2000);// duermo el hilo para que le lleguen los mensajes y mostrarlos por pantalla
             foreach (Notificacion mensaje in eze.bandejaMensajes)
             {
                 Console.WriteLine(mensaje.ToString());
             }

            //sched.stop();

        }
    */
    }
}