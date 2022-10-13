using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace CM_API_EF.Controllers
{
    public class AuthController : Controller
    {
        User user = new User();
        VerifyInfo verifyInfo = new VerifyInfo();


        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDTO request)
        {
            verifyInfo.CreatePasswordHash(request.Password, out byte[] passwordhash, out byte[] passwordsalt);

            user.userName = request.userName;
            user.passwordHash = passwordhash;
            user.passwordSalt = passwordsalt;

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDTO request)
        {
            if(user.userName != request.userName)
            {
                return BadRequest("No user found");
            }
            if(!verifyInfo.VerifyPasswordHash(request.Password, user.passwordHash, user.passwordSalt))
            {
                return BadRequest("No user found");
            }
            return Ok();
        }
    }
}
