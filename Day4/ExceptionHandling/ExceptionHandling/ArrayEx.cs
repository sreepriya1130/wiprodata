using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class ArrayEx
    {
        static void Main()
        {
            try
            {
                int[] arr = new int[] { 1, 2, 3 };
                arr[10] = 32;
                Console.WriteLine("array" + arr);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("number is out of range");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
