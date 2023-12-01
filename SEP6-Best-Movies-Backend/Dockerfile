
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base


RUN apt-get update \
    && apt-get install -y libicu-dev \
    && rm -rf /var/lib/apt/lists/*

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=0

USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

Build image with .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SEP6-Best-Movies-Backend/SEP6-Best-Movies-Backend.csproj", "SEP6-Best-Movies-Backend/"]
RUN dotnet restore "./SEP6-Best-Movies-Backend/./SEP6-Best-Movies-Backend.csproj"
COPY . .
WORKDIR "/src/SEP6-Best-Movies-Backend"
RUN dotnet build "./SEP6-Best-Movies-Backend.csproj" -c $BUILD_CONFIGURATION -o /app/build


FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SEP6-Best-Movies-Backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SEP6-Best-Movies-Backend.dll"]
