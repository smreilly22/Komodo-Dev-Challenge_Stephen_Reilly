using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Tests
{
    public class DevTeamRepository
    {

        [TestMethod]
        public void AddTeamToDirectory_ShouldAdd()
        {
            DevTeams_Challenge_Repository.DevTeam devTeam = new DevTeams_Challenge_Repository.DevTeam();
            DevTeams_Challenge_Repository.DevTeamsRepo repository = new DevTeams_Challenge_Repository.DevTeamsRepo();

            bool addResult = repository.AddTeamToDirectory(devTeam);
            Assert.IsTrue(addResult);



        }
    }
}
