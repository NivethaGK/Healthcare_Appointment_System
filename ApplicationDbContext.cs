using Microsoft.EntityFrameworkCore;
using HealthcareAppointmentSystem.Models;

namespace HealthcareAppointmentSystem.Data
{
   
   public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
    }
}

