using hospitalManagement.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Infrastructure.Data.Configs
{
    public class MedicalRecordConfig : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.ToTable("MedicalRecords");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Diagnosis)
                   .IsRequired();

            builder.HasOne(m => m.Patient)
                   .WithMany(p => p.MedicalRecords)
                   .HasForeignKey(m => m.PatientId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.Doctor)
                   .WithMany(d => d.MedicalRecords)
                   .HasForeignKey(m => m.DoctorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.Prescriptions)
                   .WithOne(p => p.MedicalRecord)
                   .HasForeignKey(p => p.MedicalRecordId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
