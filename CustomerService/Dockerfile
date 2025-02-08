# Stage 1: Build the CustomerService application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . ./
RUN dotnet publish -c Release -o out

# Stage 2: Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

#ENV ASPNETCORE_URLS=http://+:80  # Ensure app listens on port 80

EXPOSE 8080
ENTRYPOINT ["dotnet", "CustomerService.dll"]