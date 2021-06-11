using Microsoft.EntityFrameworkCore;

namespace Web._931803.Chegodaeva.Lab5._1.Models
{
    public sealed class AppContext : DbContext
    {
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public AppContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public AppContext()
        {
        }
    }
}