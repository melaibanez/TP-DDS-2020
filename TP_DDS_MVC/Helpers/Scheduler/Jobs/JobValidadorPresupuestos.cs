using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Helpers.Validadores;

namespace TP_DDS_MVC.Helpers.Scheduler.Jobs
{
    public class JobValidadorPresupuestos : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            //Compra compra = (Compra)context.JobDetail.JobDataMap.Get("compra");
            MyLogger.log("COMPRAS VALIDADASSSSSSsmKJNGBRULHGBEWUOBGFEWUFBjhewbfuhbewf");
            foreach (Compra compra in MvcApplication.comprasNoValidadas)
            {
                await ValidadorPresupuestosEgreso.validar(compra);
                MvcApplication.comprasNoValidadas.Remove(compra);
                
            }
        }

       

    }
}
