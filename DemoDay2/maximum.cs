using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoDay2
{
    internal class maximum
    {
        public void show(int a, int b, int c)
        {
            int m = a;
            if (m < b)
            {
                m = b;
            }
            if (m < c)
            {
                m = c;
            }
            Console.WriteLine("Maximum value " +m);
        }
        static void Main()
        {
            int a, b, c;
            Console.WriteLine("Enter the values ");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            c = Convert.ToInt32(Console.ReadLine());
            maximum max = new maximum();
            max .show(a, b, c);

        }
    }
}
