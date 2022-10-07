using SignalRHub;
using SignalRHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class RepoRoomTest
    {
        [TestMethod]
        public void Test_Add()
        {
            //arrange
            RepoRoom<Room> repoRoom = new RepoRoom<Room>();
            Room room = new Room();
            int key = 3;

            //act
            bool actual = repoRoom.Add(room, key);
            bool expected = true;


            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Test_Exists()
        {
            //arrange
            RepoRoom<Room> repoRoom = new RepoRoom<Room>();
            Room room = new Room();
            int key = 3;


            //act
            bool actual = repoRoom.Exists(key);
            bool expected = false;


            //assert
            Assert.AreEqual(actual, expected);
        }
    }
}
