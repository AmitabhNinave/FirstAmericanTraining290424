using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Entities
{
    [Serializable]
    public class Employee
    {
        private int id;
        private string name;
        private string designation;
        private string department;

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Designation { get { return designation; } set { designation = value; } }
        public string Department { get { return department; } set { department = value; } }
        public Employee()
        {
            this.Id = 0;
            this.Name = string.Empty;
            this.Designation = string.Empty;
            this.Department = string.Empty;
        }
        public Employee(int id, string name, string designation, string department)
        {
            this.Id = id;
            this.Name = name;
            this.Designation = designation;
            this.Department = department;
        }
    }
}
