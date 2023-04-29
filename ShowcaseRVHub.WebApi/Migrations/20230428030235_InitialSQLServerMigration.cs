using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShowcaseRVHub.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialSQLServerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShowcaseUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(25)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(25)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(13)", nullable: true),
                    Username = table.Column<string>(type: "varchar(25)", nullable: false),
                    Password = table.Column<string>(type: "varchar(15)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemembered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowcaseUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleRVs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "varchar(50)", nullable: false),
                    Model = table.Column<string>(type: "varchar(50)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Chassis = table.Column<string>(type: "varchar(25)", nullable: false),
                    Class = table.Column<byte>(type: "tinyint", nullable: false),
                    Sleeps = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "varchar(250)", nullable: false),
                    Description = table.Column<string>(type: "varchar(250)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Odometer = table.Column<double>(type: "float", nullable: false),
                    GeneratorHours = table.Column<int>(type: "int", nullable: false),
                    FuelLevel = table.Column<byte>(type: "tinyint", nullable: false),
                    MasterBedType = table.Column<int>(type: "int", nullable: false),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false),
                    HasSlideout = table.Column<bool>(type: "bit", nullable: false),
                    HasGenerator = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleRVs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleRVs_ShowcaseUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ShowcaseUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.DropTable(
                name: "ShowcaseUsers");
        }
    }
}
