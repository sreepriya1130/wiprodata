using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoDay2
{
    internal class posneg
    {
        public void check(int x)

        {
            if (x >= 0)
            {
                Console.WriteLine("Positive number");
            }
            else
            {
                Console.WriteLine("negative number");
            }
        }
        static void Main(string[] args)
        {
            int x;
            Console.WriteLine("enter the value");
            x = Convert.ToInt32(Console.ReadLine());
            posneg obj = new posneg();
            obj.check(x);


        }
    }
}
