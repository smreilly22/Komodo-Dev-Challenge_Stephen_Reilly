using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class DevTeamsRepo : DeveloperRepo
    {

        private List<DevTeam> _devTeamDirectory = new List<DevTeam>();

        protected int _id = 100;

        // Create
        

        // Add Team
        public bool AddTeamToDirectory( DevTeam devteam)
        {
            int startingCount = _devTeamDirectory.Count();
            _devTeamDirectory.Add(devteam);
            _id++;

            bool wasAdded = (_devTeamDirectory.Count() > startingCount) ? true : false;
            return wasAdded;
        }

        //Add to a Team by ID
        public bool AddDeveloperToTeamByID( int devID, int teamID)
        {
            Developer dev = GetDeveloperById(devID);
            DevTeam dTeam = GetDevTeamById(teamID);

            int startingCount = dTeam.TeamMember.Count();
            dTeam.TeamMember.Add(dev);
            return dTeam.TeamMember.Count > startingCount ? true : false;
        }

        //Add to a Team by Name
        public bool AddDevelopertoTeamByName(string devName, int teamID)
        {
            Developer devoloper = GetDeveloperByName(devName);
            DevTeam dTeam = GetDevTeamById(teamID);

            int startingCount = dTeam.TeamMember.Count();
            dTeam.TeamMember.Add(devoloper);

            return dTeam.TeamMember.Count > startingCount ? true : false;
        }



        //Read
        public List<DevTeam> GetDevTeam()
        {
            
            return _devTeamDirectory;
        }

        public DevTeam GetDevTeamById(int teamID)
        {
            return _devTeamDirectory.Where(d => d.TeamID == teamID).SingleOrDefault();
        }

        public DevTeam GetDevTeamByDeveloper(List<Developer> listOfDevelopers)
        {
            return _devTeamDirectory.Where(d => d.TeamMember == listOfDevelopers).SingleOrDefault();
        }

        public List<DevTeam> GetDevTeamByTeam(string assignmentMent)
        {
            return _devTeamDirectory.Where(d => d.TeamName == assignmentMent).ToList();
            
           
              
        }

        // Update

        public bool UpdateExistingDevTeam ( int teamId, DevTeam newTeamInfo)
        {
            DevTeam oldTeam = GetDevTeamById(teamId);
            if (oldTeam != null)
            {
                oldTeam.TeamName = newTeamInfo.TeamName;
                oldTeam.TeamID = newTeamInfo.TeamID;
                oldTeam.TeamMember = newTeamInfo.TeamMember;

                return true;
            }
            else
            {
                return false;
            }

        }


        // Remove
        
        //Remove from a team
        public bool RemovingExistingDeveloperOnTeam( int devID, int teamID)
        {
            Developer dev = GetDeveloperById(devID);
            DevTeam dTeam = GetDevTeamById(teamID);

            int standingCount = dTeam.TeamMember.Count();
            dTeam.TeamMember.Remove(dev);
            return dTeam.TeamMember.Count > standingCount ? true : false;
        }

        //Remove Team
        public bool RemovingTeamFromDirectory(DevTeam existingTeam)
        {
            bool deleteDevTeam = _devTeamDirectory.Remove(existingTeam);
            return deleteDevTeam;
        }

       






        
    }
}
