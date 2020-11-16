#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["RecursosHumanos2/RecursosHumanos2.csproj", "RecursosHumanos2/"]
RUN dotnet restore "RecursosHumanos2/RecursosHumanos2.csproj"
COPY . .
WORKDIR "/src/RecursosHumanos2"
RUN dotnet build "RecursosHumanos2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecursosHumanos2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RecursosHumanos2.dll"]