﻿// <auto-generated />
using System;
using Festifact.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Festifact.Api.Migrations
{
    [DbContext(typeof(FestifactDbContext))]
    [Migration("20230607165407_Added ticketsremaining to festival")]
    partial class Addedticketsremainingtofestival
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Festifact.Api.Entities.Festival", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AgeCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Banner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<int>("MaxTickets")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganiserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TicketsRemaining")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Festivals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "baz",
                            Genre = 0,
                            MaxTickets = 250,
                            Name = "bar",
                            OrganiserId = 1,
                            TicketsRemaining = 0,
                            Type = 0
                        });
                });

            modelBuilder.Entity("Festifact.Api.Entities.FestivalPerformance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FestivalId")
                        .HasColumnType("int");

                    b.Property<int>("ShowId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FestivalPerformances");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FestivalId = 1,
                            ShowId = 1
                        },
                        new
                        {
                            Id = 2,
                            FestivalId = 1,
                            ShowId = 2
                        });
                });

            modelBuilder.Entity("Festifact.Api.Entities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Actors")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryOfOrigin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Films");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Actors = "Fairies",
                            CountryOfOrigin = "LaLaLand",
                            Description = "Empty",
                            Director = "Not available",
                            Name = "Placeholder",
                            Year = 0
                        });
                });

            modelBuilder.Entity("Festifact.Api.Entities.ImageUri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FestivalId")
                        .HasColumnType("int");

                    b.Property<string>("Uri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FestivalId");

                    b.ToTable("ImageUri");
                });

            modelBuilder.Entity("Festifact.Api.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<int?>("FestivalId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gps")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FestivalId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 1000,
                            Name = "My backyard"
                        });
                });

            modelBuilder.Entity("Festifact.Api.Entities.Organiser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organisers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "foo"
                        });
                });

            modelBuilder.Entity("Festifact.Api.Entities.Performer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryOfOrigin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("ImageFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Performers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryOfOrigin = "Iceland",
                            Description = "Coolino",
                            Genre = 0,
                            Name = "Coolio",
                            Type = 0
                        });
                });

            modelBuilder.Entity("Festifact.Api.Entities.Show", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FilmId")
                        .HasColumnType("int");

                    b.Property<string>("ImageFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PerformerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Shows");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Show by Coolio",
                            EndDateTime = new DateTime(2023, 6, 7, 20, 54, 7, 779, DateTimeKind.Local).AddTicks(8107),
                            LocationId = 1,
                            Name = "Coolio",
                            PerformerId = 1,
                            StartDateTime = new DateTime(2023, 6, 7, 18, 54, 7, 779, DateTimeKind.Local).AddTicks(8067)
                        },
                        new
                        {
                            Id = 2,
                            Description = "Film",
                            EndDateTime = new DateTime(2023, 6, 7, 20, 54, 7, 779, DateTimeKind.Local).AddTicks(8122),
                            FilmId = 1,
                            LocationId = 1,
                            Name = "Film",
                            StartDateTime = new DateTime(2023, 6, 7, 18, 54, 7, 779, DateTimeKind.Local).AddTicks(8120)
                        });
                });

            modelBuilder.Entity("Festifact.Api.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FestivalId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FestivalId = 1
                        });
                });

            modelBuilder.Entity("Festifact.Api.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Hogeschoollaan 1",
                            DateOfBirth = new DateTime(2003, 6, 7, 18, 54, 7, 779, DateTimeKind.Local).AddTicks(8158),
                            Email = "piet@test.nl",
                            Name = "Piet"
                        });
                });

            modelBuilder.Entity("Festifact.Api.Entities.ImageUri", b =>
                {
                    b.HasOne("Festifact.Api.Entities.Festival", null)
                        .WithMany("Images")
                        .HasForeignKey("FestivalId");
                });

            modelBuilder.Entity("Festifact.Api.Entities.Location", b =>
                {
                    b.HasOne("Festifact.Api.Entities.Festival", null)
                        .WithMany("Locations")
                        .HasForeignKey("FestivalId");
                });

            modelBuilder.Entity("Festifact.Api.Entities.Festival", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}