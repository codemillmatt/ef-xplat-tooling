# EF Core 6 Cross Platform Tooling - Reverse Engineering

This project will show you how to reverse engineer an Azure SQL database.

## Prerequisite

You first must have an Azure SQL database available to use. You must also have the connection string to it.

## Create the .NET Secret

1. Initialize the .NET secrets for this project

    ```bash
    dotnet user-secrets init
    ```

1. Add the SQL connection string to the user secrets

    ```bash
    dotnet user-secrets set ConnectionStrings:EventsSql "<THE VALUE OF CONNECTION STRING>"
    ```

1. Scaffold out the DbContext and Model classes

    ```bash
    dotnet ef dbcontext scaffold Name=ConnectionStrings:EventsSql Microsoft.EntityFrameworkCore.SqlServer -C EventContext --context-dir Data -o Models
    ```

1. You may want to change the created `EventContext` class so it takes the connection string in as a parameter to its constructor, instead of trying to look it up directly.

1. Uncomment the lines 30-34 in **Program.cs** and run the app.