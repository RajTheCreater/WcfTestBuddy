# Use the official .NET Core SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy the solution file and restore dependencies for all projects
COPY *.sln ./
COPY WebApplication1/. ./WebApplication1/
#COPY WebApplication1.csproj ./WebApplication1/
RUN dotnet restore
 
#
#COPY WebApplication1/. ./WebApplication1/

# Build and publish the API project
RUN dotnet publish WebApplication1.csproj -c Release -o out

# Use the official .NET Core runtime image for the final stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/out .

# Expose the port the app runs on
 
# Set the entry point for the container
ENTRYPOINT ["dotnet", "WebApplication1.dll"]