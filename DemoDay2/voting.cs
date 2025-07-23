using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDay2
{
    internal class voting
    {
        public void Check(int age)
        {
            if (age > 18)
            {
                Console.WriteLine("person is eligible for voting");
            }
            else
            {
                Console.WriteLine("person is not eligible for voting");
            }
        }

        static void Main(string[] args)
        {
            int age;
            Console.WriteLine("Enter age ");
            age = Convert.ToInt32(Console.ReadLine());
            voting voting = new voting();
            voting.Check(age);
        }
    }
}

