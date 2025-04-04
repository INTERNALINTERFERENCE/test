FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RestService.WebApi/RestService.WebApi.csproj", "RestService.WebApi/"]
RUN dotnet restore "RestService.WebApi/RestService.WebApi.csproj"
COPY . .
WORKDIR "/src/RestService.WebApi"
RUN dotnet build "RestService.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "RestService.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RestService.WebApi.dll"]
