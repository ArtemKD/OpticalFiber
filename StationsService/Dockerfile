FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["StationsService/StationsService.csproj", "StationsService/"]
RUN dotnet restore "StationsService/StationsService.csproj"
COPY . .
WORKDIR "/src/StationsService"
RUN dotnet build "StationsService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StationsService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StationsService.dll"]