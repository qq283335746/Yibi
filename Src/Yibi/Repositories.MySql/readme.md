# Yibi's MySQL Database Provider

This project contains Yibi's MySQL database provider.

## Migrations

Add a migration with:

```
dotnet ef migrations add MigrationName --context MySqlContext --output-dir Migrations --startup-project ..\Repositories.Web\Repositories.Web.csproj

dotnet ef database update --context MySqlContext
```
