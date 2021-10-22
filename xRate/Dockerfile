FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["xRate/xRate.csproj", "xRate/"]
RUN dotnet restore "xRate/xRate.csproj"
COPY . .
WORKDIR "/src/xRate"
RUN dotnet build "xRate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "xRate.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "xRate.dll"]
