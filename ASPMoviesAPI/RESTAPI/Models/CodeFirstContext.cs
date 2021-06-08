using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RESTAPI.Models
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CodeFirstContextDataBase;Username=postgres;Password=razumovsky123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United Kingdom.1252");

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
