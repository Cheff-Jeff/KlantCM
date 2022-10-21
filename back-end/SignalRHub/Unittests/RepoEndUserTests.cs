using SignalRHub;
using SignalRHub.Models;
using SignalRHub.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Unittests
{
    [TestClass]
    public class RepoEndUserTests
    {
        [TestMethod]
        public void Test_Add()
        {
            //arrange
            RepoEndUser repo = new RepoEndUser();

            string connectionstring = "test";
            string key = "69";

            EndUser endUser = new EndUser(connectionstring);

            //act
            repo.Add(endUser, key);
            EndUser fromrepo = repo.get(key);
            //assert
            
            Assert.AreEqual(endUser.ConnectionString, fromrepo.ConnectionString);
            Assert.AreEqual(endUser, fromrepo);
        }

        [TestMethod]
        public void Test_Update()
        {
            //arrange
            RepoEndUser repo = new RepoEndUser();

            string connection1 = "this is the bad one";
            string connection2 = "this is the good one";
            EndUser endUser1 = new EndUser(connection1);
            EndUser endUser2 = new EndUser(connection2);
            string key = "69";
            //act
            repo.Add(endUser1, key);
            repo.Update(endUser2, key);
            EndUser fromRepo = repo.get(key);
            //assert
            Assert.AreEqual(fromRepo, endUser2);
            Assert.AreEqual(fromRepo.ConnectionString, endUser2.ConnectionString);


        }
        [TestMethod]
        public void Test_Exists()
        {
            //arrange
            RepoEndUser repo = new RepoEndUser();

            string connectionstring = "test";
            string key = "69";

            EndUser endUser = new EndUser(connectionstring);

            //act
            repo.Add(endUser, key);
            //assert
            Assert.IsTrue(repo.Exists(key));
        }

        [TestMethod]
        public void Test_Get()
        {
            //arrange
            RepoEndUser repo = new RepoEndUser();

            string connectionstring = "test";
            string key = "69";

            EndUser endUser = new EndUser(connectionstring);

            //act
            repo.Add(endUser, key);
            //assert
            Assert.AreEqual(endUser, repo.get(key));
        }
        [TestMethod]
        public void Test_FindFreeUser()
        {
            RepoEndUser repo = new RepoEndUser();

            string connection1 = "this is the bad one";
            string connection2 = "this is the good one";
            EndUser endUser1 = new EndUser(connection1, true);
            EndUser endUser2 = new EndUser(connection2, false);
            string key = "69";
            string key2 = "420";
            //act
            repo.Add(endUser1, key);
            repo.Add(endUser2, key2);
            //assert
            Assert.AreEqual(endUser2, repo.FindFreeUser());
        }
        [TestMethod]
        public void Test_Count()
        {
            //arrange
            RepoEndUser repo = new RepoEndUser();

            string connectionstring = "test";
            string key = "69";
            int expectedcount = 1;
            EndUser endUser = new EndUser(connectionstring);

            //act
            repo.Add(endUser, key);
            //assert
            Assert.AreEqual(expectedcount, repo.Count());
        }
        [TestMethod]
        public void Test_Remove()
        {
            //arrange
            RepoEndUser repo = new RepoEndUser();

            string connectionstring = "test";
            string key = "69";

            EndUser endUser = new EndUser(connectionstring);

            //act
            repo.Add(endUser, key);
            repo.remove(key);
            //assert
            Assert.IsFalse(repo.Exists(key));
        }
    }
}
