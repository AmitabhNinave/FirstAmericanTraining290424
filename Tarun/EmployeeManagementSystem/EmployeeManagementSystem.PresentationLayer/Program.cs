using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.BusinessLayer;
using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.Exceptions;

namespace EmployeeManagementSystem.PresentationLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeBL.DeserializationBAL();

            int choice;
            do
            {
                PrintMenu();
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        ListAllEmployee();
                        break;
                    case 3:
                        SearchEmployeeByID();
                        break;
                    case 4:
                        UpdateEmployee();
                        break;
                    case 5:
                        DeleteEmployee();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (choice != 6);
        }

        static void DeleteEmployee()
        {
            try
            {

                Console.Write("Enter Employee ID to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Employee deleteEmployee = EmployeeBL.SearchEmployeeBL(id);

                if (deleteEmployee != null)
                {

                    bool employeeDeleted = EmployeeBL.DeleteEmployeeBL(id);

                    if (employeeDeleted)
                    {
                        Console.WriteLine("Employee is deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Employee is not deleted.");
                    }
                }
                else
                {
                    Console.WriteLine("No Employee Details Available");
                }
            }
            catch (EmployeeManagementSystemExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void UpdateEmployee()
        {
            try
            {

                Console.Write("Enter Employee ID to update: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Employee updateEmployee = EmployeeBL.SearchEmployeeBL(id);

                if(updateEmployee != null)
                {
                    Console.Write("Enter Employee Name to update: ");
                    updateEmployee.Name = Console.ReadLine();

                    Console.Write("Enter Employee Designation to update: ");
                    updateEmployee.Designation = Console.ReadLine();

                    Console.Write("Enter Employee Department to update: ");
                    updateEmployee.Department = Console.ReadLine();

                    bool employeeUpdated = EmployeeBL.UpdateEmployeeBL(updateEmployee);

                    if(employeeUpdated)
                    {
                        Console.WriteLine("Employee is updated");
                    }
                    else
                    {
                        Console.WriteLine("Employee Detail is not updated");
                    }
                }
                else
                {
                    Console.WriteLine("No Employee Details Available");
                }
            }
            catch (EmployeeManagementSystemExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void SearchEmployeeByID()
        {
            try
            {
                Console.Write("Enter EmployeeID to Search:");
                int employeeID = Convert.ToInt32(Console.ReadLine());
                Employee searchEmployee = EmployeeBL.SearchEmployeeBL(employeeID);

                if (searchEmployee != null)
                {
                    Console.WriteLine("*****************************************************************");
                    Console.WriteLine("EmployeeID\t\tName\t\tDesignation\t\tDepartment");
                    Console.WriteLine("*****************************************************************");
                    Console.WriteLine($"{searchEmployee.Id}\t\t{searchEmployee.Name}\t\t{searchEmployee.Designation}\t\t{searchEmployee.Department}");
                }
                else
                {
                    Console.WriteLine("No Employee Details Available");
                }
            }
            catch (EmployeeManagementSystemExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ListAllEmployee()
        {
            try
            {
                List<Employee> employeeList = EmployeeBL.GetAllEmployeeBL();
                if (employeeList != null)
                {
                    Console.WriteLine("*****************************************************************");
                    Console.WriteLine("EmployeeID\tName\t\tDesignation\t\tDepartment");
                    Console.WriteLine("*****************************************************************");
                    foreach (Employee employee in employeeList)
                    {
                        Console.WriteLine($"{employee.Id}\t\t{employee.Name}\t\t{employee.Designation}\t{employee.Department}");
                    }
                }
                else
                {
                    Console.WriteLine("No Employee Details Available");
                }
            }
            catch (EmployeeManagementSystemExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void AddEmployee()
        {
            try
            {

                Console.Write("Enter Employee ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Employee Designation: ");
                string designation = Console.ReadLine();

                Console.Write("Enter Employee Department: ");
                string department = Console.ReadLine();

                Employee employee = new Employee(id, name, designation, department);
                bool employeeAdded = EmployeeBL.AddEmployeeBL(employee);
                if (employeeAdded)
                {
                    Console.WriteLine("Employee Added Successfully");
                }
                else
                {
                    Console.WriteLine("Employee Not Added");
                }
            }
            catch (EmployeeManagementSystemExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("*************Employee Management System*************");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. List ALl Employee");
            Console.WriteLine("3. Search Employee");
            Console.WriteLine("4. Update Employee");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Exit");
        }
    }
}
