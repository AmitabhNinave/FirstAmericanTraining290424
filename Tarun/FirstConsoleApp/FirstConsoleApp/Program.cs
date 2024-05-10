using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CalculatorLib;

namespace FirstConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---- Console Application -----");
            //
            char choice;
            do
            {
                Console.WriteLine("Press 1 for Addition, 2 for Subtraction, 3 for Multiplication, 4 for Division and 5 to exit. ");
                int operation;
                operation = Convert.ToInt32(Console.ReadLine());
                int firstNo;
                int secondNo;
                int result;
                CalculatorLib.Calculator objCalculator = new CalculatorLib.Calculator();
                //
                switch (operation)
                {
                    case 1:
                        Console.WriteLine("Enter FirstNo");
                        firstNo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter SecondNo");
                        secondNo = Convert.ToInt32(Console.ReadLine());
                        //
                        result = objCalculator.Addition(firstNo, secondNo);
                        Console.WriteLine("Addition of two numbers is: " + result);
                        break;
                    case 2:
                        Console.WriteLine("Enter FirstNo");
                        firstNo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter SecondNo");
                        secondNo = Convert.ToInt32(Console.ReadLine());
                        //
                        result = objCalculator.Subtraction(firstNo, secondNo);
                        Console.WriteLine("Subtraction of two numbers is: " + result);
                        break;
                    case 3:
                        Console.WriteLine("Enter FirstNo");
                        firstNo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter SecondNo");
                        secondNo = Convert.ToInt32(Console.ReadLine());
                        //
                        result = objCalculator.Multiplication(firstNo, secondNo);
                        Console.WriteLine("Multiplication of two numbers is: " + result);
                        break;
                    case 4:
                        Console.WriteLine("Enter FirstNo");
                        firstNo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter SecondNo");
                        secondNo = Convert.ToInt32(Console.ReadLine());
                        //
                        result = objCalculator.Division(firstNo, secondNo);
                        Console.WriteLine("Division of two numbers is: " + result);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                Console.WriteLine("Do you want to continue? Press 'y' to continue or 'n' to exit.");
                choice = Convert.ToChar(Console.ReadLine());
            } while (choice == 'y');
            Console.ReadLine();
        }

        /*
        static int Addition(int num1, int num2)
        {
            int result;
            result = num1 + num2;
            return result;
        }
        static int Subtraction(int num1, int num2)
        {
            int result;
            result = num1 - num2;
            return result;
        }
        static int Multiplication(int num1, int num2)
        {
            int result;
            result = num1 * num2;
            return result;
        }
        static int Division(int num1, int num2)
        {
            int result;
            result = num1 / num2;
            return result;
        }
        */
    }
}
