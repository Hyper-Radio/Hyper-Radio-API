using Hyper_Radio_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Radio_API.Data
{
    public class HyperRadioDbContext : DbContext

    {
        public HyperRadioDbContext(DbContextOptions<HyperRadioDbContext> options) : base(options)
        {     
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Follow> Follows { get; set; }
    }
}
