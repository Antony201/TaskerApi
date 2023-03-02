# TaskerApi
## _The beautiful system for monitoring tasks_



## Installation

TaskerApi requires [dotnet](https://dotnet.microsoft.com/en-us/) v7+ to run.

Project uses the PostgreSql database.

Set env variables to configure project:
```sh
cd TaskerApi
setx SETTINGS_ConnectionStrings__WebApiDatabase 'Host=your_host; Database=your_database_name; Username=your_database_user;Password=your_database_password'
```
For development environments...

```sh
dotnet run --environment Development
```

For production environments...

```sh
dotnet run --environment Production
```



## License

MIT

**Free Software, Hell Yeah!**