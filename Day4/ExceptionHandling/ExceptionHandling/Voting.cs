using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class Voting
    {
        public void Check(int age)
        {
            if (age < 18)
            {
                throw new Exception("you are not eligible for voting");
            }
            Console.WriteLine("you are eligible to vote");
        }
        static void Main(string[] args)
        {
            int age;
            Console.WriteLine("Enter age ");
            age = Convert.ToInt32(Console.ReadLine());
            Voting voting = new Voting();
            try
            {
                voting.Check(age);
            }
            catch (Exception v)
            {
                Console.WriteLine(v.Message);
            }
           
        }
    }
}
