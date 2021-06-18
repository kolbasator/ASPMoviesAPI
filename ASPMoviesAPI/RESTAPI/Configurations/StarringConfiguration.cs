using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RESTAPI.Models;

namespace RESTAPI.Configurations
{
    class StarringConfiguration : IEntityTypeConfiguration<Starring>
    {
        public void Configure(EntityTypeBuilder<Starring> builder)
        {
            builder.ToTable("Starring").HasKey(k => new { k.ActorId, k.MovieId });
            builder.ToTable("Starring").HasOne(s => s.Movie).WithMany(m => m.Starrings).HasForeignKey(m => m.MovieId);
            builder.ToTable("Starring").HasOne(s => s.Actor).WithMany(act => act.Starrings).HasForeignKey(act => act.ActorId);
        }
    }
}
