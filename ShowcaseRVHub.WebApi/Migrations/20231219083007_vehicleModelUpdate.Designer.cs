﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShowcaseRVHub.WebApi.Data;

#nullable disable

namespace ShowcaseRVHub.WebApi.Migrations
{
    [DbContext(typeof(ShowcaseDbContext))]
    [Migration("20231219090716_vehicleModelUpdate")]
    partial class vehicleModelUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.Arrival", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte>("BlackWater")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte>("FuelLevel")
                        .HasColumnType("tinyint");

                    b.Property<byte>("GrayWater")
                        .HasColumnType("tinyint");

                    b.Property<bool>("IsCheckInComplete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsExteriorCleaned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInteriorCleaned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSignalsChecked")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Propane")
                        .HasColumnType("tinyint");

                    b.Property<int>("RentalId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Arrivals");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.Departure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte>("BlackWater")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte>("FuelLevel")
                        .HasColumnType("tinyint");

                    b.Property<byte>("GrayWater")
                        .HasColumnType("tinyint");

                    b.Property<bool>("IsExteriorCleaned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInteriorCleaned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRenterTrained")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSignalsChecked")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Propane")
                        .HasColumnType("tinyint");

                    b.Property<int>("RentalId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Departures");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArrivalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartureId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RentalEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RentalStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("RenterId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArrivalId")
                        .IsUnique()
                        .HasFilter("[ArrivalId] IS NOT NULL");

                    b.HasIndex("DepartureId")
                        .IsUnique()
                        .HasFilter("[DepartureId] IS NOT NULL");

                    b.HasIndex("RenterId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.RvMaintenance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFluidChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMaintenance")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSystemsChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTireInspected")
                        .HasColumnType("bit");

                    b.Property<DateTime>("MaintenanceEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MaintenanceStart")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Maintenances");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.ShowcaseRenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Renters");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.ShowcaseUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRemembered")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ShowcaseUsers");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.VehicleRv", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Chassis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Class")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GeneratorHours")
                        .HasColumnType("int");

                    b.Property<bool>("HasGenerator")
                        .HasColumnType("bit");

                    b.Property<bool>("HasSlideout")
                        .HasColumnType("bit");

                    b.Property<double?>("Height")
                        .HasColumnType("float");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("bit");

                    b.Property<int?>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("MasterBedType")
                        .HasColumnType("tinyint");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("Odometer")
                        .HasColumnType("float");

                    b.Property<int>("Sleeps")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("VehicleRVs");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.VehicleRvRenter", b =>
                {
                    b.Property<int?>("RenterId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("RenterId", "VehicleId");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehicleRvRenters");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.Arrival", b =>
                {
                    b.HasOne("ShowcaseRVHub.WebApi.Models.ShowcaseUser", "User")
                        .WithMany("Arrivals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.Departure", b =>
                {
                    b.HasOne("ShowcaseRVHub.WebApi.Models.ShowcaseUser", "User")
                        .WithMany("Departures")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.Rental", b =>
                {
                    b.HasOne("ShowcaseRVHub.WebApi.Models.Arrival", "Arrival")
                        .WithOne("Rental")
                        .HasForeignKey("ShowcaseRVHub.WebApi.Models.Rental", "ArrivalId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("ShowcaseRVHub.WebApi.Models.Departure", "Departure")
                        .WithOne("Rental")
                        .HasForeignKey("ShowcaseRVHub.WebApi.Models.Rental", "DepartureId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("ShowcaseRVHub.WebApi.Models.ShowcaseRenter", "Renter")
                        .WithMany("Rentals")
                        .HasForeignKey("RenterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ShowcaseRVHub.WebApi.Models.VehicleRv", "Vehicle")
                        .WithMany("Rentals")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Arrival");

                    b.Navigation("Departure");

                    b.Navigation("Renter");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.RvMaintenance", b =>
                {
                    b.HasOne("ShowcaseRVHub.WebApi.Models.ShowcaseUser", "User")
                        .WithMany("RvMaintenances")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ShowcaseRVHub.WebApi.Models.VehicleRv", "Vehicle")
                        .WithMany("RvMaintenances")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.VehicleRv", b =>
                {
                    b.HasOne("ShowcaseRVHub.WebApi.Models.ShowcaseUser", "User")
                        .WithMany("Vehicles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.VehicleRvRenter", b =>
                {
                    b.HasOne("ShowcaseRVHub.WebApi.Models.ShowcaseRenter", "Renter")
                        .WithMany("VehicleRvRenters")
                        .HasForeignKey("RenterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ShowcaseRVHub.WebApi.Models.VehicleRv", "Vehicle")
                        .WithMany("VehicleRvRenters")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Renter");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.Arrival", b =>
                {
                    b.Navigation("Rental")
                        .IsRequired();
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.Departure", b =>
                {
                    b.Navigation("Rental")
                        .IsRequired();
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.ShowcaseRenter", b =>
                {
                    b.Navigation("Rentals");

                    b.Navigation("VehicleRvRenters");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.ShowcaseUser", b =>
                {
                    b.Navigation("Arrivals");

                    b.Navigation("Departures");

                    b.Navigation("RvMaintenances");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.VehicleRv", b =>
                {
                    b.Navigation("Rentals");

                    b.Navigation("RvMaintenances");

                    b.Navigation("VehicleRvRenters");
                });
#pragma warning restore 612, 618
        }
    }
}
