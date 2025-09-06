using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class quiz1
    {
        static void Main()
        {
            int x = 10;
            int y = x++ + ++x;// here answer is 22 becuase x++=10 and ++x=12
            Console.WriteLine(y);
        }
   
    }
}
