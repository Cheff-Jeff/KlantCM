using CM_API_EF.Data;
using CM_API_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace CM_API_EF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        VerifyInfo verify = new VerifyInfo();

        public readonly UserDbContext _context;

        public AuthController(UserDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDTO request)
        {
            verify.CreatePasswordHash(request.Password, out byte[] passwordhash, out byte[] passwordsalt);

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

            if (Myuser != null)
            {
                if(verify.VerifyPasswordHash(request.Password, Myuser.passwordHash, Myuser.passwordSalt))
                {
                    return Ok(Myuser.userId);
                }
            }
            return BadRequest("user not found");
        }

        [HttpPost("doubleemail")]
        public async Task<ActionResult<bool>> DoubleEmailChecker(string email)
        {
            bool doubleEmail = await _context.Users.AnyAsync(u => u.Email == email);

            if (doubleEmail) { return true; }

            return false;
        }
    }
}
