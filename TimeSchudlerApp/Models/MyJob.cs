using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSchudlerApp.Models
{
    public class MyJob
    {
        public MyJob( Type  type, string expression)
        {
            Type = type;
            Expression = expression;
        }
        public Type Type { get; }
        public string Expression { get; }
    }
}
