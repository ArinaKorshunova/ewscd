using DataLayer.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataLayer.Context
{
    public class EwscdContext : DbContext
    {
        public EwscdContext()
            :base("EarlyWarningSystem")
        { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Action> Action { get; set; }

        public DbSet<PatientDoctor> PatientDoctor { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToOneConstraintIntroductionConvention>();

            modelBuilder.Entity<Patient>().HasRequired(f => f.Curator).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Employee>().HasRequired(f => f.User).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Action>().HasRequired(f => f.Doctor).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Action>().HasRequired(f => f.Patient).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientDoctor>().HasRequired(f => f.Patient).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientDoctor>().HasRequired(f => f.Doctor).WithMany().WillCascadeOnDelete(false);
        }

        public void DetectAndSaveChanges()
        {
            ChangeTracker.DetectChanges();
            SaveChanges();
        }
    }
}
