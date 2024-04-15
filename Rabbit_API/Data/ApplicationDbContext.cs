using Microsoft.EntityFrameworkCore;
using Rabbit_API.Models;

namespace Rabbit_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Models.Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Commentary> Commentaries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reply> Replies { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
   
        }
    }
}
