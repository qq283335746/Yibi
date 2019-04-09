# Yibi's SQL Server Database Provider

This project contains Yibi's Microsoft SQL Server database provider.

## Migrations

Add a migration with:

```
dotnet ef migrations add MigrationName --context SqlServerContext --output-dir Migrations --startup-project ..\Web\Web.csproj

dotnet ef database update --context SqlServerContext
```
