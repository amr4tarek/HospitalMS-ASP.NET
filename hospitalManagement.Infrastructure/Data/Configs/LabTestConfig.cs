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
    public class LabTestConfig : IEntityTypeConfiguration<LabTest>
    {
        public void Configure(EntityTypeBuilder<LabTest> builder)
        {
            builder.ToTable("LabTests");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.TestType)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(l => l.Status)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasOne(l => l.Patient)
                   .WithMany(p => p.LabTests)
                   .HasForeignKey(l => l.PatientId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(l => l.OrderedByDoctor)
                   .WithMany(d => d.LabTests)
                   .HasForeignKey(l => l.OrderedByDoctorId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
