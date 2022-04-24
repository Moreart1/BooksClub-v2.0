using BooksClub.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksClub.DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ModelBooks> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelBooks>();           
        }
    }
}
