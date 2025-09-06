using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractExample
{
    internal class Sree : Training
    {
        public override void Email()
        {
            //throw new NotImplementedException();
            Console.WriteLine("hi my email is sree@gmail.com");
        }

        public override void Name()
        {
            //throw new NotImplementedException();
            Console.WriteLine("hi my name is Sree");
        }
    }
}
