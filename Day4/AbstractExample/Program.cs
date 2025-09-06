using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Training obj1 = new Training();
            //Training obj2 = new Training();
            //Training obj3 = new Training();
            Training[] arrtraining = new Training[] { new Priya(),new Anvesh(),new Sree() };
            foreach(Training t in arrtraining)
            {
                t.Email();
                t.Name();
                Console.WriteLine("--------------------------------");
            }
        }
    }
}
