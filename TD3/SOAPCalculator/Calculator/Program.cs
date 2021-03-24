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
            CalculatorService.MathsOperationsClient calculator = new CalculatorService.MathsOperationsClient("SoapEndPnt1");
            Console.WriteLine(calculator.Add(1, 2));
            Console.WriteLine(calculator.Subtract(1, 2));
            Console.WriteLine(calculator.Multiply(3,5));

            CalculatorService.MathsOperationsClient calculator2 = new CalculatorService.MathsOperationsClient("SoapEndPnt2");
            Console.WriteLine(calculator2.Add(1, 2));
            Console.WriteLine(calculator2.Subtract(1, 2));
            Console.WriteLine(calculator2.Multiply(3, 5));

            CalculatorService.MathsOperationsClient calculator3 = new CalculatorService.MathsOperationsClient("SoapEndPnt3");
            Console.WriteLine(calculator3.Add(1, 2));
            Console.WriteLine(calculator3.Subtract(1, 2));
            Console.WriteLine(calculator3.Multiply(3, 5));

            Console.ReadLine();
        }
    }
}
