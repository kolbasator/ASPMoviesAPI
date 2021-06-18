using Microsoft.EntityFrameworkCore;
using RESTAPI.Models;

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
            modelBuilder.Entity<Copy>(entity =>
            {
                entity.HasIndex(e => e.MovieId, "IX_Copies_MovieId");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Copies)
                    .HasForeignKey(d => d.MovieId);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => new { e.Firstname, e.Lastname });

                entity.Property(e => e.Firstname).HasDefaultValueSql("''::text");

                entity.Property(e => e.Lastname).HasDefaultValueSql("''::text");
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.HasKey(e => new { e.CopyId, e.ClientId });

                entity.HasIndex(e => e.ClientId, "IX_Rentals_ClientId");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.ClientId);

                entity.HasOne(d => d.Copy)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.CopyId);
            });

            modelBuilder.Entity<Starring>(entity =>
            {
                entity.HasKey(e => new { e.ActorId, e.MovieId });

                entity.ToTable("Starring");

                entity.HasIndex(e => e.MovieId, "IX_Starring_MovieId");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.Starrings)
                    .HasForeignKey(d => d.ActorId);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Starrings)
                    .HasForeignKey(d => d.MovieId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
