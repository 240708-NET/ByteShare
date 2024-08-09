# ByteShare
ByteShare is an application for sharing recipes.


### User stories:
- As a user I want to add my recipe by adding the description, ingredients, and instructions for it.
- As a user I want to share my recipe.
- As a user I want to search for recipes.
- As a user I want to filter searched - recipes by rating(s) and/or users, and/or follows and/or ingredients .
- As a user I want to rate recipes.
- As a user I want to follow other users.
- As a user I want to see the recipes of my follows.



# Git Command Cheat Sheet

### Cloning your remote directory:
```
git clone <remote directory>
```

### Checking that status of your local repository:
```
git status
```

### Creating a new branch for you to work on:
```
git branch <new branch name>
```

### See all branches in your remote repository:
```
git branch -a
```

### Moving onto a branch:
```
git checkout <branch name>
```

### Deleting a branch:
```
git branch -d <branch name>
```

### Moving files while preserving git history:
```
git mv <source> <destination>
```

### Nuking a SQL Server Database (Database name is ByteShare in example):
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

### Running the backend:
- Path: `src/Web/API`
- Command: `dotnet run`

### Running the frontend:
- Path: `src/Web/ClientApp`
- Command: `npm dev`
- #### Notes:
  - When running for the first time, run command `npm install` to install dependencies.

### Data migration followed by database update:
- Path: `src/Web/API`
- Migration command: `dotnet ef migrations add <migration name here>`
- Database update command: `dotnet ef database update`
- #### Notes:
  - The SQL Server docker container should be running.
  - Check and update accordingly, the connection string in `src/Web/API/appsettings.json`.
  - Delete the `Migrations` folder for a fresh migration.
  - Nuke the database (see above) for a fresh update.
