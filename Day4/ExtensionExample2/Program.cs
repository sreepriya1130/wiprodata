using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionLibrary;

namespace ExtensionExample2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Operations operations = new Operations();
            Console.WriteLine(operations.Milestone1());
            Console.WriteLine(operations.Milestone2());
            Console.WriteLine(operations.Milestone3());
            Console.WriteLine(operations.Milestone4());
        }
    }
}
