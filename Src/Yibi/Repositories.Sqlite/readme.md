# Yibi's SQLite Database Provider

This project contains Yibi's SQLite database provider.

## Migrations

Add a migration with:

```
dotnet ef migrations add MigrationName001 --context SqliteContext --output-dir Migrations --startup-project ..\Web\Web.csproj

dotnet ef migrations remove --context SqliteContext --startup-project ..\Web\Web.csproj

dotnet ef database update --context SqliteContext --startup-project ..\Web\Web.csproj
```
