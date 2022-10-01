# Planthor_ClientBackEndWebApp

Inspired by our learning group - Let Den Giac Mo.

Thanks to all [contributors](https://github.com/Planthor-Team/Planthor_ClientBackEndWebApp/graphs/contributors), you're awesome and this project could not be possible without you! The goal is to build a web-application for goal-progress tracking:
- [Trung Pham](https://github.com/zovippro1996)
- [Quang Le](https://github.com/quanglegl1404)

To be updated...

## Technical stack (BE)
```
- C# v9.0
- .Net 5.0
- Entity Framework Core
- PostgreSQL
- Automapper
- ElasticSearch
- NLog
- xUnit, moq, FluentAssertions
```
## Coding standards and Naming convetions

Please carefully read the pre-defined coding standards and naming conventions then apply them while development.

[Planthor Coding Standards and Naming Conventions](Planthor%20Coding%20Standards%20and%20Naming%20Convetions.md)
## Project setup

### Prerequiste

- Visual Studio Code (recommended)
- .Net Core SDK (v5.0)
- PostgreSQL v13.2

### Package restore

- Restore nuget packages:
```
dotnet restore
```
- Install Entity Framework Core (*This command is supportingh for dotnet version 5):
```
dotnet tool install --global dotnet-ef --version 5.0.5
```

- If dotnet ef IS NOT available please execuse this command:
```
export PATH="$PATH:~/.dotnet/tools"
```

### Database creation

- After restoring the pre-defined packages and installig EF Core successfully, please try to build the project using the following command :
```
dotnet build
```

- For development purpose, run Postgre SQL (start pgAdmin) on your personal device. 
- Then navigate to appsettings.json and replace the database credentials with your credetials and excute this command:
```
dotnet ef database update
```

- Wait until the process completes, check if the database is created successfully.

- In case you want to make new Updates (Migrations) to database, run command:
```
dotnet ef migrations add <Name of Migration Record>
dotnet ef database update
```

### How to run

- Open the solution in Visual Studio Code
- Execute ```dotnet run -p src/PlanthorWebApiServer.csproj``` 
- Access to the adress provided in the command line

To Test the project
```
dotnet test
```

