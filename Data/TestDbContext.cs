using Microsoft.EntityFrameworkCore;

using Data.Models;

namespace Data
{
    public class TestDbContext : DbContext
    {
        public TestDbContext()//Default for ef migrations
        : base(GetOptions(""))
        {
        }
        public TestDbContext(string connectionString)
        : base(GetOptions(connectionString))
        {
        }
        private static DbContextOptions GetOptions(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))//Default for ef migrations
                connectionString = "Server=.\\SQLEXPRESS;Database=TEST;Integrated Security=true;";
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
