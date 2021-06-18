using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RESTAPI.Models;

namespace RESTAPI.Configurations
{
    class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.ToTable("Rentals").HasKey(k => new { k.CopyId, k.ClientId });
            builder.ToTable("Rentals").HasOne(r => r.Copy).WithMany(m => m.Rentals).HasForeignKey(m => m.CopyId);
            builder.ToTable("Rentals").HasOne(r => r.Client).WithMany(c => c.Rentals).HasForeignKey(c => c.ClientId); 
        }
    }
}
