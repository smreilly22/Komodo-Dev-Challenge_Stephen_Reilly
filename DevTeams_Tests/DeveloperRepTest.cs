using DevTeams_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DevTeams_Tests
{
    [TestClass]
    public class Developer
    {
        // Testing environment if you need it.
        [TestMethod]
        public void AddToDiretoryTest()
        {
            DevTeams_Challenge_Repository.Developer dev = new DevTeams_Challenge_Repository.Developer();

            DeveloperRepo repository = new DeveloperRepo();

            bool addResult = repository.AddDeveloperToDirectory(dev);

            Assert.IsTrue(addResult);

            
        }
        [TestMethod]
        public void GetDirectory_ShouldReturnCorrect()
        {

            DevTeams_Challenge_Repository.Developer developer = new DevTeams_Challenge_Repository.Developer();
            DeveloperRepo repository = new DeveloperRepo();

            repository.AddDeveloperToDirectory(developer);

            List<DevTeams_Challenge_Repository.Developer> developers = repository.GetDeveloper();

            bool directoryHasDeveloper = developers.Contains(developer);

            Assert.IsTrue(directoryHasDeveloper);

        }

        private DevTeams_Challenge_Repository.Developer _developer;
        private DeveloperRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new DeveloperRepo();
            _developer = new DevTeams_Challenge_Repository.Developer("Stephen", "Reilly", 22, TeamAssignment.FrontEnd);

            DevTeams_Challenge_Repository.Developer developer = new DevTeams_Challenge_Repository.Developer("William", "Joseph", 8, TeamAssignment.Testing);
            _repo.AddDeveloperToDirectory(_developer);
            _repo.AddDeveloperToDirectory(developer);
        }

        [TestMethod]
        public void GetByName_ShouldBeCorrect()
        {
            DevTeams_Challenge_Repository.Developer searchResult = _repo.GetDeveloperByName("Stephen Reilly");

            Assert.AreEqual(_developer, searchResult);
        }

        [TestMethod]
        public void UpdateExistingDeveloper_ShouldReturnTrue()
        {
            DevTeams_Challenge_Repository.Developer updatedDeveloper = new DevTeams_Challenge_Repository.Developer("Stephen", "Michael", 22, TeamAssignment.FrontEnd);

            bool update = _repo.UpdateExistingDeveloper("Stephen Reilly", updatedDeveloper);

            Assert.IsTrue(update);

        }

        [TestMethod]
        public void DeleteExistingDeveloper()
        {
            DevTeams_Challenge_Repository.Developer developer = _repo.GetDeveloperByName("Stephen Reilly");

            bool removeResult = _repo.RemovingExistingDeveloper(developer);

            Assert.IsTrue(removeResult);



        }
        
        
    }
}
