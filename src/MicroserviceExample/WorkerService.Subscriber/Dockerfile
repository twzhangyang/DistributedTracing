FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MicroserviceExample/WorkerService.Subscriber/WorkerService.Subscriber.csproj", "MicroserviceExample/WorkerService.Subscriber/WorkerService.Subscriber.csproj"]
COPY ["MicroserviceExample/Utils/Utils.csproj", "MicroserviceExample/Utils/Utils.csproj"]
RUN dotnet restore "MicroserviceExample/WorkerService.Subscriber/WorkerService.Subscriber.csproj"
COPY . .
WORKDIR "/src/MicroserviceExample/WorkerService.Subscriber"
RUN dotnet build "WorkerService.Subscriber.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WorkerService.Subscriber.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkerService.Subscriber.dll"]
