CREATE TABLE Renters (
	Id INT NOT NULL PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	Phone NVARCHAR(14) NOT NULL,
	CreatedOn DATE NOT NULL,
	ModifiedOn DATE NULL
);

INSERT INTO Renters (Id, FirstName, LastName, Email, Phone, CreatedOn, ModifiedOn)
VALUES
(-1, 'John', 'Doe', 'johndoe@gmail.com', '(425) 760-5962', '2023-07-13', NULL),
(-2, 'Jane', 'Doe', 'janedoe@gmail.com', '(425) 293-9006', '2023-07-11', NULL);