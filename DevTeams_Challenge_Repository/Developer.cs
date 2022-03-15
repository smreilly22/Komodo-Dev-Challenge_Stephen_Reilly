using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public enum TeamAssignment { FrontEnd =1, BackEnd, Testing}
    public class Developer
    {

        

        //This is our POCO class. It will define our properties and constructors of our Developer objects.
        //Developer objects should have the following properties
            //ID (int)
            //FirstName
            //LastName
            //a bool that shows whether they have access to the online learning tool Pluralsight.
            //TeamAssignment - use the enum declared above this class

        public Developer() { }

        public Developer(string firstName)
        {
            DeveloperFirstName = firstName;
        }

        public Developer(string firstName, string lastName) : this(firstName)
        {
            DeveloperLastName = lastName;
        }

        public Developer(string firstName, string lastName, int developerID, TeamAssignment teamAssignment) : this(firstName, lastName)
        {
            DeveloperFirstName = firstName;
            DeveloperLastName = lastName;
            DeveloperID = developerID;
            TeamAssignment = teamAssignment;
            

        }
        

        

        public string DeveloperFirstName { get; set; }

        public string DeveloperLastName { get; set; }
        

        public int DeveloperID { get; set; }

        public TeamAssignment TeamAssignment { get; set; }

        

        public string DeveloperFullName
        {
            get
            {
                return $"{DeveloperFirstName} {DeveloperLastName}";
            }
        }

        public bool DoesHavePluralsight
        {
            get
            {
                if (DoesHavePluralsight == true)
                {
                    return true;
                }
                return false;
            }
            set { }
        }


    

    

    }


}
