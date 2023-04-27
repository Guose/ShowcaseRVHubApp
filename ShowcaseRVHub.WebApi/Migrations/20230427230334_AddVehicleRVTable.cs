using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShowcaseRVHub.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleRVTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleRVs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Make = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<string>(type: "TEXT", nullable: false),
                    Chassis = table.Column<string>(type: "TEXT", nullable: false),
                    Class = table.Column<byte>(type: "INTEGER", nullable: false),
                    Sleeps = table.Column<int>(type: "INTEGER", nullable: false),
                    Length = table.Column<int>(type: "INTEGER", nullable: false),
                    Height = table.Column<double>(type: "REAL", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Odometer = table.Column<double>(type: "REAL", nullable: false),
                    GeneratorHours = table.Column<int>(type: "INTEGER", nullable: false),
                    FuelLevel = table.Column<byte>(type: "INTEGER", nullable: false),
                    MasterBedType = table.Column<int>(type: "INTEGER", nullable: false),
                    IsBooked = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasSlideout = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasGenerator = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleRVs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleRVs_ShowcaseUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ShowcaseUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRVs_UserId",
                table: "VehicleRVs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleRVs");
        }
    }
}
