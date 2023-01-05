FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5137

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MicroserviceExample/WebApi.Sender/WebApi.Sender.csproj", "MicroserviceExample/WebApi.Sender/WebApi.Sender.csproj"]
COPY ["MicroserviceExample/Utils/Utils.csproj", "MicroserviceExample/Utils/Utils.csproj"]
RUN dotnet restore "MicroserviceExample/WebApi.Sender/WebApi.Sender.csproj"
RUN dotnet restore "MicroserviceExample/Utils/Utils.csproj"
COPY . .
WORKDIR "/src/MicroserviceExample/WebApi.Sender"
RUN dotnet build "WebApi.Sender.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.Sender.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.Sender.dll"]
