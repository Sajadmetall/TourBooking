# Base image for the runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Add SSL certificates to ensure secure connections
RUN apt-get update && apt-get install -y ca-certificates && rm -rf /var/lib/apt/lists/*

# Build image to compile the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files and restore dependencies
COPY ["TourBooking/TourBooking.csproj", "TourBooking/"]
COPY ["TourBooking.Application/TourBooking.Application.csproj", "TourBooking.Application/"]
COPY ["TourBooking.Infrastructure/TourBooking.Infrastructure.csproj", "TourBooking.Infrastructure/"]
COPY ["TourBooking.Domain/TourBooking.Domain.csproj", "TourBooking.Domain/"]
RUN dotnet restore "./TourBooking/TourBooking.csproj"

# Copy the rest of the code and build the application
COPY . .
WORKDIR "/src/TourBooking"
RUN dotnet build "./TourBooking.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application to a folder
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TourBooking.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image with the runtime environment and application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set up environment variables for Azure authentication
ENV AZURE_CLIENT_ID="d8319494-9692-47d6-a7fb-3c23ebf26ece"
ENV AZURE_TENANT_ID="7c49e7f3-6eea-4329-9411-c56a19dcbb35"
ENV AZURE_CLIENT_SECRET="vFe8Q~GIZjJW5ECIfYXgUCLnYVK8jGedLYAf8bIe"

# Set additional environment variables for logging and debugging
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV ASPNETCORE_ENVIRONMENT=Development

# Entrypoint to run the application
ENTRYPOINT ["dotnet", "TourBooking.dll"]
