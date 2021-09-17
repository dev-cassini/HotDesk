﻿// <auto-generated />
using System;
using HotDesk.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotDesk.Infrastructure.Migrations
{
    [DbContext(typeof(HotDeskDbContext))]
    [Migration("20210917130344_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DepartmentLocation", b =>
                {
                    b.Property<Guid>("DepartmentsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LocationsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DepartmentsId", "LocationsId");

                    b.HasIndex("LocationsId");

                    b.ToTable("LocationDepartmentMappings");
                });

            modelBuilder.Entity("HotDesk.Domain.Entities.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("DeskId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("EndTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastUpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("StartTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("DeskId");

                    b.HasIndex("PersonId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("HotDesk.Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("LastUpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HotDesk.Domain.Entities.Desk", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("LastUpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("LocationId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Desks");
                });

            modelBuilder.Entity("HotDesk.Domain.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("LastUpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("HotDesk.Domain.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset>("LastUpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("FirstName", "LastName")
                        .IsUnique();

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("DepartmentLocation", b =>
                {
                    b.HasOne("HotDesk.Domain.Entities.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotDesk.Domain.Entities.Location", null)
                        .WithMany()
                        .HasForeignKey("LocationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotDesk.Domain.Entities.Booking", b =>
                {
                    b.HasOne("HotDesk.Domain.Entities.Desk", "Desk")
                        .WithMany("Bookings")
                        .HasForeignKey("DeskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotDesk.Domain.Entities.Person", "Person")
                        .WithMany("Bookings")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Desk");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("HotDesk.Domain.Entities.Desk", b =>
                {
                    b.HasOne("HotDesk.Domain.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotDesk.Domain.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("HotDesk.Domain.Entities.Desk", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("HotDesk.Domain.Entities.Person", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
