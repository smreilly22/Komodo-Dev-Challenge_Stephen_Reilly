using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class DeveloperRepo 
    {
        //This is our Repository class that will hold our directory (which will act as our database) and methods that will directly talk to our directory.

        private List<Developer> _devDirectory = new List<Developer>();

        

        // C
        // Add to the Directory

        public bool AddDeveloperToDirectory( Developer developer)
        {
            int startingCount = _devDirectory.Count();
            _devDirectory.Add(developer);

            bool wasAdded = (_devDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }


        
        // R

        public List<Developer> GetDeveloper()
        {
            return _devDirectory;
        }

        public Developer GetDeveloperByName(string name)
        {
            
            foreach(Developer developer in _devDirectory)
            {
                if(developer.DeveloperFullName.ToLower() == name.ToLower())
                {
                    return developer;
                }
            }
            return null;
        }

        public Developer GetDeveloperById( int id)
        {
            foreach(Developer developer in _devDirectory)
            {
                if(developer.DeveloperID == id)
                {
                    return developer;
                }
            }
            return null;

        }

        public Developer GetDeveloperByTeam( ) // TeamAssignment assignment
        {
            Developer developer = new Developer();
            Console.WriteLine(developer.TeamAssignment);
            return developer;

            //return _developerReop.Where(d => d.TeamAssignment == assignment).ToList();
        }

       
            // U

        public bool UpdateExistingDeveloper( string originalDeveloper, Developer newDeveloper)
        {
            Developer oldDeveloper = GetDeveloperByName(originalDeveloper);
            if(oldDeveloper != null)
            {
                oldDeveloper.DeveloperFirstName = newDeveloper.DeveloperFirstName;
                oldDeveloper.DeveloperID = newDeveloper.DeveloperID;
                oldDeveloper.TeamAssignment = newDeveloper.TeamAssignment;

                return true;

            }
            else
            {
                return false;
            }

        }

        // D

        public bool RemovingExistingDeveloper(Developer existingDeveloper)
        {
            bool deleteDeveloper = _devDirectory .Remove(existingDeveloper);
            return deleteDeveloper;
        }
    }
}
