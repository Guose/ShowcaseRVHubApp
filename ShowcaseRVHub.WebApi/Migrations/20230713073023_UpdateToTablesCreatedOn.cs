using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShowcaseRVHub.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToTablesCreatedOn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "VehicleRVs",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Renters",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Renters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Rentals",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Rentals",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Renters");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Renters");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Rentals");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "VehicleRVs",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RenterId",
                table: "VehicleRVs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRVs_RenterId",
                table: "VehicleRVs",
                column: "RenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleRVs_Renters_RenterId",
                table: "VehicleRVs",
                column: "RenterId",
                principalTable: "Renters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
