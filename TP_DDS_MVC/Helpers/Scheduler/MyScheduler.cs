using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Compras;
using TP_DDS_MVC.Helpers.Scheduler.Jobs;

namespace TP_DDS_MVC.Helpers.Scheduler
{

    public class MyScheduler
    {
        private static MyScheduler instance = new MyScheduler();
        private static StdSchedulerFactory factory;
        private static IScheduler scheduler;

        private MyScheduler() { }

        public static MyScheduler getInstance()
        {
            MyScheduler.doInstance();
            return MyScheduler.instance;
        }

        private static async void doInstance()
        {

            if (instance != null)
            {
                factory = new StdSchedulerFactory();
                scheduler = await factory.GetScheduler();
            }

        }

        public async void run()
        {
            await scheduler.Start();
        }

        public async void stop()
        {
            await scheduler.Shutdown();
        }


        public static void agregarJobValidador() 
        {
           

            IJobDetail jobVal = JobBuilder.Create<JobValidadorPresupuestos>()
                .WithIdentity("validadorDeCompra", "Validadores")
                .Build();

            ITrigger triggerVal = TriggerBuilder.Create()
                 .WithIdentity("triggerValidador", "Triggers")
                 .StartNow()
                 .WithSimpleSchedule(x => x
                     .WithIntervalInSeconds(1)
                     .RepeatForever())
                 .Build();

            
            scheduler.ScheduleJob(jobVal, triggerVal);

        }

      

            
        

    }
}
