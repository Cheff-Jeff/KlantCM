using CMAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CMAPI.Data
{
    public class DataContext :DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
