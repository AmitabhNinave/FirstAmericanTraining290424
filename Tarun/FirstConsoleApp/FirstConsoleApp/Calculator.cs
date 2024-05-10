using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp1{
    internal class Calculator
    {
        internal int Addition(int num1, int num2)
        {
            int result;
            result = num1 + num2;
            return result;
        }
        internal int Subtraction(int num1, int num2)
        {
            int result;
            result = num1 - num2;
            return result;
        }
        internal int Multiplication(int num1, int num2)
        {
            int result;
            result = num1 * num2;
            return result;
        }
        internal int Division(int num1, int num2)
        {
            int result;
            result = num1 / num2;
            return result;
        }
    }
}
