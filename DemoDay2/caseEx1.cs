using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDay2
{
    internal class caseEx1
    {
        public void Check(char choice)
        {
            switch (choice)
            {
                case 'a':
                case 'A':
                case '1':
                    Console.WriteLine("Anu");
                    break;
                case 'b':
                case 'B':
                case '2':
                    Console.WriteLine("sree");
                    break;
                case 'c':
                case 'C':
                case '3':
                    Console.WriteLine("anvesh");
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
        static void Main(string[] args)
        {
            char choice;
            Console.WriteLine("Enter choice ");
            choice = Convert.ToChar(Console.ReadLine());
            caseEx1 obj = new caseEx1();
            obj.Check(choice);
        }
    }
}
