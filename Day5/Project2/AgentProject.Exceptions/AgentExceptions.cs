using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentProject.Exceptions
{
    public class AgentExceptions : ApplicationException
    {
        public AgentExceptions() { }

        public AgentExceptions(string message) : base(message) { }
    }

}

