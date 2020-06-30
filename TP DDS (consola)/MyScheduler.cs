﻿using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS__consola_
{
    class MyScheduler
    {
        private static MyScheduler instance = new MyScheduler();
        private static StdSchedulerFactory factory;
        private static IScheduler scheduler;

        private MyScheduler()
        {

        }

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

        public void agregarTask(IJobDetail job, ITrigger trigger)
        {
            scheduler.ScheduleJob(job, trigger);
        }
    }
}