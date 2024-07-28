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

``` bash
dotnet ef migrations bundle
# or
dotnet ef migrations bundle --self-contained -r linux-x64
```

and just see error `NETSDK1152: Found multiple publish output files with the same relative path`. Not cool :(

There is a lot of weirdness here. It's not as slick as you might hope, if you don't want your application
to know about migrations.

```bash
# update src/EsPlaytime.Migrations/EsPlaytime.Migrations.csproj with BaseOutputPath
dotnet build ./src/EsPlaytime.Migrations/ --configuration Bundle
dotnet ef migrations bundle --configuration Bundle --verbose --startup-project ./src/EsPlaytime
```

This appears to work, but I wonder if I can flip it around so that the `BaseOutputPath` is in `MyWebApi.csproj`.
Then the bundle could just reference `EsPlaytime.Migrations`?

