using Microsoft.EntityFrameworkCore;
using Pikos.Models.Entities;

namespace Pikos.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
