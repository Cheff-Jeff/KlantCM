using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace CM_API_EF.Controllers
{
    public class LoginController : Controller
    {
        User user = new User();


        [HttpPost]
        public async Task<ActionResult<User>> Register(UserDTO request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordhash, out byte[] passwordsalt);

            user.userName = request.userName;
            user.passwordHash = passwordhash;
            user.passwordSalt = passwordsalt;

            return Ok(User);
        }

        private void CreatePasswordHash(string password, out byte[] passwordhash, out byte[] passwordsalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordsalt = hmac.Key;
                passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
