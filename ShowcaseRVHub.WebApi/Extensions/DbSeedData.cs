using ShowcaseRVHub.WebApi.Models;
using ShowcaseRVHub.WebApi.Models.EnumTypes;

namespace ShowcaseRVHub.WebApi.Extensions
{
    public class DbSeedData
    {
        private static readonly Guid _userId = new("CF3E94B7-4052-4585-86E8-B4EA68BA1BDF");
        public static List<VehicleRv> GetRvSeedData()
        {
            List<VehicleRv> rvs = new()
            {
                new VehicleRv
                {
                    Id = -1,
                    Make = "Forest River",
                    Chassis = "Ford",
                    Year = 2019,
                    Model = "Sunseeker",
                    Class = RVClassType.C,
                    Sleeps = 6,
                    Length = 27,
                    Height = 12.6,
                    Image = "C:/Users/Guose/source/repos/GitHubRepos/ShowcaseRVHubApp/ShowcaseRVHub.MAUI/Resources/Images/sunseeker.jpg",
                    Description = "Excellent for family vacations with all the extras included to make your trip enjoyable, feasible, and easy to use. " +
                    "Features include: RV has solar panels, thermal windows, and Artic Pack for winter travels, one slide out to increase living space, " +
                    "private master bedroom with memory foam queen bed & wardrobe area/cabinet, full queen bed above driver's seat, dinette converts to bed, " +
                    "full bathroom and shower, stove/oven combo, microwave, refrigerator/freezer, 2 AC units, motorized awning for easy access, and plenty " +
                    "of undercarriage storage area. Clean bedding, pots, pans, plates, bowls, coffee maker, cups, and kitchen utensils are included in rental. " +
                    "Other add-ons are available for rental: inflatable rafting tube, kayaks, paddle boards, sledding tubes, etc. 24/7 support with certified " +
                    "techs available to address the unexpected. We do offer delivery and pickup services and flexible with pickup & return times. " +
                    "Secure onsite parking of your vehicle is available on request. Towing of any trailer, boat, or vehicle is prohibited. " +
                    "Reservation dates confirmed once payment is made. If you have questions, please let us know.",
                    IsBooked = false,
                    HasSlideout = true,
                    HasGenerator = true,
                    GeneratorHours = 48,
                    Odometer = 68912,
                    MasterBedType = BedType.Queen,
                    UserId = _userId
                },
                new VehicleRv
                {
                    Id = -2,
                    Make = "Winnebago",
                    Chassis = "Ford",
                    Year = 2015,
                    Model = "Minnie Winnie 22R",
                    Class = RVClassType.C,
                    Sleeps = 6,
                    Length = 23,
                    Height = 13.2,
                    Image = "C:/Users/Guose/source/repos/GitHubRepos/ShowcaseRVHubApp/ShowcaseRVHub.MAUI/Resources/Images/minniewinnie.jpg",
                    Description = "Great for family vacations with all the extras included to make your trip enjoyable, " +
                    "feasible, and easy to use. Features include: RV has master bedroom with queen bed & wardrobe cabinet, " +
                    "queen bed over the cab, dinette converts to bed, full bathroom & shower, stove/oven combo, microwave, " +
                    "refrigerator/freezer, AC unit, electric awning, & plenty of storage. Clean bedding, pots, pans, plates, " +
                    "bowls, coffee maker, cups, & kitchen utensils included in rental. Other add-ons are available for " +
                    "rental: inflatable rafting tube, kayaks, paddle boards, sledding tubes, etc. 24/7 support with certified " +
                    "techs available to address the unexpected. We do offer delivery and pickup services and flexible with " +
                    "pickup & return times. Secure onsite parking of your vehicle is available on request. " +
                    "Towing of any trailer, boat, or vehicle is prohibited. Reservation dates confirmed once payment is made. " +
                    "If you have questions, please let us know.",
                    IsBooked = true,
                    HasSlideout = false,
                    HasGenerator = true,
                    GeneratorHours = 72,
                    Odometer = 79362,
                    MasterBedType = BedType.Full,
                    UserId = _userId
                }
            };

            return rvs;
        }

        public static List<Rental> GetRentalSeedData()
        {
            List<Rental> rentals = new()
            {
                new Rental
                {
                    Id = -1,
                    IsExteriorCleaned = true,
                    IsFluidChecked = true,
                    IsInteriorCleaned = true,
                    IsMaintenance = true,
                    IsRenterTrained = true,
                    IsSignalsChecked = true,
                    IsSystemsChecked = true,
                    IsTireInspected = true,
                    UserId = _userId,
                    RenterId = -1,
                    VehicleId = -2,
                }
            };

            return rentals;
        }

        public static List<ShowcaseUser> GetUserSeedData()
        {
            List<ShowcaseUser> users = new()
            {
                new ShowcaseUser
                {
                    Id = _userId,
                    FirstName = "Justin",
                    LastName = "Elder",
                    Username = "Guose",
                    Password = "pass",
                    Email = "justin@showcasemi.com",
                }
            };

            return users;
        }

        public static List<ShowcaseRenter> GetRenterSeedData()
        {
            List<ShowcaseRenter> renters = new()
            {
                new ShowcaseRenter
                {
                    Id = -1,
                    Firstname = "John",
                    Lastname = "Doe",
                    Email = "john@gmail.com",
                    Phone = "4257605962",
                },
                new ShowcaseRenter
                {
                    Id = -2,
                    Firstname = "Jane",
                    Lastname = "Doe",
                    Email = "jane@gmail.com",
                    Phone = "4252939006",
                }
            };

            return renters;
        }
    }
}
