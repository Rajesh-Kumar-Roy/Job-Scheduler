using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using TimeSchudlerApp.DataConn;
using TimeSchudlerApp.Repository;

namespace TimeSchudlerApp.Jobs
{
    public class SalaryJob: IJob
    {
        private readonly IServiceProvider _serviceProvider;
        public SalaryJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public  Task Execute(IJobExecutionContext context)
        {
            Test();
            return Task.CompletedTask;
        }

        private void Test()
        {
            using var scope = _serviceProvider.CreateScope();
            var salaryRepor = scope.ServiceProvider.GetRequiredService<ISalaryRepository>();
            var v = salaryRepor.GetAllSalary();
            if (v != null)
            {
                salaryRepor.InsertListOfData(v);
            }
        }
    }
}
