FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:3001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BackendBDI/BackendBDI.csproj", "BackendBDI/"]
RUN dotnet restore "BackendBDI/BackendBDI.csproj"
COPY . .
WORKDIR "/src/BackendBDI"
RUN dotnet build "BackendBDI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackendBDI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackendBDI.dll"]
