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
            percentage = Math.Round(percentage, 2);
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
            percentage = Math.Round(percentage, 2);
            return Ok(percentage);
        }

        [HttpGet("GetAverageRatingFromLastMonth")]
        public async Task<ActionResult> GetAverageRatingFromLastMonth()
        {
            var firstDay = DateTime.Today.AddDays(-30);


            List<Rating> ratingList = await _context.Ratings
                .Where(r =>
                r.TimeOfRating >= firstDay)
                .ToListAsync();
            Statistics stats = new Statistics();
            double percentage = stats.AverageRating(ratingList);
            if (percentage == null || percentage == 0) { return BadRequest("Sumthing went wrung :("); }
            percentage = Math.Round(percentage, 2);
            return Ok(percentage);
        }

        [HttpGet("GetMessageCountByChatID")]
        public async Task<ActionResult> GetMessageCountByChatID(int ChatID)
        {
            List<Message> messages = await _context.Messages
                .Where(r => r.ChatId == ChatID).
                ToListAsync();
            int count = messages.Count;
            return Ok(count);
        }

        [HttpGet("GetAverageMessageFromAllChats")]
        public async Task<ActionResult> GetAverageMessageFromAllChats()
        {
            Statistics stats = new Statistics();
            int messages = await _context.Messages.MaxAsync(e => e.MessageId);
            int chats = await _context.Chats.MaxAsync(e => e.ChatId);
            double average = stats.Average(messages, chats);
            return Ok(average);
        }

        [HttpGet("GetAverageMessageByUserID")]
        public async Task<ActionResult> GetAverageMessageByUserID(int UserID)
        {
            Statistics stats = new Statistics();
            int messageCount = _context.Messages.Count(m => m.Chat.Room.UserID == UserID);

            int chatCount = _context.Chats.Count(c => c.Room.UserID == UserID);

            double average = stats.Average(messageCount,chatCount);
            return Ok(average);
        }

    }
}