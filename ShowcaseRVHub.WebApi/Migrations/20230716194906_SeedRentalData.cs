using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShowcaseRVHub.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedRentalData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "CreatedOn", "IsExteriorCleaned", "IsFluidChecked", "IsInteriorCleaned", "IsMaintenance", "IsRenterTrained", "IsSignalsChecked", "IsSystemsChecked", "IsTireInspected", "ModifiedOn", "RenterId", "UserId", "VehicleId" },
                values: new object[,]
                {
                    { -2, new DateTime(2023, 7, 16, 12, 49, 6, 682, DateTimeKind.Local).AddTicks(8101), true, true, true, true, true, true, true, true, null, -2, new Guid("add00d60-8544-4fcc-9494-b4993b05472b"), -2 },
                    { -1, new DateTime(2023, 7, 16, 12, 49, 6, 682, DateTimeKind.Local).AddTicks(8026), true, true, true, true, true, true, true, true, null, -1, new Guid("cf3e94b7-4052-4585-86e8-b4ea68ba1bdf"), -2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
