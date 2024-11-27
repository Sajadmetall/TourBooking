# Stage 1: Build and Publish the Application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /src

# Copy the csproj files and restore dependencies
COPY ["TourBooking/TourBooking.csproj", "TourBooking/"]
COPY ["TourBooking.Application/TourBooking.Application.csproj", "TourBooking.Application/"]
COPY ["TourBooking.Infrastructure/TourBooking.Infrastructure.csproj", "TourBooking.Infrastructure/"]
COPY ["TourBooking.Domain/TourBooking.Domain.csproj", "TourBooking.Domain/"]
RUN dotnet restore "./TourBooking/TourBooking.csproj"

# Copy all project files and build the application
COPY . .
WORKDIR "/src/TourBooking"
RUN dotnet publish "./TourBooking.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Create the Runtime Image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Set working directory in the runtime container
WORKDIR /app

# Expose the necessary ports (8080 for HTTP, 8081 for HTTPS)
EXPOSE 8080
EXPOSE 8081

# Copy the published files from the build stage
COPY --from=build /app/publish .
#
#RUN ls -la /app/publish
#
# Set environment variables for Azure authentication
ENV AZURE_CLIENT_ID="d8319494-9692-47d6-a7fb-3c23ebf26ece"
ENV AZURE_TENANT_ID="7c49e7f3-6eea-4329-9411-c56a19dcbb35"
ENV AZURE_CLIENT_SECRET="vFe8Q~GIZjJW5ECIfYXgUCLnYVK8jGedLYAf8bIe"

# Set additional environment variables
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV ASPNETCORE_ENVIRONMENT=Development

# Run the application
ENTRYPOINT ["dotnet", "TourBooking.dll"]
