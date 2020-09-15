using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TP_DDS__consola_.Scheduler.Jobs;
using TP_DDS__consola_.Scheduler;
using TP_DDS__consola_.Model.Compras;
using TP_DDS__consola_.Model.Otros;
using TP_DDS__consola_.Model.Ingresos;
using TP_DDS__consola_.Model.Entidades;


namespace TP_DDS__consola_
{
    class Program
    {
        static void Main(string[] args)
        {
            EntidadJuridica ent = new EntidadJuridica("Entidad", "asd", "CUIT", "DireccionPostal", new List<EntidadBase>(), "asd", "asd", "Comercio", 1502750800, 100);

            Usuario eze = new Usuario("Eze", "Admin", "contraseña");
            
            PrestadorDeServicios prest1 = new PrestadorDeServicios("direccion1", "razonSocial1", "DNI", "4135123");
            List<Item> listaDeItems1 = new List<Item> { new Item(1, "silla", 50, null), new Item(1, "mesa", 100, null), new Item(1, "lampara", 70, null) };
            Presupuesto pres1 = new Presupuesto("1234","Presupuesto",listaDeItems1,prest1);

            PrestadorDeServicios prest2 = new PrestadorDeServicios("medrano 918", "pepe", "DNI", "21065813");
            List<Item> listaDeItems2 = new List<Item> { new Item(1, "silla", 90, null), new Item(1, "mesa", 60, null), new Item(1, "lampara", 4100, null) };
            Presupuesto pres2 = new Presupuesto("2365", "Presupuesto", listaDeItems2, prest2);

            PrestadorDeServicios prest3 = new PrestadorDeServicios("Direccion3", "razonSocial2", "DNI", "41254632");
            List<Item> listaDeItems3 = new List<Item> { new Item(1, "silla", 100, null), new Item(1, "mesa", 85, null), new Item(1, "lampara", 750, null) };
            Presupuesto pres3 = new Presupuesto("4567", "Presupuesto", listaDeItems3, prest3);

            Egreso egre = new Egreso(listaDeItems1, new List<DocumentoComercial> { pres1 }, ent, DateTime.Now, null, prest1, null);
            Compra comp = new Compra(2, 678, egre, new List<Presupuesto> { pres1, pres2, pres3 }, new List<Usuario> {eze}, false);



            MyScheduler sched = MyScheduler.getInstance();

            sched.run();

            jobValidador(sched, comp); 

            System.Threading.Thread.Sleep(2000);// duermo el hilo para que le lleguen los mensajes y mostrarlos por pantalla
            foreach (Notificacion mensaje in eze.getBandejaMensajes())
            {
                Console.WriteLine(mensaje.ToString());
            }

            sched.stop();
        }


        public static void jobValidador(MyScheduler sched, Compra compra) //hacerlo en MyScheduler
        {
            JobDataMap jobData = new JobDataMap();
            jobData.Add("compra", compra);

            IJobDetail jobVal = JobBuilder.Create<JobValidadorPresupuestos>()
                .WithIdentity("validadorDeCompra", "Validadores")
                .UsingJobData(jobData)
                .Build();

            ITrigger triggerVal = TriggerBuilder.Create()
                 .WithIdentity("triggerValidador", "Triggers")
                 .StartNow()
                 .WithSimpleSchedule(x => x
                     .WithIntervalInSeconds(2)
                     .RepeatForever())
                 .Build();

            sched.agregarTask(jobVal, triggerVal);

            
        }
    }
}
