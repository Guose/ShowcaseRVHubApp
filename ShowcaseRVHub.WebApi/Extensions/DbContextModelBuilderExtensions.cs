using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Models;
using ShowcaseRVHub.WebApi.Models.EnumTypes;

namespace ShowcaseRVHub.WebApi.Extensions
{
    public static class DbContextModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ShowcaseUser>().HasData(DbSeedData.GetUserSeedData());
            //modelBuilder.Entity<VehicleRv>().HasData(DbSeedData.GetRvSeedData());
            //modelBuilder.Entity<ShowcaseRenter>().HasData(DbSeedData.GetRenterSeedData());
            //modelBuilder.Entity<Rental>().HasData(DbSeedData.GetRentalSeedData());
        }

        public static void ModelCreator(this ModelBuilder modelBuilder)
        {
            // Build User Model
            modelBuilder.Entity<ShowcaseUser>()
                .HasMany(u => u.Arrivals)
                .WithOne(a => a.User)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ShowcaseUser>()
                .HasMany(u => u.Departures)
                .WithOne(a => a.User)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ShowcaseUser>()
                .HasMany(u => u.Vehicles)
                .WithOne(a => a.User)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ShowcaseUser>()
                .HasMany(u => u.RvMaintenances)
                .WithOne(a => a.User)
                .OnDelete(DeleteBehavior.NoAction);

            // Build VehicleRv Model
            modelBuilder.Entity<VehicleRv>()
                .HasMany(r => r.Rentals)
                .WithOne(v => v.Vehicle)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<VehicleRv>()
                .HasMany(r => r.RvMaintenances)
                .WithOne(v => v.Vehicle)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<VehicleRv>()
                .HasOne(u => u.User)
                .WithMany(r => r.Vehicles)
                .HasForeignKey(u => u.UserId);

            // Build Renter Model
            modelBuilder.Entity<ShowcaseRenter>()
                .HasMany(r => r.Rentals)
                .WithOne(r => r.Renter)
                .OnDelete(DeleteBehavior.NoAction);

            // Build Rental Model
            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Arrival)
                .WithOne(a => a.Rental)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Departure)
                .WithOne(d => d.Rental)
                .OnDelete(DeleteBehavior.NoAction);

            // Build Many to Many relationship between Renter and VehicleRv
            modelBuilder.Entity<VehicleRvRenter>()
                .HasKey(rv => new { rv.RenterId, rv.VehicleId });
            modelBuilder.Entity<VehicleRvRenter>()
                .HasOne(rv => rv.Renter)
                .WithMany(renter => renter.VehicleRvRenters)
                .HasForeignKey(rv => rv.RenterId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<VehicleRvRenter>()
                .HasOne(vr => vr.Vehicle)
                .WithMany(vehicle => vehicle.VehicleRvRenters)
                .HasForeignKey(vr => vr.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
