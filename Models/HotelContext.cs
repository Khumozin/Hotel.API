using Microsoft.EntityFrameworkCore;

namespace Hotel.API.Models
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> opt) : base(opt)
        {

        }

        public DbSet<SystemConfig> SystemConfig { get; set; }
    }
}