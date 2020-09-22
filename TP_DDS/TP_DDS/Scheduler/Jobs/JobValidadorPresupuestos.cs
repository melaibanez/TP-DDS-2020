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

            if (!compra.compraValidada)
            {
                await ValidadorPresupuestosEgreso.validar(compra);
            }
        }

       

    }
}
