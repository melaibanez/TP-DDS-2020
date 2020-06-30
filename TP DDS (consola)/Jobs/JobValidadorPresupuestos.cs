using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS__consola_.Jobs
{
    class JobValidadorPresupuestos : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Compra compra = (Compra)context.JobDetail.JobDataMap.Get("compra");

            if (compra.fueVerificada == false)
            {
                await ValidadorPresupuestosEgreso.validar(compra);
            }
        }
    }
}