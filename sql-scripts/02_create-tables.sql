-- Create ErrorLog table if it doesn't exist
IF NOT EXISTS (
	SELECT 1
	FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'ErrorLog'
)
BEGIN
CREATE TABLE ErrorLog (
    ErrorID INT IDENTITY(1,1) PRIMARY KEY,
    ErrorNumber INT,
    ErrorMessage NVARCHAR(4000),
    ErrorTime DATETIME
);
END;


BEGIN TRY
	
	-- Switch to the target database
	USE ShowcaseRVHubDB

	-- Start a transaction
	BEGIN TRAN;

	IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = 'ShowcaseRVHubDB.dbo.ShowcaseUsers'
	)
	BEGIN
	CREATE TABLE dbo.ShowcaseUsers (
		Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
		Email NVARCHAR(50) NOT NULL,
		FirstName NVARCHAR(25) NOT NULL,
		LastName NVARCHAR(25) NOT NULL,
		Phone NVARCHAR(14) NULL,
		Username NVARCHAR(25) NOT NULL,
		Password NVARCHAR(25) NOT NULL,
		CreatedOn DATE NOT NULL,
		ModifiedOn DATE NULL,
		IsRemembered BIT NOT NULL DEFAULT 0,
	);
	END;

	IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = 'ShowcaseRVHubDB.dbo.VehicleRVs'
	)
	BEGIN
	CREATE TABLE dbo.VehicleRVs (
		Id int NOT NULL,
		Make NVARCHAR(25) NOT NULL,
		Model NVARCHAR(25) NOT NULL,
		Year int NULL,
		Chassis NVARCHAR(25) NULL,
		Class TINYINT NOT NULL,
		Sleeps INT NOT NULL,
		Length INT NULL,
		Height FLOAT NULL,
		Image NVARCHAR(MAX) NULL,
		Description NVARCHAR(MAX) NULL,
		CreatedOn DATE NOT NULL,
		ModifiedOn DATE NULL,
		Odometer FLOAT NOT NULL,
		GeneratorHours INT NOT NULL,
		MasterBedType TINYINT NOT NULL,
		IsBooked BIT NOT NULL DEFAULT 0,
		HasSlideOut BIT NOT NULL,
		HasGenerator BIT NOT NULL,
		UserId UNIQUEIDENTIFIER NOT NULL,
		PRIMARY KEY (Id),
		CONSTRAINT FK_UserVehicle FOREIGN KEY (UserId) REFERENCES dbo.ShowcaseUsers(Id)
	);
	END;

	IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = 'ShowcaseRVHubDB.dbo.Renters'
	)
	BEGIN
	CREATE TABLE dbo.Renters (
		Id INT NOT NULL PRIMARY KEY,
		FirstName NVARCHAR(50) NOT NULL,
		LastName NVARCHAR(50) NOT NULL,
		Email NVARCHAR(50) NOT NULL,
		Phone NVARCHAR(14) NOT NULL,
		CreatedOn DATE NOT NULL,
		ModifiedOn DATE NULL
	);
	END;

	IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = 'ShowcaseRVHubDB.dbo.VehicleRvRenters'
	)
	BEGIN
	CREATE TABLE dbo.VehicleRvRenters (
		RenterId INT NOT NULL,
		VehicleId INT NOT NULL,
		PRIMARY KEY (RenterId, VehicleId),
		FOREIGN KEY (RenterId) REFERENCES Renters(Id),
		FOREIGN KEY (VehicleId) REFERENCES VehicleRVs(Id)
	);
	END;

	IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = 'ShowcaseRVHubDB.dbo.Arrivals'
	)
	BEGIN
	CREATE TABLE dbo.Arrivals (
		Id INT NOT NULL,
		IsExteriorCleaned BIT NOT NULL DEFAULT 0,
		IsFluidChecked BIT NOT NULL DEFAULT 0,
		IsInteriorCleaned BIT NOT NULL DEFAULT 0,
		IsCheckInComplete BIT NOT NULL DEFAULT 0,
		CreatedOn DATE NOT NULL,
		ModifiedOn DATE NULL,
		FuelLevel TINYINT NOT NULL,
		Propane TINYINT NOT NULL,
		BlackWater TINYINT NOT NULL,
		GrayWater TINYINT NOT NULL,
		UserId UNIQUEIDENTIFIER NOT NULL,
		RentalId INT NOT NULL,
		PRIMARY KEY (Id),
		CONSTRAINT FK_UserArrival FOREIGN KEY (UserId) REFERENCES dbo.ShowcaseUsers(Id)
	);
	END;

	IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = 'ShowcaseRVHubDB.dbo.Departures'
	)
	BEGIN
	CREATE TABLE dbo.Departures (
		Id INT NOT NULL,
		IsExteriorCleaned BIT NOT NULL DEFAULT 0,
		IsFluidChecked BIT NOT NULL DEFAULT 0,
		IsInteriorCleaned BIT NOT NULL DEFAULT 0,
		IsRenterTrained BIT NOT NULL DEFAULT 0,
		CreatedOn DATE NOT NULL,
		ModifiedOn DATE NULL,
		FuelLevel TINYINT NOT NULL,
		Propane TINYINT NOT NULL,
		BlackWater TINYINT NOT NULL,
		GrayWater TINYINT NOT NULL,
		UserId UNIQUEIDENTIFIER NOT NULL,
		RentalId INT NOT NULL,
		PRIMARY KEY (Id),
		CONSTRAINT FK_UserDeparture FOREIGN KEY (UserId) REFERENCES dbo.ShowcaseUsers(Id),
	);
	END;

	IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = 'ShowcaseRVHubDB.dbo.Maintenances'
	)
	BEGIN
	CREATE TABLE dbo.Maintenances (
		Id INT NOT NULL,
		IsMaintenance BIT NOT NULL DEFAULT 0,
		IsSignalsChecked BIT NOT NULL DEFAULT 0,
		IsSystemsChecked BIT NOT NULL DEFAULT 0,
		IsTireInspected BIT NOT NULL DEFAULT 0,
		CreatedOn DATE NOT NULL,
		ModifiedOn DATE NULL,
		MaintenanceEnd DATE NOT NULL,
		MaintenanceStart DATE NOT NULL,
		UserId UNIQUEIDENTIFIER NOT NULL,
		VehicleId INT NOT NULL,
		PRIMARY KEY (Id),
		CONSTRAINT FK_UserMaintenance FOREIGN KEY (UserId) REFERENCES dbo.ShowcaseUsers(Id),
		CONSTRAINT FK_VehicleMaintenance FOREIGN KEY (VehicleId) REFERENCES dbo.VehicleRVs(Id),
	);
	END;


	IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = 'ShowcaseRVHubDB.dbo.Rentals'
	)
	BEGIN
	CREATE TABLE dbo.Rentals (
		Id INT NOT NULL,
		CreatedOn DATE NOT NULL,
		ModifiedOn DATE NULL,
		RentalEnd DATE NOT NULL,
		RentalStart DATE NOT NULL,
		ArrivalId INT NULL,
		DepartureId INT NULL,
		RenterId INT NOT NULL,
		UserId UNIQUEIDENTIFIER NOT NULL,
		VehicleId INT NOT NULL,
		PRIMARY KEY (Id),
		CONSTRAINT FK_ArrivalRental FOREIGN KEY (ArrivalId) REFERENCES dbo.Arrivals(Id),
		CONSTRAINT FK_DepartureRental FOREIGN KEY (DepartureId) REFERENCES dbo.Departures(Id),
		CONSTRAINT FK_RenterRental FOREIGN KEY (RenterId) REFERENCES dbo.Renters(Id),
		CONSTRAINT FK_VehicleRental FOREIGN KEY (VehicleId) REFERENCES dbo.VehicleRVs(Id)
	);
	END;	

	COMMIT;
END TRY
BEGIN CATCH

	-- Roll back the transaction if an error occurs
    ROLLBACK;

	-- Get the error message
    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();

    -- Get the error number
    DECLARE @ErrorNumber INT = ERROR_NUMBER();

	-- Log the error and insert details into the error log table
	INSERT INTO master.dbo.ErrorLog (ErrorNumber, ErrorMessage, ErrorTime)
    VALUES (@ErrorNumber, @ErrorMessage, GETDATE());

END CATCH;