ARG SDK_VERSION=7.0
FROM mcr.microsoft.com/dotnet/sdk:${SDK_VERSION} AS build
ARG PUBLISH_CONFIGURATION=Release
ARG PUBLISH_FRAMEWORK=net7.0
WORKDIR /app
COPY . ./
RUN dotnet publish ./MicroserviceExample/WorkerService -c "${PUBLISH_CONFIGURATION}" -o /out -p:IntegrationBuild=true

FROM mcr.microsoft.com/dotnet/aspnet:${SDK_VERSION} AS runtime
WORKDIR /app
COPY --from=build /out ./
ENTRYPOINT ["dotnet", "WorkerService.dll"]
