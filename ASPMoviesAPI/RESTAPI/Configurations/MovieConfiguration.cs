using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RESTAPI.Models;

namespace RESTAPI.Configurations 
{
    class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies").HasKey(m => m.MovieId); 
        }
    }
}
