using CM_API_EF.Data;
using CM_API_EF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace CM_API_EF.Controllers
{
    public class AuthController : Controller
    {
        public readonly UserDbContext _context;

        public AuthController(UserDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User request)
        {
            var newUser = new User
            {
                userName = request.userName,
                Email = request.Email,
                passwordHash = request.passwordHash,
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

            bool validPassword = BCrypt.Net.BCrypt.Verify(request.Password, Myuser.passwordHash);

            if (Myuser == null || validPassword == false)
            {
                return BadRequest("user not found");
            }

            return Ok(Myuser.userId);
        }
    }
}
