using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevTeams_Tests
{
    [TestClass]
    public class DevTeamRepTest
    {
        [TestMethod]
        public void AddDevTeamToDirectory()
        {

            DevTeams_Challenge_Repository.DevTeam devTeam = new DevTeams_Challenge_Repository.DevTeam();
            DevTeams_Challenge_Repository.DevTeamsRepo repository = new DevTeams_Challenge_Repository.DevTeamsRepo();

            bool addResult = repository.AddTeamToDirectory(devTeam);
            Assert.IsTrue(addResult);
        }

    }
}
