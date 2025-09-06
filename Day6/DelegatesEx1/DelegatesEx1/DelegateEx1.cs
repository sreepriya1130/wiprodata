using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEx1
{
    internal class DelegateEx1
    {
        public delegate void MyDelegate();
        public static void Show()
        {
            Console.WriteLine("My name is Priya ");
        }
        static void Main(string[] args)
        {
            MyDelegate obj = new MyDelegate(Show);
            obj();

        }
    }
}
