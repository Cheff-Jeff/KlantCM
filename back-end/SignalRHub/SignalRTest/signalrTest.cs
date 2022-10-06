using Microsoft.VisualStudio.TestTools.UnitTesting;
using SignalRHub.Hubs;
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
           bool expected = false ;
           bool actual = await chathub.SendMessage(message, id, connectionid);
            //Assert
            Assert.AreEqual(expected, actual);            
        }
    }
}
