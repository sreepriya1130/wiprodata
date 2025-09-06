using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            Console.WriteLine("Enter two numbers ");

            try
            {
                a = Convert.ToInt32(Console.ReadLine());
                b = Convert.ToInt32(Console.ReadLine());
                c = a / b;
                Console.WriteLine("Division " + c);
            }
            catch (OverflowException) 
            {
                Console.WriteLine("number is too big ");
            }
            catch (FormatException e)
            {
                Console.WriteLine("string cannot be integer");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Zero should not be taken");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("thank u");
            }
        }
    }
}
