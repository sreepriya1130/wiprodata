using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class quiz5
    {
        static void Main()
        {
            int x = 10;
            Console.WriteLine(x++ + ++x + x++ + ++x);//10+12+13+13
            //x value is 10
            //memory value is 11

            //next value is 12
            // memoery value is 13

            //next value is 13
            //memory value 14
        }
    }
}
