using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Compras;
using TP_DDS.Model.Otros;
using TP_DDS.Validadores;

namespace TP_DDS.Scheduler.Jobs
{
    public class JobValidadorPresupuestos : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Compra compra = (Compra)context.JobDetail.JobDataMap.Get("compra");

            if (!compra.fueVerificada)
            {
                await ValidadorPresupuestosEgreso.validar(compra);
            }
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

        public static void iniciarScheduler(Usuario usuario, Compra comp)
        {

            MyScheduler sched = MyScheduler.getInstance();

            sched.run();

            jobValidador(sched, comp); 

            System.Threading.Thread.Sleep(2000);// duermo el hilo para que le lleguen los mensajes y mostrarlos por pantalla
            foreach (Notificacion mensaje in usuario.getBandejaMensajes())
            {
                Console.WriteLine(mensaje.ToString());
            }

            sched.stop();


            Console.ReadLine(); //para que no se salga la consola apenas ejecuta
        }

    }
}
