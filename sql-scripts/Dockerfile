# Stage 1: Build the custom SQL Server image
FROM mcr.microsoft.com/mssql/server:latest

# Set environment variables if needed
ENV SA_PASSWORD=5p3ctrum!
ENV ACCEPT_EULA=Y

# Install necessary packages and copy wait-for-it script
USER root

# COPY wait-for-it.sh /usr/src/app/wait-for-it.sh
# RUN chmod +x /usr/src/app/wait-for-it.sh

# Copy SQL scripts to the initialization directory
RUN mkdir -p /docker-entrypoint-initdb.d
# RUN chown -R mssql /docker-entrypoint-initdb.d
ADD *.sql /docker-entrypoint-initdb.d

# # Copy the custom initialization script
# ADD init-database-scripts.sh /usr/src/app/init-database-scripts.sh
# RUN chmod +x /usr/src/app/init-database-scripts.sh

# # Set the custom script as the entrypoint
# ENTRYPOINT ["/bin/bash", "/usr/src/app/init-database-scripts.sh"]
