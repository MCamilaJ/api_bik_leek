using api_bik_leek.Models;
using Microsoft.EntityFrameworkCore;

namespace api_bik_leek.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
