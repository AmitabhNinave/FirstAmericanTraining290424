using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagementSystemWebApplication
{
    [Serializable]
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string designation { get; set; }
        public string department { get; set; }
        public string gender { get; set; }
        public string education { get; set; }
    }
}