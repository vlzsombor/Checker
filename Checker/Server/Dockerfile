#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Checker/Server/Checker.Server.csproj", "Checker/Server/"]
COPY ["Checker/Client/Checker.Client.csproj", "Checker/Client/"]
COPY ["Checker/Shared/Checker.Shared.csproj", "Checker/Shared/"]
RUN dotnet restore "Checker/Server/Checker.Server.csproj"
COPY . .
WORKDIR "/src/Checker/Server"
RUN dotnet build "Checker.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Checker.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Checker.Server.dll"]
