FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# Copy csproj and restore nuget packages
COPY "DemoWebApplication.csproj" "DemoWebApplication/"
RUN dotnet restore "DemoWebApplication/DemoWebApplication.csproj"

# Copy everything else and publish (publish includes build)
# NOTE: "everything else" respects the `.dockerignore` file
COPY . "DemoWebApplication"
WORKDIR "/src/DemoWebApplication"
RUN dotnet publish "DemoWebApplication.csproj" -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DemoWebApplication.dll"]
