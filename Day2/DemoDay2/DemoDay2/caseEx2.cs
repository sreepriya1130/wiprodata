using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDay2
{
    internal class caseEx2
    {
        public void Show(string dayName)
        {
            switch (dayName.ToUpper())
            {
                case "SUN":
                    Console.WriteLine("Its Sunday...");
                    break;
                case "MON":
                    Console.WriteLine("Its Monday...");
                    break;
                case "TUE":
                    Console.WriteLine("Its Tuesday...");
                    break;
                case "WED":
                    Console.WriteLine("Its Wednesday...");
                    break;
                case "THU":
                    Console.WriteLine("Its Thursday...");
                    break;
                case "FRI":
                    Console.WriteLine("Its Friday...");
                    break;
                case "SAT":
                    Console.WriteLine("Its Saturday...");
                    break;
                default:
                    Console.WriteLine("Invalid Choice...");
                    break;
            }
        }
        static void Main()
        {
            string dayName;
            Console.WriteLine("Enter 3 chars of Day Name  ");
            dayName = Console.ReadLine();
            caseEx2 caseEx2 = new caseEx2();
            caseEx2.Show(dayName);
        }
    }
}
