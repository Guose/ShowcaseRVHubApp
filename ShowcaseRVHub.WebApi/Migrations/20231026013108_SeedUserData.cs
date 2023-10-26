using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShowcaseRVHub.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ShowcaseUsers",
                columns: new[] { "Id", "CreatedOn", "Email", "FirstName", "IsRemembered", "LastName", "ModifiedOn", "Password", "Phone", "Username" },
                values: new object[] { new Guid("cf3e94b7-4052-4585-86e8-b4ea68ba1bdf"), new DateTime(2023, 10, 25, 18, 31, 7, 949, DateTimeKind.Local).AddTicks(5308), "justin@showcasemi.com", "Justin", true, "Elder", null, "pass", null, "Guose" });

            migrationBuilder.InsertData(
                table: "VehicleRVs",
                columns: new[] { "Id", "Chassis", "Class", "CreatedOn", "Description", "GeneratorHours", "HasGenerator", "HasSlideout", "Height", "Image", "IsBooked", "Length", "Make", "MasterBedType", "Model", "ModifiedOn", "Odometer", "Sleeps", "UserId", "Year" },
                values: new object[,]
                {
                    { -2, "Ford", (byte)3, new DateTime(2023, 7, 13, 13, 30, 4, 925, DateTimeKind.Local).AddTicks(4765), "Great for family vacations with all the extras included to make your trip enjoyable, feasible, and easy to use. Features include: RV has master bedroom with queen bed & wardrobe cabinet, queen bed over the cab, dinette converts to bed, full bathroom & shower, stove/oven combo, microwave, refrigerator/freezer, AC unit, electric awning, & plenty of storage. Clean bedding, pots, pans, plates, bowls, coffee maker, cups, & kitchen utensils included in rental. Other add-ons are available for rental: inflatable rafting tube, kayaks, paddle boards, sledding tubes, etc. 24/7 support with certified techs available to address the unexpected. We do offer delivery and pickup services and flexible with pickup & return times. Secure onsite parking of your vehicle is available on request. Towing of any trailer, boat, or vehicle is prohibited. Reservation dates confirmed once payment is made. If you have questions, please let us know.", 72, true, false, 13.2, "C:/Users/Guose/source/repos/GitHubRepos/ShowcaseRVHubApp/ShowcaseRVHub.MAUI/Resources/Images/minniewinnie.jpg", true, 23, "Winnebago", (byte)3, "Minnie Winnie 22R", null, 79362.0, 6, new Guid("cf3e94b7-4052-4585-86e8-b4ea68ba1bdf"), 2015 },
                    { -1, "Ford", (byte)3, new DateTime(2023, 7, 13, 13, 30, 4, 925, DateTimeKind.Local).AddTicks(4706), "Excellent for family vacations with all the extras included to make your trip enjoyable, feasible, and easy to use. Features include: RV has solar panels, thermal windows, and Artic Pack for winter travels, one slide out to increase living space, private master bedroom with memory foam queen bed & wardrobe area/cabinet, full queen bed above driver's seat, dinette converts to bed, full bathroom and shower, stove/oven combo, microwave, refrigerator/freezer, 2 AC units, motorized awning for easy access, and plenty of undercarriage storage area. Clean bedding, pots, pans, plates, bowls, coffee maker, cups, and kitchen utensils are included in rental. Other add-ons are available for rental: inflatable rafting tube, kayaks, paddle boards, sledding tubes, etc. 24/7 support with certified techs available to address the unexpected. We do offer delivery and pickup services and flexible with pickup & return times. Secure onsite parking of your vehicle is available on request. Towing of any trailer, boat, or vehicle is prohibited. Reservation dates confirmed once payment is made. If you have questions, please let us know.", 48, true, true, 12.6, "C:/Users/Guose/source/repos/GitHubRepos/ShowcaseRVHubApp/ShowcaseRVHub.MAUI/Resources/Images/sunseeker.jpg", false, 27, "Forest River", (byte)2, "Sunseeker", null, 68912.0, 6, new Guid("cf3e94b7-4052-4585-86e8-b4ea68ba1bdf"), 2019 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShowcaseUsers",
                keyColumn: "Id",
                keyValue: new Guid("cf3e94b7-4052-4585-86e8-b4ea68ba1bdf"));

            migrationBuilder.DeleteData(
                table: "VehicleRVs",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "VehicleRVs",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
