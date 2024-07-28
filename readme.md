# EsPlaytime

A play project to get ef & eventuous playing nicely together. Especially with migrations & bundle

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

### Entity frameworks bundle

Th important thing here is you need a separate project for your `DbContext` or bad stuff happens.
There's error `NETSDK1152: Found multiple publish output files with the same relative path`. and all
sorts. Not cool :(

Quite a lot of messing about with migration operations as well.
Note, will need changing for Eventuous 0.15 (breaking change in `Schema.cs`)

``` bash
dotnet ef migrations bundle --project ./src/EsPlaytime.Migrations/
```
