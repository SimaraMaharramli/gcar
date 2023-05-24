using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Domain.Configurations
{
    public class SubLocationConfiguration : IEntityTypeConfiguration<SubLocation>
    {
        public void Configure(EntityTypeBuilder<SubLocation> builder)
        {
            builder.Property(m => m.SoftDelete).HasDefaultValue(false);
            builder.Property(m => m.LocationId).IsRequired();
            builder.HasQueryFilter(m => !m.SoftDelete);
        }
    }
}
