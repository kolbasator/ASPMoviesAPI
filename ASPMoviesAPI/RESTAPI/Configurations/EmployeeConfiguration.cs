using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RESTAPI.Models;

namespace RESTAPI.Configurations
{
    class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees").HasKey(k => new { k.Firstname, k.Lastname }); 
        }
    }
}
