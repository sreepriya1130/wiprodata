using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDay2
{
    internal class ladder
    {
        public void Show(int choice)
        {
            if (choice == 1)
            {
                Console.WriteLine("Hi I am Anu...");
            }
            else if (choice == 2)
            {
                Console.WriteLine("Hi I am Sree...");
            }
            else if (choice == 3)
            {
                Console.WriteLine("Hi I am Anvesh...");
            }
            else if (choice == 4)
            {
                Console.WriteLine("Hi am Priya...");
            }
            else if (choice == 5)
            {
                Console.WriteLine("Hi I am Devanand...");
            }
            else
            {
                Console.WriteLine("Invalid Choice");
            }
        }
        static void Main()
        {
            int choice;
            Console.WriteLine("Enter Your Choice  ");
            choice = Convert.ToInt32(Console.ReadLine());
            ladder ladder = new ladder();
            ladder.Show(choice);
        }

    }
}
