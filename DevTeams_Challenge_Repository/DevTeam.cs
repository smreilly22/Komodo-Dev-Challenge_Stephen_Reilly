using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    
    public class DevTeam 
    {

        public DevTeam() { }
        public DevTeam(string teamName, int teamID)
        {
            TeamName = teamName;
            TeamID = teamID;
        }

        public DevTeam( string teamName, int teamID, List<Developer> teamMember)  : this(teamName, teamID)
        { 
            
            TeamMember = teamMember;

        }
        

        public int TeamID { get; set; }

        public List<Developer> TeamMember { get; set; }

        public string TeamName { get ; set; }
        

    }
}
