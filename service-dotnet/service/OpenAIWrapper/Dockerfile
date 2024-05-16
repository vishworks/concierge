# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

# Copy only the necessary project files and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the entire project and build
COPY . ./
RUN dotnet publish -c Release -o out

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final

WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/out .

# Expose the port
EXPOSE 80

# Set the entry point for the application
ENTRYPOINT ["dotnet", "OpenAIWrapper.dll"]

