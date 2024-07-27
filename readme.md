## Getting the stuff setup

### dev containers

need `git config --global --add safe.directory /workspace` to make **git** happy

### dotnet tooling

``` bash
dotnet new tool-manifest
```

### Entity frameworks migrations

``` bash
dotnet tool install dotnet-ef
cd src/EsPlaytime/
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
# add class EsDbContext
cd src/EsPlaytime.Migrations/
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add reference ../EsPlaytime
# add class MigrationsDbContextFactory
dotnet ef migrations add InitialCreate
```