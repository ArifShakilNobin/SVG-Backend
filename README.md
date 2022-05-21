# SVG-Backend


## CLI Based Execution

Entity Framework Core is the new data access technology baked into .net core. It is cross platform and supports multiple relational databases. It supports both targeted upgrading and downgrading. Migrations can be executed from the PMC or via the dotnet CLI. The dotnet CLI makes it highly scriptable and CI friendly.

## About

- Maintained By: [Microsoft](https://github.com/aspnet/EntityFramework/graphs/contributors) & a huge number of OSS contributors
- [NuGet](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/)
- [Source](https://github.com/aspnet/EntityFramework)
- [Documentation](https://docs.microsoft.com/en-us/ef/)


### Installation

```powershell
dotnet add .\src\Example.CLI\Example.CLI.csproj package Microsoft.EntityFrameworkCore
```

This is just a base class library, to interact with a database you must also install a package specific to that database.

#### Npgsql

```powershell
dotnet add package Npgsql --version 6.0.4
```

#### Svg.Repository
```powershell
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 6.0.5
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.5
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 6.0.4
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL.Design --version 1.1.0
```

#### Svg.WebApp
```powershell
dotnet add package Microsoft.EntityFrameworkCore --version 6.0.5
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.5
```

#### Migration (Svg.Repository)
CLI Based Execution

All Entity Framework migration commands must be excuted from inside Visual Studio's Package Manager Console or the CLI. CLI integration easy for CI systems to interact with the migrations to deploy them to an environment or generate data change scripts at build time.

#### Creating and Destroying Migrations
```powershell
dotnet ef migrations add MeaningfullName
```
Will look at the current state of our model and generate migration for any changes from the previous migration.
```powershell
dotnet ef migrations remove MeaningfullName
```

#### Applying Migrations to Database
Will connect to the database and apply any migrations that have not already been applied.

```powershell
dotnet ef database update
```




