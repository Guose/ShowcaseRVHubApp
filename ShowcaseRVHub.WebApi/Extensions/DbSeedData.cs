﻿using ShowcaseRVHub.WebApi.Models;
using ShowcaseRVHub.WebApi.Models.EnumTypes;

namespace ShowcaseRVHub.WebApi.Extensions
{
    public class DbSeedData
    {
        private static readonly Guid _userId = new("CF3E94B7-4052-4585-86E8-B4EA68BA1BDF");
        private static readonly Guid _userId2 = new("ADD00D60-8544-4FCC-9494-B4993B05472B");

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
                    UserId = _userId,
                    //User = new ShowcaseUser
                    //{
                    //    Id = _userId,
                    //    FirstName = "Justin",
                    //    LastName = "Elder",
                    //    Username = "Guose",
                    //    Password = "pass",
                    //    Email = "justin@showcasemi.com",
                    //    IsRemembered = true,
                    //}
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
                    UserId = _userId2,
                    //User = new ShowcaseUser
                    //{
                    //    Id = _userId,
                    //    FirstName = "Justin",
                    //    LastName = "Elder",
                    //    Username = "Guose",
                    //    Password = "pass",
                    //    Email = "justin@showcasemi.com",
                    //    IsRemembered = true,
                    //}
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
                    RentalStart = DateTime.Now.AddDays(2),
                    RentalEnd = DateTime.Now.AddDays(9),
                    ArrivalId = -1,
                    DepartureId = -1,
                    RenterId = -1,
                    VehicleId = -2,
                },
                new Rental
                {
                    Id = -2,
                    RentalStart = DateTime.Now.AddDays(20),
                    RentalEnd = DateTime.Now.AddDays(25),
                    ArrivalId = -2,
                    DepartureId = -2,
                    RenterId = -2,
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
                    IsRemembered = true,
                },
                new ShowcaseUser
                {
                    Id = _userId2,
                    FirstName = "Kathleen",
                    LastName = "Lordan",
                    Username = "cuggle",
                    Password = "password",
                    Email = "cuggle1008@gmail.com",
                    IsRemembered = false
                }
            };

            return users;
        }

        public static List<Arrival> GetArrivalSeedData()
        {
            List<Arrival> arrivals = new()
            {
                new Arrival
                {
                    Id = -1,
                    IsExteriorCleaned = true,
                    IsInteriorCleaned = true,
                    IsSignalsChecked = true,
                    IsCheckInComplete = true,
                    CreatedOn = DateTime.Now,
                    FuelLevel = LevelType.Full,
                    BlackWater = LevelType.Empty,
                    GrayWater = LevelType.Empty,
                    Propane = LevelType.Full,
                    UserId = _userId,
                    RentalId = -1
                }, 
                new Arrival
                {
                    Id = -2,
                    IsExteriorCleaned = true,
                    IsInteriorCleaned = true,
                    IsSignalsChecked = true,
                    IsCheckInComplete = true,
                    CreatedOn = DateTime.Now,
                    FuelLevel = LevelType.Half,
                    BlackWater = LevelType.ThreeQuarter,
                    GrayWater = LevelType.Full,
                    Propane = LevelType.Empty,
                    UserId = _userId2,
                    RentalId = -1
                }
            };

            return arrivals;
        }

        public static List<Departure> GetDepartureSeedData()
        {
            List<Departure> departures = new()
            {
                new Departure
                {
                    Id = -1,
                    IsExteriorCleaned = true,
                    IsInteriorCleaned = true,
                    IsSignalsChecked = true,
                    IsRenterTrained = true,
                    CreatedOn = DateTime.Now,
                    FuelLevel = LevelType.Full,
                    BlackWater = LevelType.Empty,
                    GrayWater = LevelType.Empty,
                    Propane = LevelType.Full,
                    UserId = _userId,
                    RentalId = -1
                }, 
                new Departure
                {
                    Id = -2,
                    IsExteriorCleaned = true,
                    IsInteriorCleaned = true,
                    IsSignalsChecked = true,
                    IsRenterTrained = true,
                    CreatedOn = DateTime.Now,
                    FuelLevel = LevelType.Half,
                    BlackWater = LevelType.ThreeQuarter,
                    GrayWater = LevelType.Full,
                    Propane = LevelType.Empty,
                    UserId = _userId,
                    RentalId = -1
                }
            };

            return departures;
        }

        public static List<RvMaintenance> GetMaintenanceSeedData()
        {
            List<RvMaintenance> rvMaintenances = new()
            {
                new RvMaintenance
                {
                    Id = -1,
                    IsTireInspected = true,
                    IsMaintenance = true,
                    IsFluidChecked = true,
                    IsSystemsChecked = true,
                    CreatedOn = DateTime.Now,
                    MaintenanceStart = DateTime.Now,
                    MaintenanceEnd = DateTime.Now.AddDays(4),
                    UserId = _userId,
                    VehicleId = -1
                },
                new RvMaintenance
                {
                    Id = -2,
                    IsTireInspected = true,
                    IsMaintenance = true,
                    IsFluidChecked = true,
                    IsSystemsChecked = true,
                    CreatedOn = DateTime.Now,
                    MaintenanceStart = DateTime.Now.AddDays(2),
                    MaintenanceEnd = DateTime.Now.AddDays(4),
                    UserId = _userId,
                    VehicleId = -2
                }
            };

            return rvMaintenances;
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
