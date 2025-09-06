using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.Models
{
    public class Agent
    {
        public int AgentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public double PremiumAmount { get; set; }

        public Agent() { }


        public Agent(string Fname, string Lname, string city, string gender, double premiumAmount)
        {
            //AgentID = agentid;
            FirstName = Fname;
            LastName = Lname;
            City = city;
            Gender = gender;
            PremiumAmount = premiumAmount;
        }

        public override string ToString()
        {
            return "AgentID:" + AgentID +
                ", Name:" + FirstName + " " + LastName +
                ", City: " + City +
                ", Gender: " + Gender +
                ", PremiumAmount: " + PremiumAmount;
        }
    }
}
