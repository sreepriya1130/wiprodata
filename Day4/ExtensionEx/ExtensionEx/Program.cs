using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculation calculation = new Calculation();
            Console.WriteLine(calculation.Sum(5,2));
            Console.WriteLine(calculation.Sub(6,3));
            Console.WriteLine(calculation.Mul(2,4));
        }
    }
}
