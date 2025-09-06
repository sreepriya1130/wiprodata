using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    internal class harika : ITraining
    {
        public void Email()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Email is harika@gamil.com");
        }

        public void Name()
        {
            //throw new NotImplementedException();
            Console.WriteLine("My name is Harika");
        }
    }
}
