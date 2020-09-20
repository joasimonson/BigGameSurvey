#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
RUN mkdir /app
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
#WORKDIR /app
#COPY BigGameSurvey.Api.csproj .
#RUN dotnet restore
#COPY . .
#RUN dotnet build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet build --no-restore -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "BigGameSurvey.Api.dll"]
# Opção utilizada pelo Heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet BigGameSurvey.Api.dll