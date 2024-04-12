#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# To build outside of Visual Studio, run the following command: docker build -t koldste/koldste.dev:dev -f .\Koldste.dev.Web\Dockerfile .
# To run the container, run the following command from the solution directory: docker run -ti -p 8800:8800 koldste/koldste.dev:dev

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
# https://devblogs.microsoft.com/dotnet/running-nonroot-kubernetes-with-dotnet/
USER $APP_UID
WORKDIR /app
EXPOSE 8800

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Koldste.dev.Web/Koldste.dev.Web.csproj", "Koldste.dev.Web/"]
RUN dotnet restore "./Koldste.dev.Web/Koldste.dev.Web.csproj"
COPY . .
WORKDIR "/src/Koldste.dev.Web"
RUN dotnet build "./Koldste.dev.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Koldste.dev.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_HTTP_PORTS=8800

# Container hardening
# https://techcommunity.microsoft.com/t5/microsoft-developer-community/hardening-an-asp-net-container-running-on-kubernetes/ba-p/2542224
ENV COMPlus_EnableDiagnostics=0

ENTRYPOINT ["dotnet", "Koldste.dev.Web.dll"]