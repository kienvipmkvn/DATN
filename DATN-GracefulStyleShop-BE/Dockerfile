FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
ARG MYSQL_SERVER
ENV MYSQL_SERVER ${MYSQL_SERVER}
ARG MYSQL_PORT
ENV MYSQL_PORT ${MYSQL_PORT}
ARG MYSQL_INITIAL_CATALOG
ENV MYSQL_INITIAL_CATALOG ${MYSQL_INITIAL_CATALOG}
ARG MYSQL_USERNAME
ENV MYSQL_USERNAME ${MYSQL_USERNAME}
ARG MYSQL_PASSWORD
ENV MYSQL_PASSWORD ${MYSQL_PASSWORD}
WORKDIR /app

COPY . .
RUN dotnet restore
RUN dotnet publish -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
WORKDIR /app
COPY --from=build /app/published-app /app
ENTRYPOINT [ "dotnet", "/app/DATN.DTKIEN.GracefulStyleShop.API.dll" ]