using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agent.Models;

namespace AgentProject.Dao
{
    internal interface IAgentDao
    {
        string AddAgentDao(Agent.Models.Agent agent);
        List<Agent.Models.Agent> ShowAgentDao();
        Agent.Models.Agent SearchAgentDao(int agentid);
    }
}
