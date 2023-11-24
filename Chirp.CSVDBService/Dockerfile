FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Chirp.CSVDBService/Chirp.CSVDBService.csproj", "Chirp.CSVDBService/"]
RUN dotnet restore "Chirp.CSVDBService/Chirp.CSVDBService.csproj"
COPY . .
WORKDIR "/src/Chirp.CSVDBService"
RUN dotnet build "Chirp.CSVDBService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Chirp.CSVDBService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Chirp.CSVDBService.dll"]
