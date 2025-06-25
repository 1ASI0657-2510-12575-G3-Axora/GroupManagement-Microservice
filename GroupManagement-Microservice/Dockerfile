FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GroupManagement-Microservice/GroupManagement-Microservice.csproj", "GroupManagement-Microservice/"]
RUN dotnet restore "GroupManagement-Microservice/GroupManagement-Microservice.csproj"
COPY . .
WORKDIR "/src/GroupManagement-Microservice"
RUN dotnet build "GroupManagement-Microservice.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "GroupManagement-Microservice.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GroupManagement-Microservice.dll"]
