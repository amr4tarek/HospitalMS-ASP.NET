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
    public class ResourceAllocationConfig : IEntityTypeConfiguration<ResourceAllocation>
    {
        public void Configure(EntityTypeBuilder<ResourceAllocation> builder)
        {
            builder.ToTable("ResourceAllocations");

            builder.HasKey(ra => ra.Id);

            builder.HasOne(ra => ra.Resource)
                   .WithMany()
                   .HasForeignKey(ra => ra.ResourceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ra => ra.Appointment)
                   .WithMany(a => a.ResourceAllocations)
                   .HasForeignKey(ra => ra.AppointmentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
