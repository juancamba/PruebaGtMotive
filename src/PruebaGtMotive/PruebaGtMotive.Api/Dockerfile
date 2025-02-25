FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# ENV ASPNETCORE_URLS=http://+:5000

# USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# ARG configuration=Release
WORKDIR /src
COPY ["src/PruebaGtMotive/PruebaGtMotive.Domain/PruebaGtMotive.Domain.csproj", "src/PruebaGtMotive/PruebaGtMotive.Domain/"]
COPY ["src/PruebaGtMotive/PruebaGtMotive.Infrastructure/PruebaGtMotive.Infrastructure.csproj", "src/PruebaGtMotive/PruebaGtMotive.Infrastructure/"]
COPY ["src/PruebaGtMotive/PruebaGtMotive.Application/PruebaGtMotive.Application.csproj", "src/PruebaGtMotive/PruebaGtMotive.Application/"]
COPY ["src/PruebaGtMotive/PruebaGtMotive.Api/PruebaGtMotive.Api.csproj", "src/PruebaGtMotive/PruebaGtMotive.Api/"]
RUN dotnet restore "src/PruebaGtMotive/PruebaGtMotive.Api/PruebaGtMotive.Api.csproj"
COPY . .
WORKDIR "/src/src/PruebaGtMotive/PruebaGtMotive.Api"
RUN dotnet build "PruebaGtMotive.Api.csproj" -c Debug -o /app/build

FROM build AS publish
#ARG configuration=Release
RUN dotnet publish "PruebaGtMotive.Api.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PruebaGtMotive.Api.dll"]