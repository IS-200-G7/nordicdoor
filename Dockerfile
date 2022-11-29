FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY [".", "."]
RUN ls /src
WORKDIR "/src/PDSA_System/Server/"
RUN ls "/src/PDSA_System/Server/"
RUN dotnet build -c Release

FROM build AS publish
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish  --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PDSA_System.Server.dll"]
