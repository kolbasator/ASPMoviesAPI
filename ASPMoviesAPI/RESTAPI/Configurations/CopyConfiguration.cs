using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RESTAPI.Models;

namespace RESTAPI.Configurations
{
    class CopyConfiguration : IEntityTypeConfiguration<Copy>
    {
        public void Configure(EntityTypeBuilder<Copy> builder)
        {
            builder.ToTable("Copies").HasKey(c => c.CopyId);
            builder.ToTable("Copies").HasOne(c => c.Movie).WithMany(m => m.Copies).HasForeignKey(m => m.MovieId);
        }

    }

}
