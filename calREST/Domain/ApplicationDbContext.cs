using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace calREST.Domain
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}