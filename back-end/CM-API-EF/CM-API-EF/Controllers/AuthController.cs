using CM_API_EF.Data;
using CM_API_EF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace CM_API_EF.Controllers
{
    public class AuthController : Controller
    {
        VerifyInfo verify = new VerifyInfo();

        public readonly UserDbContext _context;

        public AuthController(UserDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User request)
        {
            verify.CreatePasswordHash(Convert.ToBase64String(request.passwordHash), out byte[] passwordhash, out byte[] passwordsalt);

            var newUser = new User
            {
                userName = request.userName,
                Email = request.Email,
                passwordHash = passwordhash,
                passwordSalt = passwordsalt,
                isAdmin = request.isAdmin,
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return Ok(newUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(UserDTO request)
        {
            var Myuser = _context.Users
                .FirstOrDefault(u => u.Email == request.Email);

            //bool validPassword = BCrypt.Net.BCrypt.Verify(request.Password, Myuser.passwordHash);

            if (Myuser != null || verify.VerifyPasswordHash(request.Password, Myuser.passwordHash, Myuser.passwordSalt))
            {
                return Ok(Myuser.userId);
            }
            return BadRequest("user not found");
        }
    }
}
