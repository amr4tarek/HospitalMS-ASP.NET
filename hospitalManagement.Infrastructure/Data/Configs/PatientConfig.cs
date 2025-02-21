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
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");

            builder.HasKey(p => p.Id);

            // Enforce a one-to-one relationship with ApplicationUser.
            builder.HasIndex(p => p.ApplicationUserId).IsUnique();

            builder.HasOne(p => p.ApplicationUser)
                   .WithOne()
                   .HasForeignKey<Patient>(p => p.ApplicationUserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Gender)
                   .HasMaxLength(20);

            builder.Property(p => p.Address)
                   .HasMaxLength(200);

            builder.Property(p => p.ContactNumber)
                   .HasMaxLength(50);
        }
    }
}
