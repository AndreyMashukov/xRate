FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . /src
RUN cd /src
RUN dotnet restore --interactive
RUN dotnet build --configuration Release

FROM build AS publish
RUN dotnet publish --configuration Release --output /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "xRate.dll"]
