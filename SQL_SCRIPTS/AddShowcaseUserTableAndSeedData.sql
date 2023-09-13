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