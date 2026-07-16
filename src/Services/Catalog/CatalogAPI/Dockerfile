# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
# KS - Docker internally expose 8080 and 8081 ports for .Net applications by default. These are internal port numbers ie Docker inside.
# KS - we also need Docker External port numbers as well that maps to internal port numbers to call our code and application requests and
	# KS  - that is done using docker compose files to expose external ports for docker containers.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Catalog/CatalogAPI/CatalogAPI.csproj", "Services/Catalog/CatalogAPI/"]
RUN dotnet restore "./Services/Catalog/CatalogAPI/CatalogAPI.csproj"
COPY . .
WORKDIR "/src/Services/Catalog/CatalogAPI"
RUN dotnet build "./CatalogAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CatalogAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CatalogAPI.dll"]