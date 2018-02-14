using DataLayer.Entities;
using System.Data.Entity;

namespace DataLayer.Context
{
    public class EwscdContext : DbContext
    {
        public EwscdContext()
            :base("EarlyWarningSystem")
        { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Disease> Disease { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Procedure> Procedures { get; set; }

        public DbSet<Appointment> Appointments { get; set; }
        
        public DbSet<CuratorPatient> CuratorPatients { get; set; }

        public DbSet<DiseaseProcedure> DiseaseProcedure { get; set; }

        public DbSet<PatientDisease> PatientDisease { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
