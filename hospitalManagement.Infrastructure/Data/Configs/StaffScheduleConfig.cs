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
    public class StaffScheduleConfig : IEntityTypeConfiguration<StaffSchedule>
    {
        public void Configure(EntityTypeBuilder<StaffSchedule> builder)
        {
            builder.ToTable("StaffSchedules");

            builder.HasKey(ss => ss.Id);

            builder.Property(ss => ss.AssignedDepartment)
                   .HasMaxLength(100);

            builder.HasOne(ss => ss.Staff)
                   .WithMany()
                   .HasForeignKey(ss => ss.StaffId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
