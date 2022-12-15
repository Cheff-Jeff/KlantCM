using CM_API_EF;
using CM_API_EF.Controllers;
using CM_API_EF.Data;
using CM_API_EF.Models;
using Microsoft.AspNetCore.Mvc;
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
        VerifyInfo info = new VerifyInfo();

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
            controller = new StatisticsController(_context);
        }

        private List<Message> seed_message()
        {
            int messageid = 1;
            List<Message> messages = new List<Message>();
            //loops through all of the chats
            for(int i = 1; i < 10; i++)
            {
                //for each chat it makes 2 messages
                for(int j =1; j < 3; j++)
                {
                    Message message = new Message
                    {
                        MessageId = messageid,
                        ChatId = i,
                        Text = "This better works otherwise i'll be getting a crippling depression"
                    };
                    messages.Add(message);
                    messageid++;
                }
            }
            _messages = messages;
            return messages;
        }

        private List<Chat> seed_chat()
        {
            List<Chat> chats = new List<Chat>();
            foreach(Room room in _rooms)
            {
                Chat chat = new Chat
                {
                    RoomId = room.RoomId,
                    ChatId = room.RoomId
                };
                chats.Add(chat);
            }
            _chats = chats;
            return chats;
        }

        private List<Room> seed_room()
        {
            List<Room> rooms = new List<Room>();
            for (int i = 1; i <4; i++)
            {
                Room room = new Room
                {
                    RoomId = i,
                    UserID = 1
                };
                rooms.Add(room);
            }

            for (int i = 4; i < 7; i++)
            {
                Room room = new Room
                {
                    RoomId = i,
                    UserID = 2
                };
                rooms.Add(room);
            }

            for (int i = 7; i <10; i++)
            {
                Room room = new Room
                {
                    RoomId = i,
                    UserID = 3
                };
                rooms.Add(room);
            }
            _rooms = rooms;
            return rooms;
        }

        private List<User> seed_user()
        {
            info.CreatePasswordHash("lekker", out byte[] pwhash, out byte[] pwsalt);
            List<User> users = new List<User>
            {
                new User
                {
                    userId =1,
                    userName = "admin",
                    Email = "admin@example.com",
                    isAdmin = true,
                    passwordHash = pwhash,
                    passwordSalt = pwsalt
                },
                new User
                {
                    userId =2,
                    userName = "peter",
                    Email = "peter@example.com",
                    isAdmin = false,
                    passwordHash = pwhash,
                    passwordSalt = pwsalt
                },
                new User
                {
                    userId =3,
                    userName = "sjaak",
                    Email = "sjaak@example.com",
                    isAdmin = false,
                    passwordHash = pwhash,
                    passwordSalt = pwsalt
                }
            };
            _users = users;

            return users;
        }


        //finally some tests 0_0
        [Fact]
        public async void GetAverageMessageByUserID_Test()
        {
            //arrange

            //act
            var response = await controller.GetAverageMessageByUserID(1);
            var result = (ObjectResult)response;
            double average = (double)result.Value;

            //assert
            Assert.Equal(2, average);

        }

        [Fact]
        public async void GetAverageFromAllChats_Test()
        {
            //arrange

            //act
            var response = await controller.GetAverageMessageFromAllChats();
            var result = (ObjectResult)response;
            double average = (double)result.Value;
            //assert
            Assert.Equal(2, average);
        }

        [Fact]
        public async void GetMessageCountByChatID_Test()
        {
            //arrange

            //act
            var response = await controller.GetMessageCountByChatID(1);
            var result = (ObjectResult)response;
            int count = (int)result.Value;
            //assert
            Assert.Equal(2, count);
        }






    }
}
