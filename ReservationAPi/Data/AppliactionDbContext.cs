using Microsoft.EntityFrameworkCore;
using ReservationAPi.Models;

namespace ReservationAPi.Data
{
    public class AppliactionDbContext:DbContext
    {
        public AppliactionDbContext(DbContextOptions<AppliactionDbContext> options) : base(options)
        
        {

        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

    }
}
