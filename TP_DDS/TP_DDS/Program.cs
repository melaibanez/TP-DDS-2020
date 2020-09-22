using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.DB;
using TP_DDS.Model.Compras;
using TP_DDS.Model.Entidades;
using TP_DDS.Model.Otros;
using TP_DDS.Model.Ingresos;
using TP_DDS.VinculadorEgresoIngreso;
using TP_DDS.Scheduler;
using TP_DDS.Scheduler.Jobs;
using TP_DDS.Validadores;

namespace TP_DDS
{
    class Program
    {
        static void Main(string[] args)
        {

           // using (MyDBContext context = new MyDBContext())
            //{

                DireccionPostal dirPos = new DireccionPostal();
                ValidadorDireccionPostal.validarPais(dirPos);

                EntidadJuridica ent = new EntidadJuridica("Entidad", "asd", "CUIT", null, new List<EntidadBase>(), "asd", "asd", "Comercio", 1502750800, 100);
                //context.Entidades.Add(ent);

                Usuario eze = new Usuario("Eze", "Admin", "contraseña");

                //context.Usuarios.Add(eze);


                PrestadorDeServicios prest1 = new PrestadorDeServicios("direccion1", "razonSocial1", "DNI", "4135123");
                /* List<ItemPresupuesto> listaDeItems1 = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 50, null), new ItemPresupuesto(1, "mesa", 100, null), new ItemPresupuesto(1, "lampara", 70, null) };
                 Presupuesto pres1 = new Presupuesto("1234", "Presupuesto", listaDeItems1, prest1);
                 context.DocumentosComerciales.Add(pres1);
                 context.SaveChanges();


                 PrestadorDeServicios prest2 = new PrestadorDeServicios("medrano 918", "pepe", "DNI", "21065813");
                 List<ItemPresupuesto> listaDeItems2 = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 90, null), new ItemPresupuesto(1, "mesa", 60, null), new ItemPresupuesto(1, "lampara", 4100, null) };
                 Presupuesto pres2 = new Presupuesto("2365", "Presupuesto", listaDeItems2, prest2);
                 context.DocumentosComerciales.Add(pres2);
                 PrestadorDeServicios prest3 = new PrestadorDeServicios("Direccion3", "razonSocial2", "DNI", "41254632");
                 List<ItemPresupuesto> listaDeItems3 = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 100, null), new ItemPresupuesto(1, "mesa", 85, null), new ItemPresupuesto(1, "lampara", 750, null) };
                 Presupuesto pres3 = new Presupuesto("4567", "Presupuesto", listaDeItems3, prest3);
                 context.DocumentosComerciales.Add(pres3);


                 List<ItemEgreso> listaDeItems4 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 50, null), new ItemEgreso(1, "mesa", 100, null), new ItemEgreso(1, "lampara", 70, null) };

                 Egreso egre = new Egreso(listaDeItems4, new List<DocumentoComercial> { pres1 }, ent, DateTime.Now, null, prest1, null);
                 Compra comp = new Compra(2, 678, egre, new List<Presupuesto> { pres1, pres2, pres3 }, new List<Usuario> { eze });



                 MyScheduler sched = MyScheduler.getInstance();

                 sched.run();



                 System.Threading.Thread.Sleep(2000);// duermo el hilo para que le lleguen los mensajes y mostrarlos por pantalla
                 foreach (Notificacion mensaje in eze.bandejaMensajes)
                 {
                     Console.WriteLine(mensaje.ToString());
                 }

                 sched.stop();


                 Console.ReadLine(); //para que no se salga la consola apenas ejecuta
             }
             */

                List<ItemEgreso> listaDeItems1 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 126312, null) };
                List<ItemPresupuesto> listaDeItems1p = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 126312, null) };
                List<ItemEgreso> listaDeItems2 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 1263, null) };
                List<ItemPresupuesto> listaDeItems2p = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 1263, null) };
                List<ItemEgreso> listaDeItems3 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 4365, null) };
                List<ItemPresupuesto> listaDeItems3p = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 4365, null) };
                List<ItemEgreso> listaDeItems4 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 126, null) };
                List<ItemPresupuesto> listaDeItems4p = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 126, null) };
                List<ItemEgreso> listaDeItems5 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 1248, null) };
                List<ItemPresupuesto> listaDeItems5p = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 1248, null) };
                List<ItemEgreso> listaDeItems6 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 12687, null) };
                List<ItemPresupuesto> listaDeItems6p = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 12687, null) };
                List<ItemEgreso> listaDeItems7 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 16348, null) };
                List<ItemPresupuesto> listaDeItems7p = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 16348, null) };
                List<ItemEgreso> listaDeItems8 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 1267, null) };
                List<ItemPresupuesto> listaDeItems8p = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 1267, null) };
                List<ItemEgreso> listaDeItems9 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 13, null) };
                List<ItemPresupuesto> listaDeItems9p = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 13, null) };
                List<ItemEgreso> listaDeItems10 = new List<ItemEgreso> { new ItemEgreso(1, "silla", 48, null) };
                List<ItemPresupuesto> listaDeItems10p = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 48, null) };

                Presupuesto pres1 = new Presupuesto("1234", "Presupuesto", listaDeItems1p, prest1);
                Presupuesto pres2 = new Presupuesto("1234", "Presupuesto", listaDeItems2p, prest1);
                Presupuesto pres3 = new Presupuesto("1234", "Presupuesto", listaDeItems3p, prest1);
                Presupuesto pres4 = new Presupuesto("1234", "Presupuesto", listaDeItems4p, prest1);
                Presupuesto pres5 = new Presupuesto("1234", "Presupuesto", listaDeItems5p, prest1);
                Presupuesto pres6 = new Presupuesto("1234", "Presupuesto", listaDeItems6p, prest1);
                Presupuesto pres7 = new Presupuesto("1234", "Presupuesto", listaDeItems7p, prest1);
                Presupuesto pres8 = new Presupuesto("1234", "Presupuesto", listaDeItems8p, prest1);
                Presupuesto pres9 = new Presupuesto("1234", "Presupuesto", listaDeItems9p, prest1);
                Presupuesto pres10 = new Presupuesto("1234", "Presupuesto", listaDeItems10p, prest1);

                Egreso egre1 = new Egreso(listaDeItems1, new List<DocumentoComercial> { pres1 }, ent, DateTime.Now, null, prest1, null);
                Compra comp1 = new Compra(1, 678, egre1, new List<Presupuesto> { pres1 }, new List<Usuario> { eze });
                Egreso egre2 = new Egreso(listaDeItems2, new List<DocumentoComercial> { pres2 }, ent, DateTime.Now, null, prest1, null);
                Compra comp2 = new Compra(1, 678, egre2, new List<Presupuesto> { pres2 }, new List<Usuario> { eze });
                Egreso egre3 = new Egreso(listaDeItems3, new List<DocumentoComercial> { pres3 }, ent, DateTime.Now, null, prest1, null);
                Compra comp3 = new Compra(1, 678, egre3, new List<Presupuesto> { pres3 }, new List<Usuario> { eze });
                Egreso egre4 = new Egreso(listaDeItems4, new List<DocumentoComercial> { pres4 }, ent, DateTime.Now, null, prest1, null);
                Compra comp4 = new Compra(1, 678, egre4, new List<Presupuesto> { pres4 }, new List<Usuario> { eze });
                Egreso egre5 = new Egreso(listaDeItems5, new List<DocumentoComercial> { pres5 }, ent, DateTime.Now, null, prest1, null);
                Compra comp5 = new Compra(1, 678, egre5, new List<Presupuesto> { pres5 }, new List<Usuario> { eze });
                Egreso egre6 = new Egreso(listaDeItems6, new List<DocumentoComercial> { pres6 }, ent, DateTime.Now, null, prest1, null);
                Compra comp6 = new Compra(1, 678, egre6, new List<Presupuesto> { pres6 }, new List<Usuario> { eze });
                Egreso egre7 = new Egreso(listaDeItems7, new List<DocumentoComercial> { pres7 }, ent, DateTime.Now, null, prest1, null);
                Compra comp7 = new Compra(1, 678, egre7, new List<Presupuesto> { pres7 }, new List<Usuario> { eze });
                Egreso egre8 = new Egreso(listaDeItems8, new List<DocumentoComercial> { pres8 }, ent, DateTime.Now, null, prest1, null);
                Compra comp8 = new Compra(1, 678, egre8, new List<Presupuesto> { pres8 }, new List<Usuario> { eze });
                Egreso egre9 = new Egreso(listaDeItems9, new List<DocumentoComercial> { pres9 }, ent, DateTime.Now, null, prest1, null);
                Compra comp9 = new Compra(1, 678, egre9, new List<Presupuesto> { pres9 }, new List<Usuario> { eze });
                Egreso egre10 = new Egreso(listaDeItems10, new List<DocumentoComercial> { pres10 }, ent, DateTime.Now, null, prest1, null);
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

           // }
                
            }
    }
}