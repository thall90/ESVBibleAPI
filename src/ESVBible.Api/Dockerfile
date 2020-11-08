#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-5.0.0-rc.2-alpine3.12-amd64 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/aspnet:5.0-5.0.0-rc.2-alpine3.12-amd64 AS build
WORKDIR /src
COPY ["src/ESVBible.Api/ESVBible.Api.csproj", "src/ESVBible.Api/"]
COPY ["src/ESVBible.Read.Query.Handler/ESVBible.Read.Query.Handler.csproj", "src/ESVBible.Read.Query.Handler/"]
COPY ["src/ESVBible.Shared.Infrastructure/ESVBible.Shared.Infrastructure.csproj", "src/ESVBible.Shared.Infrastructure/"]
COPY ["src/ESVBible.Shared.Enum/ESVBible.Shared.Enum.csproj", "src/ESVBible.Shared.Enum/"]
COPY ["src/ESVBible.Read.Query.Mapping/ESVBible.Read.Query.Mapping.csproj", "src/ESVBible.Read.Query.Mapping/"]
COPY ["src/ESVBible.Read.Query/ESVBible.Read.Query.csproj", "src/ESVBible.Read.Query/"]
COPY ["src/ESVBible.Read.Query.Transport/ESVBible.Read.Query.Transport.csproj", "src/ESVBible.Read.Query.Transport/"]
COPY ["src/ESVBible.Shared/ESVBible.Shared.csproj", "src/ESVBible.Shared/"]
COPY ["src/ESVBible.Data/ESVBible.Data.csproj", "src/ESVBible.Data/"]
RUN dotnet restore "src/ESVBible.Api/ESVBible.Api.csproj"
COPY . .
WORKDIR "/src/src/ESVBible.Api"
RUN dotnet build "ESVBible.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ESVBible.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ESVBible.Api.dll"]