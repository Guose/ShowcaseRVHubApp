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
COPY --from=build-env /app/out .

# Specify the entry point for the WebAPI project
ENTRYPOINT ["dotnet", "ShowcaseRVHub.Email.dll"]