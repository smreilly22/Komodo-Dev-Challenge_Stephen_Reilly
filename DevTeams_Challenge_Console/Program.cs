using DevTeams_Challenge_Repository;

using System;
using System.Collections.Generic;

namespace DevTeams_Challenge_Console
{
    class Program
    {
        //This class is the starting point for our Console Application. This main method is the first code to be run when we start the program. We have made the connection to the ProgramUI for you.
        static void Main(string[] args)
        {
            ProgramUI ui = new ProgramUI();
            ui.Run();
        }

        
        public void MyTestMethod()
        {

            

            
           List< Developer> developer = new List< Developer>();

            foreach(Developer dev in developer)
            {

                if (dev.GetType() == typeof(Developer))
                {
                Console.WriteLine(((Developer)dev).DoesHavePluralsight);
                }
                else
                {
                Console.WriteLine("Does not have Pluralsight");
                }

            }
        }
      
        

            

        
    }
}
