using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Exceptions
{
    public class EmployeeManagementSystemExceptions: ApplicationException
    {
        public EmployeeManagementSystemExceptions() : base() { }
        public EmployeeManagementSystemExceptions(string message) : base(message) { }
        public EmployeeManagementSystemExceptions(string message, Exception innerException) : base(message, innerException) { }
    }
}
