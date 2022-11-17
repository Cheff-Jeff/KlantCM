using CM_API_EF.Data;
using CM_API_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CM_API_EF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        public readonly UserDbContext _context;

        VerifyInfo verifyInfo = new VerifyInfo();

        public UserController(UserDbContext context)
        {
            _context = context;
        }

        [HttpGet("getuser")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var myuser = await _context.Users
            .Where(u => u.userId == id)
                         .Select(u => new
                         {
                             u.userId,
                             u.userName,
                             u.Email,
                             u.isAdmin
                             //nog stats toevoegen voor user details.
                         })
                         .ToArrayAsync();

            if (myuser.Length == 0) { return BadRequest("user not found"); }

            return Ok(myuser);
        }

        [HttpGet("getallusers")]
        public async Task<ActionResult> GetAllUsers()
        {
            var myuser = await _context.Users
                         .Select(u => new
                         {
                             u.userId,
                             u.userName,
                             u.Email,
                             u.isAdmin
                         })
                         .ToListAsync();

            return Ok(myuser);
        }

        [HttpPut("edituser")]
        public async Task<ActionResult> EditUser(UserDTO request)
        {
            var myuser = await _context.Users.FindAsync(request.Id);
            if(myuser != null)
            {
                if (request.userName != "") { myuser.userName = request.userName; }
                if (request.Email != "") { myuser.Email = request.Email; }
                if (request.Password != "") 
                {
                    verifyInfo.CreatePasswordHash(request.Password, out byte[] passwordhash, out byte[] passwordsalt);
                    myuser.passwordHash = passwordhash; myuser.passwordSalt = passwordsalt; 
                }
                myuser.isAdmin = request.isAdmin;
                

                await _context.SaveChangesAsync();
                return Ok("user edited");
            }
            return BadRequest("user not found");
        }

        [HttpDelete("deleteuser")]
        public async Task<ActionResult> DeleteUserById(int id)
        {
            var myuser = await _context.Users.FindAsync(id);
            if (myuser != null && myuser.isAdmin == false)
            {
                _context.Users.Remove(myuser);
                await _context.SaveChangesAsync();
                return Ok("user deleted");
            }
            return BadRequest("user not found or user is admin");
        }
    }
}
