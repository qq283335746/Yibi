# Yibi's MySQL Database Provider

This project contains Yibi's MySQL database provider.

## Migrations

Add a migration with:

```
//dotnet ef migrations add MigrationName --context MySqlContext --output-dir Migrations --startup-project ..\Web\Web.csproj

dotnet ef migrations add DingtalkMigrations --context MySqlContext --output-dir DingtalkMigrations --startup-project ..\Web\Web.csproj

dotnet ef database update --context MySqlContext
```

(MySQL Connector/Net)[https://www.connectionstrings.com/mysql/]

Standard

```
Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;
```

运行Web项目后即可看到数据表。