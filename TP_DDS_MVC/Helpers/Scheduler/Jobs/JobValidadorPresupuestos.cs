using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Compras;
using TP_DDS_MVC.Helpers.Validadores;
using TP_DDS;

namespace TP_DDS_MVC.Scheduler.Jobs
{
    public class JobValidadorPresupuestos : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            //Compra compra = (Compra)context.JobDetail.JobDataMap.Get("compra");
            
            foreach (Compra compra in Global.comprasNoValidadas)
            {
                await ValidadorPresupuestosEgreso.validar(compra);
                Global.comprasNoValidadas.Remove(compra);
                Console.WriteLine("Compra validada");
            }

            
        }

       

    }
}
