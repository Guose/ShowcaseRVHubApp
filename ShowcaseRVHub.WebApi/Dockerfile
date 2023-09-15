# Use the official .NET 7 SDK image as a build environment
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY ["./ShowcaseRVHub.WebApi.csproj", "./"]
RUN dotnet restore "./ShowcaseRVHub.WebApi.csproj"

# Copy the entire project directory
COPY . .

# Build the project
RUN dotnet build "ShowcaseRVHub.WebApi.csproj" -c Release -o /app/build

# Create a runtime image for the WebAPI project
FROM build AS publish
RUN dotnet publish "ShowcaseRVHub.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use the official .NET 7 SDK image as the final base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app

# Copy the published output from the build stage
COPY --from=publish /app/publish .

# Set environment variables
ENV ASPNETCORE_URLS http://*:5000

# Set the entry point for the runtime image
ENTRYPOINT ["dotnet", "ShowcaseRVHub.WebApi.dll"]
