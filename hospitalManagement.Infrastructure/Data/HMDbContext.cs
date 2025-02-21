using hospitalManagement.Domain.Models.Users;
using hospitalManagement.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace hospitalManagement.Infrastructure.Data
{
    public class HMDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public HMDbContext(DbContextOptions<HMDbContext> options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<LabTest> LabTests { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceAllocation> ResourceAllocations { get; set; }
        public DbSet<StaffSchedule> StaffSchedules { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HMDbContext).Assembly);
        }
    }
}
