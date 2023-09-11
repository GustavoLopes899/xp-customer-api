FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY *.sln .
COPY ./src/Application/. ./src/Application/
COPY ./tests/Application.Test/. ./tests/Application.Test/
RUN dotnet restore

RUN dotnet publish -c release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Xp.Api.Application.dll"]