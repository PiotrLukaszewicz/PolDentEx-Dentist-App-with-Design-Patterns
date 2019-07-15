using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PolDentEx.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<PolDentEx.Models.Patient> Patients { get; set; }

        public System.Data.Entity.DbSet<PolDentEx.Models.Doctor> Doctors { get; set; }

        public System.Data.Entity.DbSet<PolDentEx.Models.Appointment> Appointments { get; set; }

        public System.Data.Entity.DbSet<PolDentEx.Models.HumanTooth> HumanTooths { get; set; }

        public System.Data.Entity.DbSet<PolDentEx.Models.Tooth> Teeth { get; set; }

        public System.Data.Entity.DbSet<PolDentEx.Models.PatientCard> PatientCards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasRequired(c => c.PatientDetails)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasRequired(c => c.Doctor)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Appointment>()
                .HasRequired(c => c.Patient)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Appointment>()
                .HasRequired(c => c.Doctor)
                .WithMany()
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<PolDentEx.Models.TreatmentOnAppointment> TreatmentOnAppointments { get; set; }

        public System.Data.Entity.DbSet<PolDentEx.Models.Treatment> Treatments { get; set; }
    }
}