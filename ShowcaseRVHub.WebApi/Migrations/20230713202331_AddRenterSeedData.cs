using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShowcaseRVHub.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRenterSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Renters",
                columns: new[] { "Id", "CreatedOn", "Email", "Firstname", "Lastname", "ModifiedOn", "Phone" },
                values: new object[,]
                {
                    { -2, new DateTime(2023, 7, 13, 13, 23, 31, 477, DateTimeKind.Local).AddTicks(4213), "jane@gmail.com", "Jane", "Doe", null, "4252939006" },
                    { -1, new DateTime(2023, 7, 13, 13, 23, 31, 477, DateTimeKind.Local).AddTicks(4156), "john@gmail.com", "John", "Doe", null, "4257605962" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Renters",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Renters",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
