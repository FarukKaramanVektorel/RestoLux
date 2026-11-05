
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY RestoLux.Domain/RestoLux.Domain.csproj RestoLux.Domain/
COPY RestoLux.Application/RestoLux.Application.csproj RestoLux.Application/
COPY RestoLux.Infrastructure/RestoLux.Infrastructure.csproj RestoLux.Infrastructure/
COPY RestoLux.Web/RestoLux.Web.csproj RestoLux.Web/

RUN dotnet restore RestoLux.Web/RestoLux.Web.csproj

COPY . .

RUN dotnet publish RestoLux.Web/RestoLux.Web.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

RUN mkdir -p /data /app/logs /app/wwwroot/uploads \
    && chown -R app:app /data /app

COPY --from=build --chown=app:app /app/publish .

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:10000
ENV ConnectionStrings__DefaultConnection="Data Source=/data/restolux.db"

EXPOSE 10000

USER app

ENTRYPOINT ["dotnet", "RestoLux.Web.dll"]
