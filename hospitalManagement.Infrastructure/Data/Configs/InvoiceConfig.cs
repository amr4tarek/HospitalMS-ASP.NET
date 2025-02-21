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
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Amount)
                   .HasColumnType("decimal(18,2)");

            builder.Property(i => i.PaymentStatus)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasOne(i => i.Patient)
                   .WithMany(p => p.Invoices)
                   .HasForeignKey(i => i.PatientId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Optional relationship with Appointment.
            builder.HasOne(i => i.Appointment)
                   .WithMany()
                   .HasForeignKey(i => i.AppointmentId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(i => i.Payments)
                   .WithOne(p => p.Invoice)
                   .HasForeignKey(p => p.InvoiceId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
