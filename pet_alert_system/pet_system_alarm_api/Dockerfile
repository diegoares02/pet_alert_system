#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
#EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["pet_system_alarm_api.csproj", "pet_system_alarm_api/"]
RUN dotnet restore "pet_system_alarm_api/pet_system_alarm_api.csproj"

COPY . .
WORKDIR "/src/pet_system_alarm_api"
RUN dotnet build "pet_system_alarm_api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "pet_system_alarm_api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "pet_system_alarm_api.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet pet_system_alarm_api.dll