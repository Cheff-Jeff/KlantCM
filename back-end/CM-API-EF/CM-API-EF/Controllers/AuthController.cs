using CM_API_EF.Data;
using CM_API_EF.DTO_s;
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
        public async Task<ActionResult> Register(UserDTO request)
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
        public async Task<ActionResult> Login(UserDTO request)
        {
            var Myuser = _context.Users
                .FirstOrDefault(u => u.Email == request.Email);

            //bool validPassword = BCrypt.Net.BCrypt.Verify(request.Password, Myuser.passwordHash);

            if (Myuser != null)
            {
                if(verify.VerifyPasswordHash(request.Password, Myuser.passwordHash, Myuser.passwordSalt))
                {
                    UserName user = new() { UserId = Myuser.userId, Name = Myuser.userName };
                    return Ok(user);
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

        [HttpGet("getuser")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var myuser = await _context.Users
            .Where(u => u.userId == id)
                         .Select(u => new
                         {
                             u.userName,
                             u.isAdmin,
                         })
                         .ToArrayAsync();

            if (myuser == null) { return BadRequest("user not ound"); }

            return Ok(myuser);
        }
    }
}
