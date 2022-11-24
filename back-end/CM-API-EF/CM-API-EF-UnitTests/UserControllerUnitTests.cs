using CM_API_EF;
using CM_API_EF.Controllers;
using CM_API_EF.Data;
using CM_API_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CM_API_EF_UnitTests
{
    public class UserControllerUnitTests
    {
        UserController userController;
        VerifyInfo verifyInfo = new VerifyInfo();

        public UserControllerUnitTests()
        {
            SeedDb();
        }

        private void SeedDb()
        {
            var options = new DbContextOptionsBuilder<UserDbContext>()
                .UseInMemoryDatabase(databaseName: "test")
                .Options;

            var context = new UserDbContext(options);

            context.Database.EnsureDeleted();

            userController = new UserController(context);
            

            verifyInfo.CreatePasswordHash("peter123", out byte[] passwordhash, out byte[] passwordsalt);

            var users = new List<User>
            {
                new User
                {
                userId = 1,
                userName = "Peter",
                Email = "peter@example.com",
                passwordHash = passwordhash,
                passwordSalt = passwordsalt,
                isAdmin = false,
                },

                new User
                {
                userId = 10,
                userName = "peet",
                Email = "peet@example.com",
                passwordHash = passwordhash,
                passwordSalt = passwordsalt,
                isAdmin = false,
                },
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        [Fact]
        public async Task Test_GetUserById_OKResult()
        {
            //arrange
            int userid = 1;


            //act
            var user = await userController.GetUserById(userid);
            var result = (ObjectResult)user;


            //assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task Test_GetUserById_BadRequestResult()
        {
            //arrange
            var userid = 0;


            //act
            var user = await userController.GetUserById(userid);
            var result = (ObjectResult)user;


            //assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task Test_GetAllUsers_OKResult()
        {
            //arrange


            //act
            var user = await userController.GetAllUsers();
            var result = (ObjectResult)user;


            //assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task Test_EditUser_OKResult()
        {
            //arrange
            var myuser = new UserDTO
            {
                Id = 1,
                userName = "pietjuh",
                Email = "piet@example.com",
                Password = "",
                isAdmin = false
            };

            //act
            var user = await userController.EditUser(myuser);
            var result = (ObjectResult)user;


            //assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task Test_EditUser_BadRequestResult()
        {
            //arrange
            var myuser = new UserDTO
            {
                Id = 0,
                userName = "pietjuh",
                Email = "piet@example.com",
                Password = "",
                isAdmin = false
            };


            //act
            var user = await userController.EditUser(myuser);
            var result = (ObjectResult)user;


            //assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task Test_DeleteUserById_OKResult()
        {
            //arrange
            int userid = 10;

            //act
            var user = await userController.DeleteUserById(userid);
            var result = (ObjectResult)user;


            //assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task Test_DeleteUserById_BadRequestResult()
        {
            //arrange
            int userid = 0;


            //act
            var user = await userController.DeleteUserById(userid);
            var result = (ObjectResult)user;


            //assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }
    }
}