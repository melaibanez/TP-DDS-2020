using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TP_DDS__consola_.Jobs;


namespace TP_DDS__consola_
{
    class Program
    {
        static void Main(string[] args)
        {
            EntidadJuridica ent = new EntidadJuridica("asd", "asd", "asd", "asd", new List<EntidadBase>(), "asd", "asd", "Comercio", 1502750800, 100);

            Usuario eze = new Usuario("eze", "Admin", "rgag");
            
            PrestadorDeServicios prest1 = new PrestadorDeServicios("calle falsa 123", "tuvieja", "DNI", "4135123");
            List<Item> listaDeItems1 = new List<Item> { new Item(1, "silla", 50), new Item(1, "mesa", 100), new Item(1, "lampara", 70) };
            Presupuesto pres1 = new Presupuesto("1234","Presupuesto",listaDeItems1,prest1);

            PrestadorDeServicios prest2 = new PrestadorDeServicios("medrano 918", "pepe", "DNI", "21065813");
            List<Item> listaDeItems2 = new List<Item> { new Item(1, "silla", 90), new Item(1, "mesa", 60), new Item(1, "lampara", 4100) };
            Presupuesto pres2 = new Presupuesto("2365", "Presupuesto", listaDeItems2, prest2);

            PrestadorDeServicios prest3 = new PrestadorDeServicios("calle real 321", "yvan eht nioj", "DNI", "1");
            List<Item> listaDeItems3 = new List<Item> { new Item(1, "silla", 100), new Item(1, "mesa", 85), new Item(1, "lampara", 750) };
            Presupuesto pres3 = new Presupuesto("4567", "Presupuesto", listaDeItems3, prest3);

            Egreso egre = new Egreso(listaDeItems1, new List<DocumentoComercial> { pres1 }, ent, DateTime.Now, null, prest1);
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


        public static void jobValidador(MyScheduler sched, Compra compra)
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
