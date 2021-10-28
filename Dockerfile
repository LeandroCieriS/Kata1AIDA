# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY . .
RUN dotnet restore

# build app
RUN dotnet build StringCalculator.Api/StringCalculator.Api.csproj -c Release --no-restore
RUN dotnet publish StringCalculator.Api/StringCalculator.Api.csproj -c Release --no-restore --no-build -o out

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "StringCalculator.Api.dll"]