using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS__consola_.Model.Compras;
using TP_DDS__consola_.Validadores;

namespace TP_DDS__consola_.Scheduler.Jobs
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
    }
}