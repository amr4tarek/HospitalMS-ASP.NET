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
    public class PrescriptionConfig : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("Prescriptions");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.MedicationDetails)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.Dosage)
                   .HasMaxLength(100);

        }
    }
}
