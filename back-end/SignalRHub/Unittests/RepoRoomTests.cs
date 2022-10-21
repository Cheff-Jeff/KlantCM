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
        private readonly Dictionary<int, Room> _data =
        new Dictionary<int, Room>();

        [TestMethod]
        public void Test_Add()
        {
            //arrange
            SignalRHub.RepoRoom repo = new SignalRHub.RepoRoom();

            Room room = new Room();
            int key = 1;


            //act
            _data.Add(key, room);
            repo.Add(room, key);


            //assert
            Assert.AreEqual(repo._data.Count, _data.Count);
        }

        [TestMethod]
        public void Test_Update()
        {

        }

        [TestMethod]
        public void Test_Exists()
        {

        }

        [TestMethod]
        public void Test_get()
        {

        }

        [TestMethod]
        public void Test_Count()
        {

        }

        [TestMethod]
        public void Test_FindFreeUser()
        {

        }

        [TestMethod]
        public void Test_remove()
        {

        }

        [TestMethod]
        public void Test_Find()
        {

        }
    }
}
