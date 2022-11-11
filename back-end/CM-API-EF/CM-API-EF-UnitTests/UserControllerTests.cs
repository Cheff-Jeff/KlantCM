using CM_API_EF;
using CM_API_EF.Controllers;
using CM_API_EF.Data;
using CM_API_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CM_API_EF_UnitTests
{
    public class UserControllerTests
    {
        UserController userController;
        VerifyInfo verifyInfo = new VerifyInfo();

        public UserControllerTests()
        {
            SeedDb();
        }

        private void SeedDb()
        {
            var options = new DbContextOptionsBuilder<UserDbContext>()
                .UseInMemoryDatabase(databaseName: "test")
                .Options;

            var context = new UserDbContext(options);

            userController = new UserController(context);

            context.Database.EnsureDeleted();

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

            context.Users.Add(newuser);
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
    }
}