-- Check if the database exists, create it if not
	IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'ShowcaseRVHubDB1')
	BEGIN

		-- Wait for SQL Server to be ready (adjust the delay as needed)
		WAITFOR DELAY '00:00:01'; -- Wait for 30 seconds

		CREATE DATABASE ShowcaseRVHubDB1;
	END;
	GO