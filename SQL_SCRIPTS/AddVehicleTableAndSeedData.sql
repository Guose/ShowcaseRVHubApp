CREATE TABLE VehicleRVs (
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
	CONSTRAINT FK_UserVehicle FOREIGN KEY (UserId) REFERENCES ShowcaseUsers(Id)
);

INSERT INTO VehicleRVs (Id, Make, Model, Year, Chassis, Class, Sleeps, Length, Height, Image, Description, CreatedOn, ModifiedOn, Odometer, GeneratorHours, MasterBedType, IsBooked, HasGenerator, HasSlideOut, UserId)
VALUES 
(-1, 'Winnebago', 'Minnie Winnie 22R', 2015, 'Ford', 3, 6, 23, 13.2, 'C:/Users/Guose/source/repos/GitHubRepos/ShowcaseRVHubApp/ShowcaseRVHub.MAUI/Resources/Images/minniewinnie.jpg', NULL, '2032-09-12', NULL, 79362.0, 72, 3, 1, 1, 0, 'cf3e94b7-4052-4585-86e8-b4ea68ba1bdf'),
(-2, 'Forest River', 'Sunseeker', 2019, 'Ford', 3, 6, 27, 12.6, 'C:/Users/Guose/source/repos/GitHubRepos/ShowcaseRVHubApp/ShowcaseRVHub.MAUI/Resources/Images/sunseeker.jpg', NULL, '2023-08-14', NULL, 68912.0, 48, 2, 0, 1, 1, 'cf3e94b7-4052-4585-86e8-b4ea68ba1bdf');