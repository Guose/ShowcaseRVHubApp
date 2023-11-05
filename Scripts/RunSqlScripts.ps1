# Define the container id
$containerId = $env:CONTAINER_ID

# Define the paths to your .sql scripts
$scriptPaths = @(
  "01_create-db.sql",
  "02_create-tables.sql",
  "03_seed-data.sql"
)

# Loop through the scripts files and execute them in the Docker container
foreach ($scriptPath in $scriptPaths) {
  # Build the docker exec command for creating the database (using a Here-String)
  $dockerExecCommand = "docker exec -i $containerId /opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U sa -P 5p3ctrum! -d master -Q" + `
  " 'IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N''ShowcaseRVHubDB'') CREATE DATABASE [ShowcaseRVHubDB]'"

  # Execute the script to create the database
  Write-Host "Executing script to create the database...  $scriptPath"
  Invoke-Expression $dockerExecCommand

  # Check the exit code of the previous command
  $exitCode = $LASTEXITCODE
  if ($exitCode -eq 0) {
    Write-Host "Database creation script executed successfully."
  } else {
    Write-Host "Database creation script failed with exit code $exitCode."
  }

  # Build the docker exec command to execute the main script
  $dockerExecCommand = "docker exec -i $containerId /opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U sa -P 5p3ctrum! -d ShowcaseRVHubDB -i /docker-entrypoint-initdb.d/$scriptPath"  
  
  # Execute the scripts
  Write-Host "Executing $scriptPath in the container..."
  Invoke-Expression $dockerExecCommand

  # Check the exit code of the previous command
  $exitCode = $LASTEXITCODE
  if ($exitCode -eq 0) {
    Write-Host "Script $scriptPath executed successfully."
  } else {
    Write-Host "Script $scriptPath failed with exit code $exitCode."
  }
}