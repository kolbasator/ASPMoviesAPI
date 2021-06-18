using Microsoft.EntityFrameworkCore;
using RESTAPI.Models;
using RESTAPI.Configurations;
#nullable disable

namespace RESTAPI.Data
{
    public partial class CodeFirstContext : DbContext
    {
        public CodeFirstContext()
        {
        }

        public CodeFirstContext(DbContextOptions<CodeFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Copy> Copies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<Starring> Starrings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CodeFirstContextDataBase;Username=postgres;Password=razumovsky123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new CopyConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new RentalConfiguration());
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new StarringConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
