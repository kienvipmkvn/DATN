FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["app/DATN.DTKIEN.GracefulStyleShop.API.csproj", "app/"]
RUN dotnet restore "app/DATN.DTKIEN.GracefulStyleShop.API.csproj"
COPY . .
WORKDIR "/src/app"
RUN dotnet build "DATN.DTKIEN.GracefulStyleShop.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DATN.DTKIEN.GracefulStyleShop.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DATN.DTKIEN.GracefulStyleShop.API.dll"]