using Microsoft.VisualStudio.TestTools.UnitTesting;
using SignalRHub;
using SignalRHub.Hubs;
using SignalRHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SignalRTest
{
    [TestClass]
    public class signalrTest
    {
        [TestMethod]
        public async Task Test_SendMessage()
        {
            //Arrange
            Chathub chathub = new Chathub();
            int id = 16;
            string message = "hoi";
            string connectionid = "asdjasda";
            //Act
            bool expected = false;
            bool actual = await chathub.SendMessage(message, id, connectionid);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task Test_AddEndUserToRoom()
        {
            //arrange
                            
            Chathub chathub = new Chathub();
            string connectionid = "test";
            bool inRoom = false;
            Employee henk = new Employee();
            int roomid = 1;

            Room room = new Room();
            room.EndUserIds = new List<string>();
            EndUser endUser = new EndUser(connectionid, inRoom ) ;

            int ExpectedOutcome = 1;
            //act
            room.EndUserIds.Add(endUser.ConnectionString);
            //assert
            Assert.AreEqual(room.EndUserIds[0], endUser.ConnectionString);
            Assert.AreEqual(room.EndUserIds.Count, ExpectedOutcome);
        }

        //[TestMethod]
        public async Task Test_StartRoom()
        {
            ////arrange
            //Chathub chathub = new Chathub();

            //List<string> l = new();
            //l.Add("1");

            //int id = 3;
            //string firstname = "Pieter";

            //Employee employee = new Employee();
            //employee.Id = id;
            //employee.FirstName = firstname;

            //Room room = new Room();
            //room.Id = 6;
            //room.employee = employee;
            //room.EndUserIds = l;


            ////act
            //Room expected = new Room();
            //Room actual = new Room();
            //actual = await chathub.StartRoom(id, firstname);
            //expected = room;


            ////assert
            //Assert.AreEqual(actual, expected);
        }

        //[TestMethod]
        public void Test_ConnectUser()
        {
            ////arrange
            //Chathub chathub = new Chathub();
            //string connectionString = "test";

            //EndUser e = new EndUser(connectionString);


            ////act
            //bool actual = chathub.ConnectUser();
            //bool expected = true;


            ////assert
            //Assert.AreEqual(actual, expected);

        }
    }
}