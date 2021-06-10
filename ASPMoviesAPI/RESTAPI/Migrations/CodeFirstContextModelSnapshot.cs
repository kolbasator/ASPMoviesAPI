﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RESTAPI.Data;

namespace RESTAPI.Migrations
{
    [DbContext(typeof(CodeFirstContext))]
    partial class CodeFirstContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "English_United Kingdom.1252")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("RESTAPI.Models.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Firstname")
                        .HasColumnType("text");

                    b.Property<string>("Lastname")
                        .HasColumnType("text");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("RESTAPI.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Firstname")
                        .HasColumnType("text");

                    b.Property<string>("Lastname")
                        .HasColumnType("text");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("RESTAPI.Models.Copy", b =>
                {
                    b.Property<int>("CopyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.HasKey("CopyId");

                    b.HasIndex(new[] { "MovieId" }, "IX_Copies_MovieId");

                    b.ToTable("Copies");
                });

            modelBuilder.Entity("RESTAPI.Models.Employee", b =>
                {
                    b.Property<string>("Firstname")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("''::text");

                    b.Property<string>("Lastname")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("''::text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.HasKey("Firstname", "Lastname");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RESTAPI.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AgeRestriction")
                        .HasColumnType("integer");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("RESTAPI.Models.Rental", b =>
                {
                    b.Property<int>("CopyId")
                        .HasColumnType("integer");

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DateOfRental")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateOfReturn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("CopyId", "ClientId");

                    b.HasIndex(new[] { "ClientId" }, "IX_Rentals_ClientId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("RESTAPI.Models.Starring", b =>
                {
                    b.Property<int>("ActorId")
                        .HasColumnType("integer");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.HasKey("ActorId", "MovieId");

                    b.HasIndex(new[] { "MovieId" }, "IX_Starring_MovieId");

                    b.ToTable("Starring");
                });

            modelBuilder.Entity("RESTAPI.Models.Copy", b =>
                {
                    b.HasOne("RESTAPI.Models.Movie", "Movie")
                        .WithMany("Copies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("RESTAPI.Models.Rental", b =>
                {
                    b.HasOne("RESTAPI.Models.Client", "Client")
                        .WithMany("Rentals")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RESTAPI.Models.Copy", "Copy")
                        .WithMany("Rentals")
                        .HasForeignKey("CopyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Copy");
                });

            modelBuilder.Entity("RESTAPI.Models.Starring", b =>
                {
                    b.HasOne("RESTAPI.Models.Actor", "Actor")
                        .WithMany("Starrings")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RESTAPI.Models.Movie", "Movie")
                        .WithMany("Starrings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("RESTAPI.Models.Actor", b =>
                {
                    b.Navigation("Starrings");
                });

            modelBuilder.Entity("RESTAPI.Models.Client", b =>
                {
                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("RESTAPI.Models.Copy", b =>
                {
                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("RESTAPI.Models.Movie", b =>
                {
                    b.Navigation("Copies");

                    b.Navigation("Starrings");
                });
#pragma warning restore 612, 618
        }
    }
}
