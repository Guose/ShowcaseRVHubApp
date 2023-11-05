#!/bin/bash

# Wait for SQL Server to start (you can adjust the sleep time as needed)
# sleep 30

# Use wait-for-it to wait for SQL Server to be available
/usr/src/app/wait-for-it.sh localhost:1433 -t 30

# Set SQL Server environment variables
export SA_PASSWORD=5p3ctrum!
export ACCEPT_EULA=Y

# Execute SQL scripts
/opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U sa -P $SA_PASSWORD -d master -i /docker-entrypoint-initdb.d/01_create-db.sql
/opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U sa -P $SA_PASSWORD -i /docker-entrypoint-initdb.d/02_create-tables.sql
/opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U sa -P $SA_PASSWORD -i /docker-entrypoint-initdb.d/03_seed-data.sql

# Run SQL Server in the background
/opt/mssql/bin/sqlservr
