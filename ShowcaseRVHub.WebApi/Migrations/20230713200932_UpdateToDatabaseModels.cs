using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShowcaseRVHub.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToDatabaseModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleRVs_ShowcaseUsers_UserId",
                table: "VehicleRVs");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "VehicleRVs",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleRVs_ShowcaseUsers_UserId",
                table: "VehicleRVs",
                column: "UserId",
                principalTable: "ShowcaseUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleRVs_ShowcaseUsers_UserId",
                table: "VehicleRVs");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "VehicleRVs",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleRVs_ShowcaseUsers_UserId",
                table: "VehicleRVs",
                column: "UserId",
                principalTable: "ShowcaseUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
