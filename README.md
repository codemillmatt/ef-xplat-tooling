# EF Core 6 Cross-Platform Tooling

Hello! And thanks for watching the EF Core 6 - Cross Platform Tooling course from Pluralsight. (And if you stumbled across this repo & want to watch the course? Head on over here to give it a whirl.)

> Remember, this course is on EF Core 6. So all the tooling, the SDKs, everything, will be based off of .NET 6.

This repository contains 4 projects that will help you follow along as you learn the course. Each project is in its own directory.

* [`api-only`](/api-only/GlobalTicket.Events.Api/) => this contains a project that you can use for migrations, optimizations, and performance
* [`api-reverse-engineer`](/api-reverse-engineer/GlobalTicket.Events.Api/) => this contains a project that you can use to reverse engineer an Azure SQL database
* [`api-with-tests`](/api-with-tests/GlobalTicket.Events/) => this contains a web api and unit test project
* [`mobile-app`](/mobile-app/) => this contains a .NET MAUI application that uses EF Core 6

## Some basic info

This course only focuses in on the tooling, not any particulars of the EF Core SDK. There are a number of other great Pluralsight courses that do that. If interested, check them out!

### EF Core 6 Pluralsight courses

* [EF Core 6 Fundamentals](https://pluralsight.pxf.io/mgWXBM)
* [EF Core 6: The Big Picture](https://pluralsight.pxf.io/x942P1)
* [Querying Data in EF Core 6](https://pluralsight.pxf.io/5b9M32)
* [EF Core 6: Best Practices](https://pluralsight.pxf.io/LPbxqa)
* [Using EF Core 6 with Azure Cosmos DB](https://pluralsight.pxf.io/9W5MPe)
* [Encapsulating EF Core 6 Usage](https://pluralsight.pxf.io/jWon3n)
* [Entire EF Core 6 Path](https://pluralsight.pxf.io/e4VrMg)

## Setup

As you learned, you'll need to do some basic setup to make sure you can follow along. That includes:

* [Installing .NET](https://dot.net)
* [Installing VS Code](https://visualstudio.com)
  * [Installing the SQLite extension](https://marketplace.visualstudio.com/items?itemName=alexcvzz.vscode-sqlite)
  * [Installing the Rainbow CSV extension](https://marketplace.visualstudio.com/items?itemName=mechatroner.rainbow-csv)
  * [Installing the CSV to table extension](https://marketplace.visualstudio.com/items?itemName=phplasma.csv-to-table)
* [Installing EF Core CLI tooling](https://learn.microsoft.com/en-us/ef/core/cli/)
* [Installing Azure Data Studio](https://learn.microsoft.com/en-us/sql/azure-data-studio/download-azure-data-studio?view=sql-server-ver16)
* [Installing .NET Counters](https://learn.microsoft.com/en-us/dotnet/core/diagnostics/dotnet-counters)
