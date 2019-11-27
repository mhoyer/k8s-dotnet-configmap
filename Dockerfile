FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine
    WORKDIR /app
    COPY *.csproj ./
    RUN dotnet restore

    COPY *.cs ./
    CMD dotnet run