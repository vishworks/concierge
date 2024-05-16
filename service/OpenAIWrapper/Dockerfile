# Use the official .NET SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy and restore dependencies
COPY . .
RUN dotnet restore

# Build the application
RUN dotnet publish -c Release -o out

# Use the official .NET runtime image as the final stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "OpenAIWrapper.dll"]

# Configure the port the application listens on
EXPOSE 80

