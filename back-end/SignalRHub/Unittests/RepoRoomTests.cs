using SignalRHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unittests
{
    [TestClass]
    public class RepoRoomTests
    {
        //employee aanmaken.
        Employee employee = new Employee()
        {
            Id = 1,
            FirstName = "Peter",
            ConnectionString = "test123"
        };

        //list van eindgebruikers aanmaken.
        List<string> endUsers = new List<string>()
        {
            "Pietje",
            "Peter",
            "Kees"
        };

        //key aanmaken.
        public int key = 1;



        [TestMethod]
        public void Test_Add()
        {
            //arrange
            SignalRHub.RepoRoom repo = new SignalRHub.RepoRoom();

            Room actual = new Room();

            Room expected = new Room();
            expected.Id = 1;
            expected.employee = employee;
            expected.EndUserIds = endUsers;


            //act
            repo.Add(expected, key);

            actual = repo.get(key);

            //assert
            Assert.AreEqual(actual.Id, expected.Id);
            Assert.AreEqual(actual.employee, expected.employee);
            Assert.AreEqual(actual.employee.Id, expected.employee.Id);
            Assert.AreEqual(actual.employee.FirstName, expected.employee.FirstName);
            Assert.AreEqual(actual.employee.ConnectionString, expected.employee.ConnectionString);
            Assert.AreEqual(actual.EndUserIds, expected.EndUserIds);
            Assert.AreEqual(actual.EndUserIds.Count, expected.EndUserIds.Count);
        }

        [TestMethod]
        public void Test_Update()
        {
            //arrange
            SignalRHub.RepoRoom repo = new SignalRHub.RepoRoom();

            Room actual = new Room();

            Room expected = new Room();
            expected.Id = 1;
            expected.employee = employee;
            expected.EndUserIds = endUsers;


            //act
            repo.Update(expected, key);
            actual = repo.get(key);


            //assert
            Assert.AreEqual(actual.Id, expected.Id);
            Assert.AreEqual(actual.employee, expected.employee);
            Assert.AreEqual(actual.employee.Id, expected.employee.Id);
            Assert.AreEqual(actual.employee.FirstName, expected.employee.FirstName);
            Assert.AreEqual(actual.employee.ConnectionString, expected.employee.ConnectionString);
            Assert.AreEqual(actual.EndUserIds, expected.EndUserIds);
            Assert.AreEqual(actual.EndUserIds.Count, expected.EndUserIds.Count);
        }

        [TestMethod]
        public void Test_Exists()
        {
            //arrange
            SignalRHub.RepoRoom repo = new SignalRHub.RepoRoom();


            //act    
            bool expected = repo.Exists(key);
            bool actual = false;


            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_get()
        {
            //arrange
            SignalRHub.RepoRoom repo = new SignalRHub.RepoRoom();

            Room expected = new Room();
            expected.Id = 1;
            expected.employee = employee;
            expected.EndUserIds = endUsers;

            Room actual = new Room();


            //act
            repo.Add(expected, key);
            actual = repo.get(key);



            //assert
            Assert.AreEqual(actual.Id, expected.Id);
            Assert.AreEqual(actual.employee, expected.employee);
            Assert.AreEqual(actual.employee.Id, expected.employee.Id);
            Assert.AreEqual(actual.employee.FirstName, expected.employee.FirstName);
            Assert.AreEqual(actual.employee.ConnectionString, expected.employee.ConnectionString);
            Assert.AreEqual(actual.EndUserIds, expected.EndUserIds);
            Assert.AreEqual(actual.EndUserIds.Count, expected.EndUserIds.Count);
        }

        [TestMethod]
        public void Test_Count()
        {
            //arrange
            SignalRHub.RepoRoom repo = new SignalRHub.RepoRoom();

            Room expected = new Room();
            expected.Id = 1;
            expected.employee = employee;
            expected.EndUserIds = endUsers;


            //act
            repo.Add(expected, key);

            int actualint = repo.Count();
            int expectedint = 1;


            //assert
            Assert.AreEqual(actualint, expectedint);
        }

        [TestMethod]
        public void Test_FindFreeUser()
        {


        }

        [TestMethod]
        public void Test_remove()
        {
            //arrange
            SignalRHub.RepoRoom repo = new SignalRHub.RepoRoom();

            Room expected = new Room();
            expected.Id = 1;
            expected.employee = employee;
            expected.EndUserIds = endUsers;


            //act
            repo.Add(expected, key);

            repo.remove(key);

            bool actualbool = repo.Exists(key);
            bool expectedbool = false;

            //assert
            Assert.AreEqual(actualbool, expectedbool);
        }

        [TestMethod]
        public void Test_Find()
        {

        }
    }
}
