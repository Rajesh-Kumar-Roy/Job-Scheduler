using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;
using QuartzApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuartzApplication2.Service
{
    public class QuartzHostedService: IHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _jobFactory;
        private readonly IEnumerable<MyJob> _myJobs;
        public QuartzHostedService(ISchedulerFactory schedulerFactory, IJobFactory jobFactory,
            IEnumerable<MyJob> myJobs)
        {
            _schedulerFactory = schedulerFactory;
            _jobFactory = jobFactory;
            _myJobs = myJobs;
        }

        public IScheduler Scheduler { get; set; }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Common.Logs($"StartAsync at " + DateTime.Now.ToString("dd-MMM-yyy hh:mm:ss"), "StartAsync " + DateTime.Now.ToString("hhmmss"));

            Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
            Scheduler.JobFactory = _jobFactory;

            foreach(var myjob in _myJobs)
            {
                var job = CreateJob(myjob);
                var trigger = CreateTrigger(myjob);
                await Scheduler.ScheduleJob(job, trigger, cancellationToken);
            }
            await Scheduler.Start(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {

            Common.Logs($"StopAsync at " + DateTime.Now.ToString("dd-MMM-yyy hh:mm:ss"), "StopAsync " + DateTime.Now.ToString("hhmmss"));
            await Scheduler?.Shutdown(cancellationToken);
        }


        private static IJobDetail CreateJob(MyJob myJob)
        {
            var type = myJob.Type;
            return JobBuilder.Create(type).WithIdentity(type.FullName).WithDescription(type.Name).Build();
        }

        private static ITrigger CreateTrigger(MyJob myJob)
        {
            return TriggerBuilder.Create().WithIdentity($"{myJob.Type.FullName}.trigger").WithCronSchedule(myJob.Expression).WithDescription(myJob.Expression).Build();
        }

    }
}
