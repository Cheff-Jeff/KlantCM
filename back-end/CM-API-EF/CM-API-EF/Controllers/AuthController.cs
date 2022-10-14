using CM_API_EF.Data;
using CM_API_EF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace CM_API_EF.Controllers
{
    public class AuthController : Controller
    {
        User user = new User();
        VerifyInfo verifyInfo = new VerifyInfo();

        public readonly UserDbContext _context;

        public AuthController(UserDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDTO request)
        {
            verifyInfo.CreatePasswordHash(request.Password, out byte[] passwordhash, out byte[] passwordsalt);

            var newUser = new User
            {
                userName = request.userName,
                passwordHash = passwordhash,
                passwordSalt = passwordsalt,
                isAdmin = false
            };
            

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDTO request)
        {
            var Myuser = _context.Users
                .FirstOrDefault(u => u.userName == request.userName);
            if (Myuser == null || !verifyInfo.VerifyPasswordHash(request.Password, Myuser.passwordHash, Myuser.passwordSalt))
            {
                return BadRequest("No matching credentials");
            }

            return Ok(Myuser.userId);
        }
    }
}
