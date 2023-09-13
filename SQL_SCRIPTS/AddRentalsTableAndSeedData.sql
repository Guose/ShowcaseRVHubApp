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