FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 6137

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApplicationInsights/ApplicationInsights.WebApi.Sender/ApplicationInsights.WebApi.Sender.csproj", "ApplicationInsights/ApplicationInsights.WebApi.Sender/ApplicationInsights.WebApi.Sender.csproj"]
COPY ["ApplicationInsights/ApplicationInsights.Utils/ApplicationInsights.Utils.csproj", "ApplicationInsights/ApplicationInsights.Utils/ApplicationInsights.Utils.csproj"]
RUN dotnet restore "ApplicationInsights/ApplicationInsights.WebApi.Sender/ApplicationInsights.WebApi.Sender.csproj"
RUN dotnet restore "ApplicationInsights/ApplicationInsights.Utils/ApplicationInsights.Utils.csproj"
COPY . .
WORKDIR "/src/ApplicationInsights/ApplicationInsights.WebApi.Sender"
RUN dotnet build "ApplicationInsights.WebApi.Sender.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApplicationInsights.WebApi.Sender.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApplicationInsights.WebApi.Sender.dll"]
