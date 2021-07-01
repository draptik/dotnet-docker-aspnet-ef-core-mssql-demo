using DemoWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApplication
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}