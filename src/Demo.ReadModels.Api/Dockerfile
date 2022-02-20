#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["src/Demo.ReadModels.Api/Demo.ReadModels.Api.csproj", "src/Demo.ReadModels.Api/"]
COPY ["src/Demo.Extensions.NServiceBus/Demo.Extensions.NServiceBus.csproj", "src/Demo.Extensions.NServiceBus/"]
COPY ["src/Demo.Events/Demo.Events.csproj", "src/Demo.Events/"]
RUN dotnet restore "src/Demo.ReadModels.Api/Demo.ReadModels.Api.csproj"
COPY . .
WORKDIR "/src/src/Demo.ReadModels.Api"
RUN dotnet build "Demo.ReadModels.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Demo.ReadModels.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Demo.ReadModels.Api.dll"]