# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore
# Copy everything else and build
COPY ./ ./
RUN dotnet publish -c Release -o out
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"
COPY ./entrypoint.sh /app
EXPOSE 80
RUN chmod +x ./entrypoint.sh
ENTRYPOINT /bin/bash ./entrypoint.sh



# Build runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:5.0
# WORKDIR /app
# COPY --from=build-env /app/out .
# EXPOSE 80
# ENTRYPOINT ["dotnet","PlanthorWebApiServer.dll", "--server.urls", "https://+:5000"]

