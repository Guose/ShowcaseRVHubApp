-- Check if the database exists, create it if not
	IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'ShowcaseRVHubDB')
	BEGIN
		CREATE DATABASE ShowcaseRVHubDB;
	END;
	GO