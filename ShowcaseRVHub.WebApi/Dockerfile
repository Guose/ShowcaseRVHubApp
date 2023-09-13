# Use the official .NET 7 SDK image as a build environment
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Set the working directory in the container for the WebAPI project
WORKDIR /app

# Copy the project file and restore dependencies for the WebAPI project
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source code for the WebAPI project
COPY . ./



# Build the application for the WebAPI project
RUN dotnet publish -c Release -o out

# Create a runtime image for the WebAPI project
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build-env /app/out .

# Copy the SQLite database file into the container (in the build stage)
COPY ["ShowcaseRVHub_2.db", "."]

# Set the entry point for the runtime image
ENTRYPOINT ["dotnet", "ShowcaseRVHub.WebApi.dll"]
