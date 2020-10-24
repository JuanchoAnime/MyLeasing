﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyLeasing.Api.Infrastructure.Data;

namespace MyLeasing.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201024171550_complete-db")]
    partial class completedb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyLeasing.Api.Infrastructure.Data.Entities.ContractDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("LesseeId");

                    b.Property<int?>("OwnerId");

                    b.Property<decimal>("Price");

                    b.Property<int?>("PropertyId");

                    b.Property<string>("Remarks")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("LesseeId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PropertyId");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("MyLeasing.Api.Infrastructure.Data.Entities.LesseeDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<string>("CellPhone")
                        .HasMaxLength(20);

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FixedPhone")
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Lessee");
                });

            modelBuilder.Entity("MyLeasing.Api.Infrastructure.Data.Entities.OwnerDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<string>("CellPhone")
                        .HasMaxLength(20);

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FixedPhone")
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("MyLeasing.Api.Infrastructure.Data.Entities.PropertyDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("HasParkingLot");

                    b.Property<bool>("IsAvailable");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("OwnerId");

                    b.Property<decimal>("Price");

                    b.Property<int?>("PropertyTypeId");

                    b.Property<string>("Remarks");

                    b.Property<int>("Rooms");

                    b.Property<int>("SquareMeters");

                    b.Property<int>("Stratum");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PropertyTypeId");

                    b.ToTable("Property");
                });

            modelBuilder.Entity("MyLeasing.Api.Infrastructure.Data.Entities.PropertyImageDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<int?>("PropertyId");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropertyImage");
                });

            modelBuilder.Entity("MyLeasing.Api.Infrastructure.Data.Entities.PropertyTypeDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("PropertyType");
                });

            modelBuilder.Entity("MyLeasing.Api.Infrastructure.Data.Entities.ContractDto", b =>
                {
                    b.HasOne("MyLeasing.Api.Infrastructure.Data.Entities.LesseeDto", "Lessee")
                        .WithMany("Contracts")
                        .HasForeignKey("LesseeId");

                    b.HasOne("MyLeasing.Api.Infrastructure.Data.Entities.OwnerDto", "Owner")
                        .WithMany("Contracts")
                        .HasForeignKey("OwnerId");

                    b.HasOne("MyLeasing.Api.Infrastructure.Data.Entities.PropertyDto", "Property")
                        .WithMany("Contracts")
                        .HasForeignKey("PropertyId");
                });

            modelBuilder.Entity("MyLeasing.Api.Infrastructure.Data.Entities.PropertyDto", b =>
                {
                    b.HasOne("MyLeasing.Api.Infrastructure.Data.Entities.OwnerDto", "Owner")
                        .WithMany("Properties")
                        .HasForeignKey("OwnerId");

                    b.HasOne("MyLeasing.Api.Infrastructure.Data.Entities.PropertyTypeDto", "PropertyType")
                        .WithMany("Properties")
                        .HasForeignKey("PropertyTypeId");
                });

            modelBuilder.Entity("MyLeasing.Api.Infrastructure.Data.Entities.PropertyImageDto", b =>
                {
                    b.HasOne("MyLeasing.Api.Infrastructure.Data.Entities.PropertyDto", "Property")
                        .WithMany("PropertiesImages")
                        .HasForeignKey("PropertyId");
                });
#pragma warning restore 612, 618
        }
    }
}