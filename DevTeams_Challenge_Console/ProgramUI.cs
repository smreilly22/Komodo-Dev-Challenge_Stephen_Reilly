using DevTeams_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Console
{
    public class ProgramUI
    {
        //This class will be how we interact with our user through the console. When we need to access our data, we will call methods from our Repo class.

        

        private DevTeamsRepo _teamRepo = new DevTeamsRepo();

       

        public void Run()
        {
            SeedContent();
            Menu();
        }

        private void Menu()
        {
            //Start with the main menu here
            Console.WriteLine("Enter the number of the option you would like: \n" +
                "1.Create New Developer: \n" +
                "2.Create New Team\n"  +
                "3.Display All Developers\n" +
                "4.DispalyDevelopers by Team\n" +
                "5.Update Existing Developer\n" +
                "6.Delete Existing Developer\n" +
                "7.Add Developer to Team\n" +
                "8.Remove Developer to Team\n" +
                "9. Remove Team \n" +
                "10.Exit");

            bool runMenu = true;
            while (runMenu)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        CreateDeveloper();
                        break;
                    case "2":
                        CreateNewDevTeam();
                        break;
                    case "3":
                        DisplayAllDevelopers();
                        break;
                    case "4":
                         DisplayDeveloperById();
                        break;
                    case "5":
                        UpdateExistingDeveloper();
                        break;
                    case "6":
                         DeleteExistingDeveloper();
                        break;
                    case "7":
                        AddDeveloperToDevTeam();
                        break;
                    case "8":
                        RemoveDevelopertoDev();
                        break;

                    case "9":
                        RemoveDevTeam();
                        break;
                    case "10":
                    default:
                        Console.WriteLine("Please pick a valid number between 1-10. Press any key to continue ");
                        Console.ReadKey();
                        break;

                }
            }
        }
        

        //CreateNewDeveloper();
        private void CreateDeveloper()
        {
            Console.Clear();
            Developer developer = new Developer();

            Console.WriteLine("Please enter Developer First Name: ");
            developer.DeveloperFirstName = Console.ReadLine();

            Console.WriteLine("Please enter Developer Last Name: ");
            developer.DeveloperLastName = Console.ReadLine();

            Console.WriteLine("Please enter Developer Id number: ");
            developer.DeveloperID = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter Team Assignment: \n" +
               "1. FrontEnd\n" +
               "2. BackEnd\n" +
               "3. Testing\n");
            string teamAssignment = Console.ReadLine();
            switch (teamAssignment)
            {
                case "1":
                    developer.TeamAssignment = TeamAssignment.FrontEnd;
                    break;
                case "2":
                    developer.TeamAssignment = TeamAssignment.BackEnd;
                    break;
                case "3":
                    developer.TeamAssignment = TeamAssignment.Testing;
                    break;
            }

            if (_teamRepo.AddDeveloperToDirectory(developer))
            {
                Console.WriteLine("Success! Press any key!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Failure! Press any key to continue");
                Console.ReadLine();

            }



        }
        //DisplayAllDevelopers();

        private void DisplayAllDevelopers()
        {
            Console.Clear();

            List<Developer> listofDevelopers =_teamRepo.GetDeveloper();
            foreach (Developer deve in listofDevelopers)
            {
                DisplayAllDevelopers();
            }

            AnyKey();

        }

       

        //DisplayDeveloperById();

        private void DisplayDeveloperById()
        {
            Console.Clear();

            Console.WriteLine("Enter an ID");
            string idDeveloper = Console.ReadLine();
            int id = int.Parse(idDeveloper);

            Developer developer = _teamRepo.GetDeveloperById(id);

            if (developer != null)
            {
                DisplaylDeveloper(developer);
            }
            else
            {
                Console.WriteLine("Could not find developer by that ID.");
            }

            AnyKey();


        }

        

        //UpdateExistingDeveloper();

        private void UpdateExistingDeveloper()
        {
            Console.Clear();
            Console.Write("Please enter the name developer you wish to update: ");
            Developer oldDeveloper = _teamRepo.GetDeveloperByName(Console.ReadLine());
            if (oldDeveloper != null)
            {
                Console.WriteLine("Please enter first name: ");
                string nameInput = Console.ReadLine();
                if (nameInput != "")
                {
                    oldDeveloper.DeveloperFirstName = nameInput;
                }
            }
        }

        //DeleteExistingDeveloper();
        private void DeleteExistingDeveloper()
        {
            Console.Clear();
            Console.WriteLine("What developer you want to remove");

            List<Developer> developerList = _teamRepo.GetDeveloper();
            int count = 0;

            foreach (Developer developer in developerList)
            {
                count++;
                Console.WriteLine($"{count} {developer.DeveloperFullName}");
            }
            Console.Write("What developer do you want to remove: ");
            int developerID = int.Parse(Console.ReadLine());
            int developerIndex = developerID - 1;
            if (developerIndex >= 0 && developerIndex < developerList.Count())
            {
                Developer desiredDeveloper = developerList[developerIndex];

                if (_teamRepo.RemovingExistingDeveloper(desiredDeveloper))
                {
                    Console.WriteLine("Something went wrong");
                }
                else
                {
                    Console.WriteLine($"{desiredDeveloper.DeveloperFullName} deleted successfully!");
                }
            }
            else
            {
                Console.WriteLine("No developer has the ID ");
            }
            AnyKey();

        }

        //CreateNewDevTeam

        private void CreateNewDevTeam()
        {
            Console.Clear();

            DevTeam devTeam = new DevTeam();
            Console.WriteLine("Please enter new dev team name: ");
            devTeam.TeamName = Console.ReadLine();

            Console.WriteLine("Please enter new dev team ID: ");
            devTeam.TeamID = int.Parse(Console.ReadLine());

            if (_teamRepo.AddTeamToDirectory(devTeam))
            {
                Console.WriteLine("Success! Press any key!");


            }
            else
            {
                Console.WriteLine("I don't tolerate failure. Try Again");
            }

            AnyKey();





        }

        private void RemoveDevTeam()
        {
            Console.Clear();

            DevTeam devTeam = new DevTeam();
            Console.WriteLine("Please enter new dev team name: ");
            devTeam.TeamName = Console.ReadLine();

            Console.WriteLine("Please enter new dev team ID: ");
            devTeam.TeamID = int.Parse(Console.ReadLine());

            if (_teamRepo.RemovingTeamFromDirectory(devTeam))
            {
                Console.WriteLine("Success! Press any key!");


            }
            else
            {
                Console.WriteLine("I don't tolerate failure. Try Again");
            }

            AnyKey();

        }





        // AddDeveloperToDevTeam();
        private void AddDeveloperToDevTeam()
        {
            Console.Clear();

            
            Console.WriteLine("Please enter team id: ");
            
            int teamID = int.Parse(Console.ReadLine());

            
            Console.WriteLine("Pleae enter developer id: ");
            int devID = int.Parse(Console.ReadLine());
            

            if (_teamRepo.AddDeveloperToTeamByID(devID, teamID))
            {
                Console.WriteLine("Success! Press Any Key");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Failure! Press any key to continue");
               Console.ReadKey();
            }
                

        }


        private void AddMultipleDevelopersToTeam()  // Extra Credit
        {
            Console.Clear();

            Console.WriteLine("Please enter team ID you want to add from: ");

            int devTeam = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the developers you want to add: ");

            List<Developer> developer = new List<Developer>();
            developer.Add(new Developer(Console.ReadLine()));
            developer.Add(new Developer(Console.ReadLine()));
            developer.Add(new Developer(Console.ReadLine()));
        }

            


            //RemoveDevelopertoDevTeam();

        private void RemoveDevelopertoDev( )
        {
            

            Console.Clear();


            Console.WriteLine("Please enter team id: ");

            int teamID = int.Parse(Console.ReadLine());


            Console.WriteLine("Pleae enter developer id: ");
            int devID = int.Parse(Console.ReadLine());


            if (_teamRepo.RemovingExistingDeveloperOnTeam(devID, teamID))
            {
                Console.WriteLine("Success! Press Any Key");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Failure! Press any key to continue");
                Console.ReadKey();
            }





        }


        private void SeedContent()
        {
            Developer bradReilly = new Developer("Brad", "Reilly", 1001, TeamAssignment.FrontEnd);
            Developer blakChamplin = new Developer("Blake", "Champlin", 1002, TeamAssignment.BackEnd);
            Developer joeSwanson = new Developer("Joe", "Swanson", 1003,TeamAssignment.FrontEnd);
            Developer hannahSmith = new Developer("Hannah", "Smith", 1005, TeamAssignment.Testing);
            Developer barkelyStevesmith = new Developer("Barkely", "Stevesmith", 1008, TeamAssignment.Testing);
            Developer ashKetchum = new Developer("Ash", "Ketchum", 1006, TeamAssignment.BackEnd);
            Developer rosieMann = new Developer("Rosie", "Mann", 1010, TeamAssignment.FrontEnd);

            DevTeam sneakyCheetahs = new DevTeam("Sneaky Cheetahs", 100);
            DevTeam firePigs = new DevTeam("Fire Pigs", 102);
            DevTeam spottedTigers = new DevTeam("Spotted Tigers", 106);



            _teamRepo.AddDeveloperToDirectory(bradReilly);
            _teamRepo.AddDeveloperToDirectory(blakChamplin);
            _teamRepo.AddDeveloperToDirectory(joeSwanson);
            _teamRepo.AddDeveloperToDirectory(hannahSmith);
            _teamRepo.AddDeveloperToDirectory(barkelyStevesmith);
            _teamRepo.AddDeveloperToDirectory(ashKetchum);
            _teamRepo.AddDeveloperToDirectory(rosieMann);

            _teamRepo.AddTeamToDirectory(sneakyCheetahs);
            _teamRepo.AddTeamToDirectory(firePigs);
            _teamRepo.AddTeamToDirectory(spottedTigers);
        }

        private void DisplayDeveloperBasicInfo(Developer developer)
        {
            Console.Clear();
            Console.WriteLine($"Developer: {developer.DeveloperFullName}");
        }

        private void DisplaylDeveloper( Developer developer)
        {
            Console.WriteLine($"Developer: {developer.DeveloperFullName}\n" +
                $"2. DeveloperId: {developer.DeveloperID}\n" +
                $"3. Developer Team: {developer.TeamAssignment}\n");
        }

        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue continue");
            Console.ReadKey();
        }








        

            




            
            
    























            

            
            
            
            
            
            
            // RemoveDevelopertoDevTeam();
        

        // Helpermethods you should write
        // A method to print a developer's first and last name, useful in display all
        // private void DisplayDevBasicInfo(Developer dev) {}

        // A method to print a developers full information, useful when showing one developer
        // private void DisplayDevFullInfo(Developer dev) {}


        //private void SeedContent(){}
    }
}
