using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITraining[] arr = new ITraining[] { new harika(), new badri() };
            foreach (ITraining i in arr)
            {
                i.Name();
                i.Email();
                Console.WriteLine("----------------------------------");
            }
        }
        
    }
}
