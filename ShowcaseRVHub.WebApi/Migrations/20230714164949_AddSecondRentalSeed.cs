using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShowcaseRVHub.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSecondRentalSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 14, 9, 49, 48, 942, DateTimeKind.Local).AddTicks(2998));

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "CreatedOn", "IsExteriorCleaned", "IsFluidChecked", "IsInteriorCleaned", "IsMaintenance", "IsRenterTrained", "IsSignalsChecked", "IsSystemsChecked", "IsTireInspected", "ModifiedOn", "RenterId", "UserId", "VehicleId" },
                values: new object[] { -2, new DateTime(2023, 7, 14, 9, 49, 48, 942, DateTimeKind.Local).AddTicks(3058), true, true, true, true, true, true, true, true, null, -2, new Guid("add00d60-8544-4fcc-9494-b4993b05472b"), -1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 13, 14, 8, 33, 138, DateTimeKind.Local).AddTicks(4661));
        }
    }
}
