using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class stringEx1
    { 
        static void Main()
        {
            try
            {
                string str = "My name is Priya";
                Console.WriteLine(str.Substring(2, 200));
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Out of the range");
            }
            catch (Exception e)
            {
                Console.WriteLine( " ");
            }
        }
    }
}
