using Quartz;
using QuartzApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzApplication2.Service
{
    public class JobReminders: IJob
    {
        public JobReminders()
        {

        }
        public Task Execute(IJobExecutionContext context)
        {
            Common.Logs($"Job Remineder at " + DateTime.Now.ToString("dd-MMM-yyy hh:mm:ss"), "Job Remineder " + DateTime.Now.ToString("hhmmss"));
            return Task.CompletedTask;
        }
    }
}
