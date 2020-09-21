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
using TP_DDS.Scheduler;
using TP_DDS.Scheduler.Jobs;
using TP_DDS.Validadores;

namespace TP_DDS
{
    class Program
    {
        static void Main(string[] args)
        {

            using (MyDBContext context = new MyDBContext())
            {

                DireccionPostal dirPos = new DireccionPostal();
                ValidadorDireccionPostal.validarPais(dirPos);

                EntidadJuridica ent = new EntidadJuridica("Entidad", "asd", "CUIT", null, new List<EntidadBase>(), "asd", "asd", "Comercio", 1502750800, 100);
                context.Entidades.Add(ent);

                Usuario eze = new Usuario("Eze", "Admin", "contraseña");

                context.Usuarios.Add(eze);
               

                PrestadorDeServicios prest1 = new PrestadorDeServicios("direccion1", "razonSocial1", "DNI", "4135123");
                List<ItemPresupuesto> listaDeItems1 = new List<ItemPresupuesto> { new ItemPresupuesto(1, "silla", 50, null), new ItemPresupuesto(1, "mesa", 100, null), new ItemPresupuesto(1, "lampara", 70, null) };
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


                JobValidadorPresupuestos.iniciarScheduler(eze, comp);
            }
           


        }
    }
}