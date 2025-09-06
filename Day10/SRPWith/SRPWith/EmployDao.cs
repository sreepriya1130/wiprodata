using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPWith
{
    internal interface EmployDao
    {
        string AddEmployDao(Employ employ);
        List<Employ> GetAllEmploys();
    }
}
