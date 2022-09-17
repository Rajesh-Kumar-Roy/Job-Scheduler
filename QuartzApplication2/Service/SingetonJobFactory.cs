using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;
using QuartzApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzApplication2.Service
{
    public class SingetonJobFactory: IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public SingetonJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            Common.Logs($"NewJob at " + DateTime.Now.ToString("dd-MMM-yyy hh:mm:ss"), "NewJob " + DateTime.Now.ToString("hhmmss"));
            return _serviceProvider.GetRequiredService(bundle.JobDetail.JobType) as IJob;
        }
        public void ReturnJob(IJob job)
        {
           
        }
    }
}
