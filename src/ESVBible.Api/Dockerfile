FROM mcr.microsoft.com/dotnet/runtime:5.0 AS nugetrestore

COPY ["ESVBible.sln", "./"]
COPY ["Directory.Build.props", "./"]
COPY ["tests/Directory.Build.props", "tests/"]
COPY ["support/.", "support/."]

COPY ["src/*/*.csproj", "./"]
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}; done

COPY ["tests/*/*.csproj", "./"]
RUN for file in $(ls *.csproj); do mkdir -p tests/${file%.*}/ && mv $file tests/${file%.*}; done

RUN dotnet restore -nowarn:msb3202,nu1503

FROM nugetrestore AS build

WORKDIR /

COPY ["src/.", "src/."]
COPY ["tests/.", "tests/."]
COPY ["ESVBible.sln", "tests/."]

RUN dotnet build -c Release --no-restore -v m EsvBible.sln

FROM build AS unit-test-runner
ENTRYPOINT [ "dotnet", "test", "--no-build", "-c", "Release", "/p:CollectCoverage=true", "/p:CoverletOutputFormat=lcov", "/p:CoverletOutput=../lcov"]

FROM build as publish
RUN dotnet publish -c Release -o /app --no-restore --no-build src/ESVBible.Api/ESVBible.Api.csproj

WORKDIR /app
EXPOSE 80

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ESVBible.Api.dll"]
