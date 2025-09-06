using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEx1
{
    internal class DelEx2
    {
        public delegate void MyDelegate(int n);
        public static void Fact(int n)
        {
            int f = 1;
            for (int i = 1; i <= n; i++)
            {
                f = f * i;
            }
            Console.WriteLine("Factorial Value " + f);
        }
        public static void posneg(int n)
        {
            if (n >= 0)
            {
                Console.WriteLine("positive Number...");
            }
            else
            {
                Console.WriteLine("Negative number...");
            }

        }
        public static void EvenOdd(int n)
        {
            if (n % 2 == 0)
            {
                Console.WriteLine("Even Number...");
            }
            else
            {
                Console.WriteLine("Odd Number...");
            }
        }

        static void Main()
        {
            int n;
            Console.WriteLine("Enter N value ");
            n = Convert.ToInt32(Console.ReadLine());
            MyDelegate obj = new MyDelegate(Fact);
            obj +=  posneg;
            obj +=  EvenOdd;

            obj(n);
        }
    }
}
