CREATE TABLE ShowcaseRVHubChecklist.dbo.ShowcaseUsers (
	Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	Email NVARCHAR(MAX) NOT NULL,
	FirstName NVARCHAR(MAX) NOT NULL,
	LastName NVARCHAR(MAX) NOT NULL,
	Phone NVARCHAR(14) NULL,
	Username NVARCHAR(50) NOT NULL,
	Password NVARCHAR(50) NOT NULL,
	CreatedOn DATETIME2(7) NOT NULL,
	ModifiedOn DATETIME2(7) NULL,
	IsRemembered BIT NOT NULL DEFAULT 0,
);

INSERT INTO ShowcaseRVHubChecklist.dbo.ShowcaseUsers (Id, Email, FirstName, LastName, Phone, Username, Password, CreatedOn, ModifiedOn, IsRemembered)
VALUES 
('cf3e94b7-4052-4585-86e8-b4ea68ba1bdf', 'justin@showcasemi.com', 'Justin', 'Elder', NULL, 'justy', 'pass', '2023-08-14', NULL, 1),
('add00d60-8544-4fcc-9494-b4993b05472b', 'cuggle1008@gmail.com', 'Kathleen', 'Lordan', '(425) 802-2164', 'cuggle', 'myPass', '2023-10-08', NULL, 0);

CREATE TABLE ShowcaseRVHubChecklist.dbo.VehicleRVs (
	Id int NOT NULL,
	Make NVARCHAR(50) NOT NULL,
	Model NVARCHAR(50) NOT NULL,
	Year int NULL,
	Chassis NVARCHAR(25) NULL,
	Class TINYINT NOT NULL,
	Sleeps TINYINT NOT NULL,
	Length SMALLINT NULL,
	Height DECIMAL NULL,
	Image NVARCHAR(MAX) NULL,
	Description NVARCHAR(MAX) NULL,
	CreatedOn DATETIME2 NOT NULL DEFAULT GETDATE(),
	ModifiedOn DATETIME2 NULL,
	Odometer DECIMAL NOT NULL,
	GeneratorHours SMALLINT NOT NULL,
	MasterBedType TINYINT NOT NULL,
	IsBooked BIT NOT NULL DEFAULT 0,
	HasSlideOut BIT NULL,
	HasGenerator BIT NULL,
	UserId UNIQUEIDENTIFIER NOT NULL,
	PRIMARY KEY (Id),
	CONSTRAINT FK_UserVehicle FOREIGN KEY (UserId) REFERENCES ShowcaseRVHubChecklist.dbo.ShowcaseUsers(Id)
);

INSERT INTO ShowcaseRVHubChecklist.dbo.VehicleRVs (Id, Make, Model, Year, Chassis, Class, Sleeps, Length, Height, Image, Description, CreatedOn, ModifiedOn, Odometer, GeneratorHours, MasterBedType, IsBooked, HasGenerator, HasSlideOut, UserId)
VALUES 
(-1, 'Winnebago', 'Minnie Winnie 22R', 2015, 'Ford', 3, 6, 23, 13.2, 'C:/Users/Guose/source/repos/GitHubRepos/ShowcaseRVHubApp/ShowcaseRVHub.MAUI/Resources/Images/minniewinnie.jpg', NULL, '2032-09-12', NULL, 79362.0, 72, 3, 1, 1, 0, 'cf3e94b7-4052-4585-86e8-b4ea68ba1bdf'),
(-2, 'Forest River', 'Sunseeker', 2019, 'Ford', 3, 6, 27, 12.6, 'C:/Users/Guose/source/repos/GitHubRepos/ShowcaseRVHubApp/ShowcaseRVHub.MAUI/Resources/Images/sunseeker.jpg', NULL, '2023-08-14', NULL, 68912.0, 48, 2, 0, 1, 1, 'cf3e94b7-4052-4585-86e8-b4ea68ba1bdf');

CREATE TABLE ShowcaseRVHubChecklist.dbo.Renters (
	Id INT NOT NULL PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	Phone NVARCHAR(14) NOT NULL,
	CreatedOn DATE NOT NULL,
	ModifiedOn DATE NULL
);

INSERT INTO ShowcaseRVHubChecklist.dbo.Renters (Id, FirstName, LastName, Email, Phone, CreatedOn, ModifiedOn)
VALUES
(-1, 'John', 'Doe', 'johndoe@gmail.com', '(425) 760-5962', '2023-07-13', NULL),
(-2, 'Jane', 'Doe', 'janedoe@gmail.com', '(425) 293-9006', '2023-07-11', NULL);

CREATE TABLE ShowcaseRVHubChecklist.dbo.Rentals (
	Id INT NOT NULL PRIMARY KEY,
	IsExterior BIT NOT NULL DEFAULT 0,
	IsFluidChecked BIT NOT NULL DEFAULT 0,
	IsInteriorCleaned BIT NOT NULL DEFAULT 0,
	IsMaintenance BIT NOT NULL DEFAULT 0,
	IsRenterTrained BIT NOT NULL DEFAULT 0,
	IsSignalsChecked BIT NOT NULL DEFAULT 0,
	IsSystemsChecked BIT NOT NULL DEFAULT 0,
	IsTireInspected BIT NOT NULL DEFAULT 0,
	CreatedOn DATE NOT NULL,
	ModifiedOn DATE NULL,
	RentalEnd DATE NOT NULL,
	RentalStart DATE NOT NULL,
	FuelLevel SMALLINT NOT NULL,
	Propane SMALLINT NOT NULL,
	BlackWater SMALLINT NOT NULL,
	GrayWater SMALLINT NOT NULL,
	RenterId INT FOREIGN KEY REFERENCES ShowcaseRVHubChecklist.dbo.Renters(Id),
	UserId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ShowcaseRVHubChecklist.dbo.ShowcaseUsers(Id),
	VehicleId INT FOREIGN KEY REFERENCES ShowcaseRVHubChecklist.dbo.VehicleRVs(Id)
);

INSERT INTO ShowcaseRVHubChecklist.dbo.Rentals (Id, IsExterior, IsFluidChecked, IsInteriorCleaned, IsMaintenance, IsRenterTrained, IsSignalsChecked, IsSystemsChecked, IsTireInspected, CreatedOn, ModifiedOn, RentalEnd, RentalStart, FuelLevel, Propane, BlackWater, GrayWater, RenterId, UserId, VehicleId)
VALUES
(-1, 1, 1, 1, 1, 1, 1, 1, 1, '2023-08-28', NULL, '2023-09-15', '2023-09-10', 5, 4, 1, 1, -2, 'ADD00D60-8544-4FCC-9494-B4993B05472B', -2),
(-2, 1, 1, 1, 1, 1, 1, 1, 1, '2023-09-05', NULL, '2023-09-25', '2023-09-20', 4, 5, 2, 1, -1, 'CF3E94B7-4052-4585-86E8-B4EA68BA1BDF', -2);