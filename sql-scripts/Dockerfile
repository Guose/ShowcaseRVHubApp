# Stage 1: Build the custom SQL Server image
FROM mcr.microsoft.com/mssql/server:latest as build

# Set environment variables if needed
ENV SA_PASSWORD=5p3ctrum!
ENV ACCEPT_EULA=Y

# Copy SQL scripts to the initialization directory
COPY . /docker-entrypoint-initdb.d

# Stage 2: Final image for SQL Server
FROM mcr.microsoft.com/mssql/server:latest

# Copy the initialized data from the builder stage
COPY --from=builder /var/opt/mssql /var/opt/mssql

EXPOSE 1433