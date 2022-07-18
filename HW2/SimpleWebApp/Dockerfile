# Base Image for Build - dotnetcore SDK Image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000
ENV ASPNETCORE_ENVIRONMENT=Development

# Build the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SimpleWebApp/SimpleWebApp.csproj", "SimpleWebApp/"]
RUN dotnet restore "SimpleWebApp/SimpleWebApp.csproj"
COPY . .
WORKDIR "/src/SimpleWebApp"
RUN dotnet build "SimpleWebApp.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "SimpleWebApp.csproj" -c Release -o /app/publish

# Build runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleWebApp.dll"]