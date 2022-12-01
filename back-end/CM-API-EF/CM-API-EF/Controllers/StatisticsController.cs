using CM_API_EF.Business_Logic;
using CM_API_EF.Data;
using CM_API_EF.Models;
using CM_API_EF.StatisticModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CM_API_EF.Controllers
{
    public class StatisticsController : Controller
    {
        public readonly UserDbContext _context;

        public StatisticsController(UserDbContext context)
        {
            _context = context;
        }


        [HttpGet("GetAverageRating")]
        public async Task<ActionResult> GetAverageRating()
        {
            List<Rating> ratingList = await _context.Ratings.ToListAsync();
            Statistics stats = new Statistics();
            double percentage = stats.AverageRating(ratingList);
            return Ok(percentage);
        }

        [HttpGet("GetAverageRatingByUserID")]
        public async Task<ActionResult> GetAverageRatingByUserID(int userID)
        {
            List<Rating> ratingList = (from ra in _context.Ratings
                                       join ro in _context.Rooms
                                       on ra.RoomId equals ro.RoomId
                                       where ro.UserID == userID
                                       select ra).ToList();
            Statistics stats = new Statistics();
            double percentage = stats.AverageRating(ratingList);
            return Ok(percentage);
        }

        [HttpGet("GetAverageRatingFromLastMonth")]
        public async Task<ActionResult> GetAverageRatingFromLastMonth()
        {
            var startOfTthisMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var firstDay = startOfTthisMonth.AddMonths(-1);
            var lastDay = startOfTthisMonth.AddDays(-1);

            List<Rating> ratingList = await _context.Ratings.
                Where(r => 
                r.TimeOfRating >= firstDay &&
                r.TimeOfRating <= lastDay)
                .ToListAsync();
            Statistics stats = new Statistics();
            double percentage = stats.AverageRating(ratingList);
            if(percentage == null) { return BadRequest("Sumthing went wrung"); }

            return Ok(percentage);
        }

    }
}
