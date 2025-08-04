# DISCLAIMED!!
Here are the following file related to the test
- 4). ShabuMemberPromotion.cs (use ChatGPT in helping connect database Postgres.
- 5). ProductStatus.cs (use ChatGPT for everything, I never use store procedure before) -> Also, not finish on time.

Required program
- IDE (Visual Studio Purple)
- PgAdmin
- Postgres

Required NuGet
- Npgsql.EntityFrameworkCore.PostgreSQL
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer (no use)

Step to run create db
- `dotnet new tool-manifest` -> this will create config cli
- `dotnet tool install dotnet-ef` -> this will install dotnet-ef cli
- `dotnet ef migrations add InitialCreate` -> this will create migration folder
- `dotnet ef database update` -> this will create database table
