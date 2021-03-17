using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLocalCalculator.MathsOperationsClient calculator = new MyLocalCalculator.MathsOperationsClient();
            Console.WriteLine(calculator.Add(1, 2));
            Console.WriteLine(calculator.Subtract(1, 2));
            Console.WriteLine(calculator.Multiply(3,5));

            Console.ReadLine();
        }
    }
}
