using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib
{
    public class Calculator
    {
        public int Addition(int num1, int num2)
        {
            int result;
            result = num1 + num2;
            return result;
        }
        public int Subtraction(int num1, int num2)
        {
            int result;
            result = num1 - num2;
            return result;
        }
        public int Multiplication(int num1, int num2)
        {
            int result;
            result = num1 * num2;
            return result;
        }
        public int Division(int num1, int num2)
        {
            int result;
            result = num1 / num2;
            return result;
        }
    }
}
