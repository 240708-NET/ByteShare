# ByteShare

## Description:
This project is a recipe-sharing web application designed to allow users to create, read, update, and delete their own recipes, as well as share them with others, view recipes from other users, and rate their favorites. The application features data persistence for user accounts and recipes, along with secure login and logout functionality. Our team utilized a range of modern technologies, including Docker for server management, Entity Framework with a code-first approach for database operations, and ASP.NET (C#) to develop the RESTful API that communicates with a SQL database over HTTP. The frontend was built using React and Next.js with TypeScript, providing a responsive and dynamic user experience. This project showcases our team's perseverance in mastering new technologies to develop a functional and user-friendly recipe-sharing platform.

## User Stories:
- As a user, I want to create a recipe (by providing the title, description, ingredients, and instructions).
- As a user, I want to update a recipe.
- As a user, I want to read my recipes.
- As a user, I want to delete a recipe.
- As a user, I want to share my recipe with other users.
- As a user I want to rate recipes.
- As a user I want to see the recipes of other users.

## Running the application:
### Backend
The backend application is a .NET Core code-first application with MS SQL Server as the database server. In order to run the backend application data migration is required.
- To run the backend navigate to `src/Web/API` then run the command:
  - `dotnet run`.
- For data migration navigate to `src/Web/API` then run the commands:
  - `dotnet ef migrations add <migration name here>`
  - `dotnet ef database update`
  - Note:
    - The MS SQL Server should be running.
    - The connection string in `src/Web/API/appsettings.json` should be valid.
    - For fresh migrations, delete the `Migrations` folder in `src/Web/API`.
    - For fresh database updates, nuke the database using SQL above.
### Frontend
The frontend application is build using React Nextjs.
- To run it navigate to `src/Web/ClientAppAPI` then run the command:
  - `npm dev`
  - Note:
    - Run command `npm install` to install dependencies.

## Nuking a SQL Server Database (Database name is ByteShare in example):
```sql
USE [master]
GO
ALTER DATABASE [ByteShare] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
GO
USE [master]
GO
DROP DATABASE [ByteShare]
GO
```