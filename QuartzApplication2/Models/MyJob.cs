using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzApplication2.Models
{
    public class MyJob
    {
        public MyJob( Type  type, string expression)
        {
            Common.Logs($"My job at " + DateTime.Now.ToString("dd-MMM-yyy hh:mm:ss"), "My job " + DateTime.Now.ToString("hhmmss"));


            Type = type;
            Expression = expression;
        }
        public Type Type { get; }
        public string Expression { get; }
    }
}
