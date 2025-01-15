# Step 1: Build the application
# Use the official .NET 8 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Copy the .csproj file and restore any dependencies (via NuGet)
COPY EmployeeManagementAPI.csproj ./
RUN dotnet restore

# Copy the rest of the application source code
COPY . ./

# Publish the application in Release mode
RUN dotnet publish -c Release -o out

# Step 2: Create the final image using the .NET runtime image
# Use the official .NET 8 runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Set the working directory for the runtime image
WORKDIR /app

# Expose the port that the app will run on (default for ASP.NET Core is 80)
EXPOSE 80

# Copy the published files from the build stage
COPY --from=build /app/out .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "EmployeeManagementAPI.dll"]
