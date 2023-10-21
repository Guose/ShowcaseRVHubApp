# Define the path to your Docker Compose YAML file
$dockerComposeFile = "C:\Users\Guose\source\repos\GitHubRepos\ShowcaseRVHubApp\docker-compose.yml"

# Build the Docker images defined in the YAML file
docker-compose -f $dockerComposeFile build

# Start the Docker containers in the background
docker-compose -f $dockerComposeFile up -d

# Continue with the rest of your script
Write-Host "Continuing with the script after waiting for 5 seconds."

# Wait for 5 seconds
Start-Sleep -Seconds 5

# Update sql-server
# Add Database
docker exec -it showcaservhubapp-sql-server-1 /opt/mssql-tools/bin/sqlcmd -S sql-server -U sa -P 5p3ctrum! -i /docker-entrypoint-initdb.d/create-db.sql

# Check to make sure DB was created
docker exec -it showcaservhubapp-sql-server-1 /opt/mssql-tools/bin/sqlcmd -S sql-server -U sa -P 5p3ctrum! -Q 'SELECT name FROM sys.databases;'

# Execute the SQL command and capture the output
$result = Invoke-Expression $sqlCommand

# Check if any results were returned
if ($null -ne $result -and $result -ne "") {
    Write-Host "ShowcaseRVHubDB Database created"
    Write-Host $result  # Output the results if you want
    # Continue with the next part of your script
} else {
    Write-Host "SQL query did not create DB. Running docker-compose down and exiting the script."
    # Exit the script since it's not successful
    docker-compose down
    Exit
}

# Wait for 3 seconds
Start-Sleep -Seconds 3

# Add tables to database
docker exec -it showcaservhubapp-sql-server-1 /opt/mssql-tools/bin/sqlcmd -S sql-server -U sa -P 5p3ctrum! -i /docker-entrypoint-initdb.d/create-tables.sql

# Check to make sure DB was created
docker exec -it showcaservhubapp-sql-server-1 /opt/mssql-tools/bin/sqlcmd -S sql-server -U sa -P 5p3ctrum! -Q "SELECT table_name FROM [ShowcaseRVHubDB].INFORMATION_SCHEMA.TABLES WHERE table_type = 'BASE TABLE';"

# Execute the SQL command and capture the output
$result = Invoke-Expression $sqlCommand

# Check if any results were returned
if ($null -ne $result -and $result -ne "") {
    Write-Host "Tables for ShowcaseRVHubDB created"
    Write-Host $result  # Output the results if you want
    # Continue with the next part of your script
} else {
    Write-Host "SQL query did not create tables. Running docker-compose down and exiting the script."
    # Exit the script since it's not successful
    docker-compose down
    Exit
}

# Wait for 3 seconds
Start-Sleep -Seconds 3

# Add seed data to tables
docker exec -it showcaservhubapp-sql-server-1 /opt/mssql-tools/bin/sqlcmd -S sql-server -U sa -P 5p3ctrum! -i /docker-entrypoint-initdb.d/seed-data.sql

# Check to make sure DB was created
docker exec -it showcaservhubapp-sql-server-1 /opt/mssql-tools/bin/sqlcmd -S sql-server -U sa -P 5p3ctrum! -Q "SELECT * FROM ShowcaseRVHubDB.dbo.ShowcaseUsers;"

# Execute the SQL command and capture the output
$result = Invoke-Expression $sqlCommand

# Check if any results were returned
if ($null -ne $result -and $result -ne "") {
    Write-Host "Seed data script has been ran..."
    Write-Host $result  # Output the results if you want
    # Continue with the next part of your script
} else {
    Write-Host "SQL query did not seed the data. Running docker-compose down and exiting the script."
    # Exit the script since it's not successful
    docker-compose down
    Exit
}