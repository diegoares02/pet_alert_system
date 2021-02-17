#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["pet_system_alarm_web/pet_system_alarm_web.csproj", "pet_system_alarm_web/"]
RUN dotnet restore "pet_system_alarm_web/pet_system_alarm_web.csproj"
COPY . .
WORKDIR "/src/pet_system_alarm_web"
RUN dotnet build "pet_system_alarm_web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "pet_system_alarm_web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "pet_system_alarm_web.dll"]