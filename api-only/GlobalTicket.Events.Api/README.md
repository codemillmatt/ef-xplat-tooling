# EF Core 6 Cross Platform Tooling - Migrations, Optimizations, Debugging

Hello! Thanks for watching the Pluralsight course on EF Core 6 cross platform tooling. The project in this directory contains all the code you need in order to run the samples you've seen in the course.

> Please note: You will not be able to run the unit tests, reverse migration, or mobile app from this project. See the other folders included in this repo to do so.

_The correct NuGet packages have already been added for you._

## Install the EF Core CLI

Before you can run any EF Core migrations, make sure you have the EF Core CLI tooling installed.

```bash
dotnet tool install dotnet-ef --global --version 6.0.11
```

## Create and populate the database

1. Create your first migration

    ```bash
    dotnet ef migrations add "initial"
    ```

1. Create and update the database

    ```bash
    dotnet ef database update
    ```

1. Run the application

    ```bash
    dotnet watch
    ```

## View the database

1. Make sure you have the [SQLite viewer](https://marketplace.visualstudio.com/items?itemName=alexcvzz.vscode-sqlite) installed
1. Right click on the `events.db` file and select **Open Database**

## Create a compiled version of the model

1. The compiled version of the model will run faster, to create it:

    ```bash
    dotnet ef dbcontext optimize --output-dir Compiled
    ```

1. You may have to check the generated classes for namespace collisions and fully qualify any that are needed.
1. Uncomment line 25 in the **EventContext.cs** file to use the compiled model.

## Create database scripts

1. To create a script to update the schema of the database with based off of your app's model:

    ```bash
    dotnet ef migrations script -o migrate.sql
    ```

1. Then open up the **migrate.sql** file to see all of the SQL needed to create the database.

1. Remember, you can create scripts that are based on particular migrations by supplying the starting migration name and ending migration name as well.

    ```bash
    dotnet ef migrations script START-MIGRATION-NAME END-MIGRATION-NAME -o partial.sql
    ```
## Create a bundle to perform migrations

1. If you want to create a self-contained file to run the SQL for you (for example, if you do not have access to DBA tool or the .NET runtime is not installed on the server):

    ```bash
    dotnet ef migrations bundle --self-contained
    ```

## Debug and log to a file

1. To log to a file instead of the console go to the **EventContext.cs** file.
1. Uncomment line 9
1. Uncomment lines 18-21
1. Comment line 16
1. Uncomment lines 28-40

The logs should now be written to the CSV file and you can use tooling such as [Rainbow CSV](https://marketplace.visualstudio.com/items?itemName=mechatroner.rainbow-csv) and [CSV to Tables](https://marketplace.visualstudio.com/items?itemName=phplasma.csv-to-table) to help you view the file.

## Performance monitoring

You can use .NET Counters to monitor the health of your application.

> Note that you cannot run the .NET Counters app on Mac Silicon as of this writing.

1. Install the .NET Counters tooling

    ```bash
    dotnet tool install --global dotnet-counters
    ```

1. Run your application (most likely `dotnet run -c Release`)
1. Find the .NET process that corresponds to your application

    ```bash
    dotnet-counters ps
    ```

    Note the **PID**.

1. Attach to the process

    ```bash
    dotnet counters monitor Microsoft.EntityFrameworkCore -p <THE PID YOU NOTED>
    ```

