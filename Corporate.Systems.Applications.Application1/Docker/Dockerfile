#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Corporate.Systems.Applications.Application1/Corporate.Systems.Applications.Application1.csproj", "Corporate.Systems.Applications.Application1/"]
COPY ["Corporate.Systems.Applications.Common/Corporate.Systems.Applications.Common.csproj", "Corporate.Systems.Applications.Common/"]
RUN dotnet restore "Corporate.Systems.Applications.Application1/Corporate.Systems.Applications.Application1.csproj"
COPY . .
WORKDIR "/src/Corporate.Systems.Applications.Application1"
RUN dotnet build "Corporate.Systems.Applications.Application1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Corporate.Systems.Applications.Application1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Corporate.Systems.Applications.Application1.dll"]