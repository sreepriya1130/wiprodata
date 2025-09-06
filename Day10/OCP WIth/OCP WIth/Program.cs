using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP_WIth
{
    internal class Program
    {
        public static void Show(Family ifamily)
        {
            ifamily.Name();
            ifamily.Relation();
        }
        static void Main(string[] args)
        {
            Father father = new Father();
            Show(father);
            Mother mother = new Mother();
            Show(mother);
            Brother brother = new Brother();
            Show(brother);
        }
    }
}
