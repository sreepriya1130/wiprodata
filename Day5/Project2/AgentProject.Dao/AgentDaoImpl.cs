using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agent.Models;

namespace AgentProject.Dao
{
    internal class AgentDaoImpl : IAgentDao
    {
        static List <Agent.Models.Agent> agentList;


        static AgentDaoImpl()
        {
            agentList = new List<Agent.Models.Agent>();
        }

        public int GenerateAgent()
        {
            if (agentList.Count == 0)
            {
                return 1;
            }
            else
            {
                return agentList[agentList.Count - 1] .AgentID + 1;
            }
        }
        public string AddAgentDao(Agent.Models.Agent agent)
        {
            int id = GenerateAgent();
            agent.AgentID = id;// Auto-generate AgentId
            agentList.Add(agent);
            return "Agent Record Inserted with ID: " + agent.AgentID;
        }

        public Agent.Models.Agent SearchAgentDao(int agentid)
        {
            foreach (Agent.Models.Agent agent in agentList)
            {
                if (agent.AgentID == agentid)
                {
                    return agent;
                }
            }
            return null;
        }

        public List<Agent.Models.Agent> ShowAgentDao()
        {
            return agentList;
        }
    }
}
