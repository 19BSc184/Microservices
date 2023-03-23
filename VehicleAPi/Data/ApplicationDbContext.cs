using Microsoft.EntityFrameworkCore;
using VehicleAPi.Models;

namespace VehicleAPi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        { 
        }
        //public DbSet<Vehicle> Vehicles { get; set; }

    }
}
