﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShowcaseRVHub.WebApi.Data;

#nullable disable

namespace ShowcaseRVHub.WebApi.Migrations
{
    [DbContext(typeof(ShowcaseDbContext))]
    [Migration("20230711220834_UpdateConstraintsOnVehicleRentalRenter")]
    partial class UpdateConstraintsOnVehicleRentalRenter
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsExteriorCleaned")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFluidChecked")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsInteriorCleaned")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsMaintenance")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRenterTrained")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsSignalsChecked")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsSystemsChecked")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsTireInspected")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RenterId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("VehicleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RenterId");

                    b.HasIndex("UserId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.ShowcaseRenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Renters");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.ShowcaseUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsRemembered")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ShowcaseUsers");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.VehicleRv", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Chassis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte>("Class")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte>("FuelLevel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GeneratorHours")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasGenerator")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasSlideout")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Height")
                        .HasColumnType("REAL");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Length")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte>("MasterBedType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<double>("Odometer")
                        .HasColumnType("REAL");

                    b.Property<int>("RenterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sleeps")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RenterId");

                    b.HasIndex("UserId");

                    b.ToTable("VehicleRVs");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.Rental", b =>
                {
                    b.HasOne("ShowcaseRVHub.WebApi.Models.ShowcaseRenter", "Renter")
                        .WithMany()
                        .HasForeignKey("RenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShowcaseRVHub.WebApi.Models.ShowcaseUser", "User")
                        .WithMany("Rentals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShowcaseRVHub.WebApi.Models.VehicleRv", "Vehicle")
                        .WithMany("Rentals")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Renter");

                    b.Navigation("User");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.VehicleRv", b =>
                {
                    b.HasOne("ShowcaseRVHub.WebApi.Models.ShowcaseRenter", "Renter")
                        .WithMany("Vehicles")
                        .HasForeignKey("RenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShowcaseRVHub.WebApi.Models.ShowcaseUser", "User")
                        .WithMany("Vehicles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Renter");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.ShowcaseRenter", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.ShowcaseUser", b =>
                {
                    b.Navigation("Rentals");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("ShowcaseRVHub.WebApi.Models.VehicleRv", b =>
                {
                    b.Navigation("Rentals");
                });
#pragma warning restore 612, 618
        }
    }
}
