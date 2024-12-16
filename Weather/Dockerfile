FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

EXPOSE 80
ENV ASPNETCORE_URLS http://+:80
ENV ASPNETCORE_ENVIRONMENT Development

WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["Weather/Weather.csproj", "Weather/"]

RUN dotnet restore "Weather/Weather.csproj"

COPY . . 
FROM build AS publish
RUN dotnet publish "Weather/Weather.csproj" -c Rwlease -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Weather.dll"]