using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SignalRHub;
using SignalRHub.Hubs;

namespace SignalRTest
{
    internal class testunittest
    {
        [TestMethod]
        public void Test_SendMessage()
        {
            //Arrange
            Chathub chathub = new Chathub();



            int id = 1;
            string message = "hoi";
            string connectionid = "asdjasda";



            //Act
            bool expected = true;
            bool actual = chathub.SendMessage(message, id, connectionid);



            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
