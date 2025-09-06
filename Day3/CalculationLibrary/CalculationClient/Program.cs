using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculationLibrary;

namespace CalculationClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("Enter two numbers ");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            calculation calculation = new calculation();
            Console.WriteLine("Sum is "+calculation.Sum(a,b));
            Console.WriteLine("Sub is "+calculation.Sub(a,b));
            Console.WriteLine("Mul is "+calculation.Mul(a,b));

        }
    }
}
