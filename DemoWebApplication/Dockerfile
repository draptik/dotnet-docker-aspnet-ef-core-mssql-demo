FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DemoWebApplication/DemoWebApplication.csproj", "DemoWebApplication/"]
RUN dotnet restore "DemoWebApplication/DemoWebApplication.csproj"
COPY . .
WORKDIR "/src/DemoWebApplication"
RUN dotnet build "DemoWebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DemoWebApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoWebApplication.dll"]
