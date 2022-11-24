using CM_API_EF;
using CM_API_EF.Controllers;
using CM_API_EF.Data;
using CM_API_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM_API_EF_UnitTests
{
    public class AuthControllerTests
    {
        AuthController authController;
        VerifyInfo verifyInfo = new VerifyInfo();

        public AuthControllerTests()
        {
            SeedDb();
        }

        private void SeedDb()
        {
            var options = new DbContextOptionsBuilder<UserDbContext>()
                .UseInMemoryDatabase(databaseName: "test123")
                .Options;

            var context = new UserDbContext(options);

            context.Database.EnsureDeleted();

            authController = new AuthController(context);

            verifyInfo.CreatePasswordHash("peter123", out byte[] passwordhash, out byte[] passwordsalt);

            var newuser = new User
            {
                userId = 1,
                userName = "Peter",
                Email = "peter@example.com",
                passwordHash = passwordhash,
                passwordSalt = passwordsalt,
                isAdmin = false,
            };

            context.Add(newuser);
            context.SaveChanges();
        }

        [Fact]
        public async Task Test_Register_OKResult()
        {
            //arrange
            var myuser = new UserDTO
            {
                Id = 11,
                userName = "pietjuh",
                Email = "piet@example.com",
                Password = "",
                isAdmin = false
            };


            //act
            var user = await authController.Register(myuser);
            var result = (ObjectResult)user;


            //assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task Test_Login_OKResult()
        {
            //arrange
            var myuser = new UserDTO
            {
                Email = "peter@example.com",
                Password = "peter123"
            };


            //act
            var user = await authController.Login(myuser);
            var result = (ObjectResult)user;


            //assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task Test_Login_BadRequestResult()
        {
            //arrange
            var myuser = new UserDTO
            {
                Email = "r@example.com",
                Password = "peter123"
            };


            //act
            var user = await authController.Login(myuser);
            var result = (ObjectResult)user;


            //assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task Test_DoubleEmailChecker_True()
        {
            //arrange
            string email = "peter@example.com";


            //act
            var result = await authController.DoubleEmailChecker(email);


            //assert
            Assert.NotNull(result);
            Assert.True(result.Value);
        }

        [Fact]
        public async Task Test_DoubleEmailChecker_False()
        {
            //arrange
            string email = "r@example.com";
            

            //act
            var result = await authController.DoubleEmailChecker(email);


            //assert
            Assert.NotNull(result);
            Assert.False(result.Value);
        }
    }
}
