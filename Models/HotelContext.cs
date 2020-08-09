using Microsoft.EntityFrameworkCore;

namespace Hotel.API.Models
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> opt) : base(opt)
        {

        }

        public DbSet<SystemConfig> SystemConfig { get; set; }
        public DbSet<HotelFeature> HotelFeature { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomImage> RoomImage { get; set; }
        public DbSet<RoomFeature> RoomFeature { get; set; }
        public DbSet<Email> Email { get; set; }
    }
}