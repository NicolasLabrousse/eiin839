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
            ServiceCalculator.CalculatorSoapClient calculator = new ServiceCalculator.CalculatorSoapClient();
            Console.WriteLine(calculator.Add(1, 2));
            Console.ReadLine();
        }
    }
}
