FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApplicationInsights/ApplicationInsights.WorkerService.Subscriber/ApplicationInsights.WorkerService.Subscriber.csproj", "ApplicationInsights/ApplicationInsights.WorkerService.Subscriber/ApplicationInsights.WorkerService.Subscriber.csproj"]
COPY ["ApplicationInsights/ApplicationInsights.Utils/ApplicationInsights.Utils.csproj", "ApplicationInsights/ApplicationInsights.Utils/ApplicationInsights.Utils.csproj"]
RUN dotnet restore "ApplicationInsights/ApplicationInsights.WorkerService.Subscriber/ApplicationInsights.WorkerService.Subscriber.csproj"
COPY . .
WORKDIR "/src/ApplicationInsights/ApplicationInsights.WorkerService.Subscriber"
RUN dotnet build "ApplicationInsights.WorkerService.Subscriber.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApplicationInsights.WorkerService.Subscriber.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApplicationInsights.WorkerService.Subscriber.dll"]
