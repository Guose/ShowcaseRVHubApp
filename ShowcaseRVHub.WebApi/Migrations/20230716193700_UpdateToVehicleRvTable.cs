using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShowcaseRVHub.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToVehicleRvTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.AddColumn<int>(
                name: "RenterId",
                table: "VehicleRVs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRVs_RenterId",
                table: "VehicleRVs",
                column: "RenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleRVs_Renters_RenterId",
                table: "VehicleRVs",
                column: "RenterId",
                principalTable: "Renters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleRVs_Renters_RenterId",
                table: "VehicleRVs");

            migrationBuilder.DropIndex(
                name: "IX_VehicleRVs_RenterId",
                table: "VehicleRVs");

            migrationBuilder.DropColumn(
                name: "RenterId",
                table: "VehicleRVs");

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "CreatedOn", "IsExteriorCleaned", "IsFluidChecked", "IsInteriorCleaned", "IsMaintenance", "IsRenterTrained", "IsSignalsChecked", "IsSystemsChecked", "IsTireInspected", "ModifiedOn", "RenterId", "UserId", "VehicleId" },
                values: new object[,]
                {
                    { -2, new DateTime(2023, 7, 14, 9, 49, 48, 942, DateTimeKind.Local).AddTicks(3058), true, true, true, true, true, true, true, true, null, -2, new Guid("add00d60-8544-4fcc-9494-b4993b05472b"), -2 },
                    { -1, new DateTime(2023, 7, 14, 9, 49, 48, 942, DateTimeKind.Local).AddTicks(2998), true, true, true, true, true, true, true, true, null, -1, new Guid("cf3e94b7-4052-4585-86e8-b4ea68ba1bdf"), -2 }
                });
        }
    }
}
