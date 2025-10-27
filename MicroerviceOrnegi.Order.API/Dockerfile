# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MicroerviceOrnegi.Order.API/MicroerviceOrnegi.Order.API.csproj", "MicroerviceOrnegi.Order.API/"]
COPY ["MicroerviceOrnegi.Order.Application/MicroerviceOrnegi.Order.Application.csproj", "MicroerviceOrnegi.Order.Application/"]
COPY ["MicroerviceOrnegi.Bus/MicroerviceOrnegi.Bus.csproj", "MicroerviceOrnegi.Bus/"]
COPY ["MicroerviceOrnegi.Order.Domain/MicroerviceOrnegi.Order.Domain.csproj", "MicroerviceOrnegi.Order.Domain/"]
COPY ["MicroerviceOrnegi.Shared/MicroerviceOrnegi.Shared.csproj", "MicroerviceOrnegi.Shared/"]
COPY ["MicroerviceOrnegi.Order.Persistence/MicroerviceOrnegi.Order.Persistence.csproj", "MicroerviceOrnegi.Order.Persistence/"]
RUN dotnet restore "./MicroerviceOrnegi.Order.API/MicroerviceOrnegi.Order.API.csproj"
COPY . .
WORKDIR "/src/MicroerviceOrnegi.Order.API"
RUN dotnet build "./MicroerviceOrnegi.Order.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MicroerviceOrnegi.Order.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroerviceOrnegi.Order.API.dll"]