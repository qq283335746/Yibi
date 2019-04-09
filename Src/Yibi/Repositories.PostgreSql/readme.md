# Yibi's PostgreSql Database Provider

This project contains Yibi's PostgreSql database provider.

## Migrations

Add a migration with:

```
dotnet ef migrations add MigrationName --context PostgreSqlContext --output-dir Migrations --startup-project ..\Web\Web.csproj

dotnet ef database update --context PostgreSqlContext
```

PostgreSql:
https://www.digitalocean.com/community/tutorials/how-to-install-and-use-postgresql-on-ubuntu-18-04
