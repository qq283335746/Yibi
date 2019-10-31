# Yibi's MySQL Database Provider

This project contains Yibi's MySQL database provider.

## Migrations

Add a migration with:

```
//dotnet ef migrations add MigrationName --context MySqlContext --output-dir Migrations --startup-project ..\Web\Web.csproj

dotnet ef migrations add DingtalkMigrations --context MySqlContext --output-dir DingtalkMigrations --startup-project ..\Web\Web.csproj

dotnet ef migrations add DingtalkMigrations010 --context MySqlContext --output-dir DingtalkMigrations --startup-project ..\Web\Web.csproj

dotnet ef migrations add SGroupMigrations008 --context MySqlContext --output-dir SGroupMigrations --startup-project ..\Web\Web.csproj

dotnet ef migrations remove --context MySqlContext --startup-project ..\Web\Web.csproj

dotnet ef database update --context MySqlContext --startup-project ..\Web\Web.csproj
```

(MySQL Connector/Net)[https://www.connectionstrings.com/mysql/]

Standard

```
Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;
```

运行Web项目后即可看到数据表。

dotnet ef database update 20191010085603_SGroupMigrations008  --force --context MySqlContext --startup-project ..\Web\Web.csproj
dotnet ef migrations remove --force --context MySqlContext --startup-project ..\Web\Web.csproj

Update-Database –TargetMigration 20191010085603_SGroupMigrations008

dotnet ef database update 0 --context MySqlContext  --startup-project ..\Web\Web.csproj

dotnet ef database update <20191010085603_SGroupMigrations008>

dotnet ef migrations remove 20191014025720_DingtalkMigrations010 --context MySqlContext --startup-project ..\Web\Web.csproj