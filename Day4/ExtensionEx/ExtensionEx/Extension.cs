using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionEx
{
    internal static class Extension
    {
        public static int Mul(this Calculation cal,int a, int b)
        {
            return a * b;
        }
    }
}
