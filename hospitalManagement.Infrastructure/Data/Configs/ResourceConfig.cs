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
    public class ResourceConfig : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("Resources");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.ResourceType)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(r => r.Identifier)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(r => r.Status)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
