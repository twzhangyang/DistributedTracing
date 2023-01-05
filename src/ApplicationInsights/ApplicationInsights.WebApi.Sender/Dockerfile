FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 6137

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApplicationInsights/WebApi.Sender/WebApi.Sender.csproj", "ApplicationInsights/WebApi.Sender/WebApi.Sender.csproj"]
COPY ["ApplicationInsights/Utils/Utils.csproj", "ApplicationInsights/Utils/Utils.csproj"]
RUN dotnet restore "ApplicationInsights/WebApi.Sender/WebApi.Sender.csproj"
RUN dotnet restore "ApplicationInsights/Utils/Utils.csproj"
COPY . .
WORKDIR "/src/ApplicationInsights/WebApi.Sender"
RUN dotnet build "WebApi.Sender.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.Sender.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.Sender.dll"]
