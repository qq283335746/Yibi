# Yibi's PostgreSql Database Provider

This project contains Yibi's PostgreSql database provider.

## Migrations

Add a migration with:

```
dotnet ef migrations add MigrationName --context PostgreSqlContext --output-dir Migrations --startup-project ..\Web\Web.csproj

dotnet ef database update --context PostgreSqlContext
```

"Database": {
    "Type": "PostgreSql",
    "ConnectionString": "host=192.168.21.131;port=5432;Database=YibiDb;Username=postgres;Password=yibi123456"
}

PostgreSql:
https://www.digitalocean.com/community/tutorials/how-to-install-and-use-postgresql-on-ubuntu-18-04
