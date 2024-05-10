using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.Exceptions;

namespace EmployeeManagementSystem.DataAccessLayer
{
    public class EmployeeDAL
    {
        public static List<Employee> employeeList = new List<Employee>();

        public void SerializationDAL()
        {
            FileStream objFS = null;
            if (File.Exists("C:\\src\\EmployeeManagementSystem\\DataSerialization\\EmployeeData.dat"))
            {
                objFS = new FileStream(@"C:\src\EmployeeManagementSystem\DataSerialization\EmployeeData.dat",
                FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
            }
            else
            {
                objFS = new FileStream(@"C:\src\EmployeeManagementSystem\DataSerialization\EmployeeData.dat",
                FileMode.Create, FileAccess.Write, FileShare.Read);
            }
            BinaryFormatter objBF = new BinaryFormatter();
            objBF.Serialize(objFS, employeeList);
            objFS.Close();
        }

        public void DeserializationDAL()
        {
            FileStream objFS = null;
            if (File.Exists("C:\\src\\EmployeeManagementSystem\\DataSerialization\\EmployeeData.dat"))
            {
                objFS = new FileStream(@"C:\src\EmployeeManagementSystem\DataSerialization\EmployeeData.dat",
                FileMode.Open, FileAccess.Read, FileShare.Read);
                BinaryFormatter objBF = new BinaryFormatter();
                employeeList = objBF.Deserialize(objFS) as List<Employee>;
                objFS.Close();
            }
        }

        public bool addEmployeeDAL(Employee employee)
        {
            bool employeeAdded = false;

            try
            {
                employeeList.Add(employee);
                employeeAdded = true;
            }
            catch (SystemException ex)
            {
                throw new EmployeeManagementSystemExceptions(ex.Message);
            }
            return employeeAdded;
        }

        public List<Employee> getEmployeeListDAL()
        {
            return employeeList;
        }

        public Employee searchEmployeeDAL(int employeeID)
        {
            Employee searchEmployee = null;
            try
            {
                searchEmployee = employeeList.Find(employee => employee.Id == employeeID);
            }
            catch (SystemException ex)
            {
                throw new EmployeeManagementSystemExceptions(ex.Message);
            }
            return searchEmployee;
        }

        public bool updateEmployeeDAL(Employee updateEmployee)
        {
            bool employeeUpdated = false;

            try
            {
                foreach (Employee employee in employeeList)
                {
                    if (employee.Id == updateEmployee.Id)
                    {
                        employeeUpdated = true;
                        employee.Name = updateEmployee.Name;
                        employee.Department = updateEmployee.Department;
                        employee.Designation = updateEmployee.Designation;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new EmployeeManagementSystemExceptions(ex.Message);
            }
            return employeeUpdated;
        }

        public bool deleteEmployeeDAL(int employeeID)
        {
            bool employeeDeleted = false;
            try
            {
                Employee deleteEmployee = employeeList.Find(employee => employee.Id == employeeID);

                if (deleteEmployee != null)
                {
                    employeeDeleted = true;
                    employeeList.Remove(deleteEmployee);
                }
            }
            catch (SystemException ex)
            {
                throw new EmployeeManagementSystemExceptions(ex.Message);
            }
            return employeeDeleted;
        }
    }
}
