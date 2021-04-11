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
- Install Entity Framework Core:
```
dotnet tool install --global dotnet-ef
```

### Database creation

- After restoring the pre-defined packages and installig EF Core successfully, please try to build the project using the following command:
```
dotnet build
```

- For development purpose, run Postgre SQL (start pgAdmin) on your personal device. Then navigate to appsettings.json and replace the database credentials with your credetials and excute this command:
```
dotnet ef database update
```

- Wait until the process completes, check if the database is created successfully.

### How to run

- Open the solution in Visual Studio Code
- Execute ```dotnet run``` 
- Access to the adress provided in the command line