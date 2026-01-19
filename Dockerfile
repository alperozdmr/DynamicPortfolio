# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Portfolio.UI/Portfolio.UI.csproj", "Portfolio.UI/"]
COPY ["Portfolio.DataAccess/Portfolio.DataAccess.csproj", "Portfolio.DataAccess/"]
COPY ["Portfolio.Entity/Portfolio.Entity.csproj", "Portfolio.Entity/"]
COPY ["Portfolio.Helper/Portfolio.Helper.csproj", "Portfolio.Helper/"]
COPY ["Portfolio.Service/Portfolio.Service.csproj", "Portfolio.Service/"]
RUN dotnet restore "./Portfolio.UI/Portfolio.UI.csproj"
COPY . .
WORKDIR "/src/Portfolio.UI"
RUN dotnet build "./Portfolio.UI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Portfolio.UI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Portfolio.UI.dll"]