using SignalRHub.Models;
using SignalRHub.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class RepoEndUserTest
    {
        [TestMethod]
        public void Test_Add()
        {
            //arrange
            RepoEndUser repoEndUser = new RepoEndUser();
            EndUser user = new EndUser("sdifsoidf");
            int key = 3;


            //act
            bool actual = repoEndUser.Add(user, key);
            bool expected = true;


            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Test_Exists()
        {
            //arrange
            RepoEndUser repoEndUser = new RepoEndUser();
            int key = 3;


            //act
            bool actual = repoEndUser.Exists(key);
            bool expected = false;


            //assert
            Assert.AreEqual(actual, expected);
        }

        //[TestMethod]
        public void Test_get()
        {
            ////arrange
            //RepoEndUser repoEndUser = new RepoEndUser();

            //int key = 3;
            //string actual2 = "";
            //string expected2 = "";


            ////act
            //EndUser actual = new EndUser("sfdg64ty");
            //EndUser expected = new EndUser("sfdg64ty");
            //actual = repoEndUser.get(key);

            //actual.ConnectionString = actual2;
            //expected.ConnectionString = expected2;


            ////assert
            //Assert.AreEqual(actual2, expected2);
        }

        [TestMethod]
        public void Test_FindFreeUser()
        {
            //arrange
            RepoEndUser repoEndUser = new RepoEndUser();


            //act
            EndUser actual = new EndUser("asidoijasd0");
            EndUser expected = new EndUser("asidoijasd0");

            actual = repoEndUser.FindFreeUser();
            expected = null;


            //assert
            Assert.AreEqual(actual, expected);
        }
    }
}
