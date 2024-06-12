FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ExpandingUnits.ExternalApi/ExpandingUnits.ExternalApi.csproj", "ExpandingUnits.ExternalApi/"]
RUN dotnet restore "ExpandingUnits.ExternalApi/ExpandingUnits.ExternalApi.csproj"
COPY . .
WORKDIR "/src/ExpandingUnits.ExternalApi"
RUN dotnet build "ExpandingUnits.ExternalApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ExpandingUnits.ExternalApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExpandingUnits.ExternalApi.dll"]
