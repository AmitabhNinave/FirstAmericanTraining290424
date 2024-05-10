using EmployeeManagementSystem.DataAccessLayer;
using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.BusinessLayer
{
    public class EmployeeBL
    {
        private static bool ValidateEmployee(Employee employee)
        {
            StringBuilder sb = new StringBuilder();
            bool validEmployee = true;

            if(employee.Id <= 0) 
            {
                validEmployee = false;
                sb.Append(Environment.NewLine + "Invalid Employee ID");
            }

            if(employee.Name == string.Empty)
            {
                validEmployee = false;
                sb.Append(Environment.NewLine + "Guest Name Required");
            }

            if(!(employee.Department == "software" || employee.Department == "it" || employee.Department == "finance")) 
            {
                validEmployee = false;
                sb.Append(Environment.NewLine + "Invalid Department");
            }

            if(validEmployee == false)
            {
                throw new EmployeeManagementSystemExceptions(sb.ToString());
            }
            return validEmployee;
        }

        public static void SerializationBAL()
        {
            try
            {
                EmployeeDAL employeeDAL = new EmployeeDAL();
                employeeDAL.SerializationDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeserializationBAL()
        {
            try
            {
                EmployeeDAL employeeDAL = new EmployeeDAL();
                employeeDAL.DeserializationDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddEmployeeBL(Employee newEmployee)
        {
            bool employeeAdded = false;

            try
            {
                if(ValidateEmployee(newEmployee))
                {
                    EmployeeDAL employeeDAL = new EmployeeDAL();
                    employeeAdded = employeeDAL.addEmployeeDAL(newEmployee);
                }
            }
            catch (EmployeeManagementSystemExceptions ex) 
            {
                throw ex;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            return employeeAdded;
        }

        public static Employee SearchEmployeeBL(int employeeID)
        {
            Employee searchEmployee = null;
            
            try
            {
                EmployeeDAL employeeDAL = new EmployeeDAL();
                searchEmployee = employeeDAL.searchEmployeeDAL(employeeID);
            }
            catch (EmployeeManagementSystemExceptions ex)
            {
                throw ex;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
            return searchEmployee;
        }

        public static bool UpdateEmployeeBL(Employee updateEmployee)
        {
            bool employeeUpdated = false;

            try
            {
                if(ValidateEmployee(updateEmployee))
                {
                    EmployeeDAL employeeDAL = new EmployeeDAL();
                    employeeUpdated = employeeDAL.updateEmployeeDAL(updateEmployee);
                }
            }
            catch (EmployeeManagementSystemExceptions ex) 
            {
                throw ex;
            }
            catch( Exception ex)
            {
                throw ex;
            }
            return employeeUpdated;
        }

        public static List<Employee> GetAllEmployeeBL()
        {
            List<Employee> employeeList = null;

            try
            {
                EmployeeDAL employeeDAL = new EmployeeDAL();
                employeeList = employeeDAL.getEmployeeListDAL();
            }
            catch (EmployeeManagementSystemExceptions ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return employeeList;
        }
        public static bool DeleteEmployeeBL(int employeeID)
        {
            bool employeeDeleted = false;

            try
            {
                if (employeeID > 0)
                {
                    EmployeeDAL employeeDAL = new EmployeeDAL();
                    employeeDeleted = employeeDAL.deleteEmployeeDAL(employeeID);
                }
                else
                {
                    throw new EmployeeManagementSystemExceptions("Invalid Employee ID");
                }
            }
            catch (EmployeeManagementSystemExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employeeDeleted;
        }
    }
}
