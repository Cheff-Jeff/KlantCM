using CM_API_EF.Data;
using CM_API_EF.DTO_s;
using CM_API_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks.Dataflow;

namespace CM_API_EF.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : Controller
    {
        public readonly UserDbContext _context;
        public RatingController(UserDbContext context)
        {
            _context = context;
        }

        [HttpPost("giveRating")]
        public async Task<ActionResult<Rating>> GiveRating(RatingDTO dto)
        {
            var newRating = new Rating
            {
                Rate = dto.Rating,
                TimeOfRating = DateTime.Now,
                RoomId = dto.RoomId,
            };
            await _context.Ratings.AddAsync(newRating);
            await _context.SaveChangesAsync();

            return Ok(newRating);

        }
        [HttpGet("GetAllRatings")]
        public async Task<ActionResult<Rating>> SelectAllRatings()
        {
            List<Rating> AllRatings = await _context.Ratings.ToListAsync();
            await _context.SaveChangesAsync();

            return Ok(AllRatings);
        }

        [HttpGet("GetAllRatingsAboutWorker")]
        public async Task<ActionResult<Rating>> SelectAllRatingsWorker(int UserID)
        {
            var Ratings = (from ra in _context.Ratings
                           join ro in _context.Rooms
                           on ra.RoomId equals ro.RoomId
                           where ro.UserID == UserID
                           select ra).ToList();
            await _context.SaveChangesAsync();
            return Ok(Ratings);
        }


    }
}