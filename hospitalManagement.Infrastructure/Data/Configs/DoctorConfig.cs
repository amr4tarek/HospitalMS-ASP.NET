using hospitalManagement.Domain.Models.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Infrastructure.Data.Configs
{
    public class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Specialization)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Qualifications)
                .HasMaxLength(200);

            builder.Property(d => d.ClinicAddress)
                .HasMaxLength(200);

            // Ensure one-to-one relationship with ApplicationUser and enforce uniqueness.
            builder.HasIndex(d => d.ApplicationUserId).IsUnique();

            builder.HasOne(d => d.ApplicationUser)
                   .WithOne()
                   .HasForeignKey<Doctor>(d => d.ApplicationUserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
