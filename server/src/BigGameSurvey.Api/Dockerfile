FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
COPY BigGameSurvey.Api.csproj .
RUN dotnet restore
COPY . .
RUN dotnet build --no-restore -c Release -o dist

FROM build AS publish
RUN dotnet publish -c Release -o dist

FROM base AS final
WORKDIR /dist
COPY --from=publish /app/dist .
#ENTRYPOINT ["dotnet", "BigGameSurvey.Api.dll"]
# Opção utilizada pelo Heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet BigGameSurvey.Api.dll
