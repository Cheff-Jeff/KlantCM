using CM_API_EF.Controllers;
using CM_API_EF.Data;
using CM_API_EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM_API_EF_UnitTests
{
    public class StatisticsControllerTest
    {
        //creating everything i need to use to make proper test and setting up a temporary database
        private readonly UserDbContext _context;
        private readonly StatisticsController controller;

        private List<User> _users = new List<User>();
        private List<Room> _rooms = new List<Room>();
        private List<Chat> _chats = new List<Chat>();
        private List<Message> _messages = new List<Message>();

        //making a constructor which creates the temporary database and also fills it with data
        public StatisticsControllerTest()
        {
            var options = new DbContextOptionsBuilder<UserDbContext>()
                .UseInMemoryDatabase(databaseName: "db").Options;

            _context = new UserDbContext(options);
            _context.Database.EnsureDeleted();
            _context.Users.AddRange(seed_user());
            _context.Rooms.AddRange(seed_room());
            _context.Chats.AddRange(seed_chat());
            _context.Messages.AddRange(seed_message());
            _context.SaveChanges();
        }

        private List<Message> seed_message()
        {
            List<Message> messages = new List<Message>();

            return messages;
        }

        private List<Chat> seed_chat()
        {
            List<Chat> chats = new List<Chat>();

            return chats;
        }

        private List<Room> seed_room()
        {
            List<Room> rooms = new List<Room>();
            for (int i = 1; i < 3; i++)
            {
                Room room = new Room
                {
                    RoomId = i,
                    UserID = 1
                };
                rooms.Add(room);
            }

            return rooms;
        }

        private List<User> seed_user()
        {
            List<User> users = new List<User>
            {
                new User
                {
                    userId =1,
                    userName = "admin",
                    Email = "admin@example.com",
                    isAdmin = true,
                },
                new User
                {
                    userId =2,
                    userName = "peter",
                    Email = "peter@example.com",
                    isAdmin = false,
                },
                new User
                {
                    userId =3,
                    userName = "sjaak",
                    Email = "sjaak@example.com",
                    isAdmin = false,
                }
            };
            _users = users;

            return users;
        }




    }
}
