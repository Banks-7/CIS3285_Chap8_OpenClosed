# CIS 3285 Chapter 8: Open-Closed Principle

This repository contains two console applications and a test project:

- **AbstractTrader** demonstrates the abstract-class version.
- **VirtualTrader** demonstrates the virtual-method version and is referenced by the tests.
- **VirtualTraderTests** contains the MSTest tests for `VirtualTrader`.

All projects target **.NET 10** (`net10.0`). Install the .NET 10 SDK and Visual Studio Code with the recommended C# Dev Kit extension to build, run, test, and debug the projects.

## Open in VS Code

Open this repository folder in VS Code. If prompted, install the recommended C# Dev Kit extension. Then use the integrated terminal for the commands below, or select a launch configuration from **Run and Debug**.

## Build and test

From the repository root:

```sh
dotnet build CIS3285_Chap8_OpenClosed.sln
dotnet test CIS3285_Chap8_OpenClosed.sln
```

## Run an application

Choose either example:

```sh
dotnet run --project AbstractTrader/AbstractTrader.csproj
dotnet run --project VirtualTrader/VirtualTrader.csproj
```

Each application waits for a key press before it exits.

## VS Code tasks and debugging

Open **Terminal > Run Task** to find tasks for building the solution, running the tests, or running either application. The **Run and Debug** view also provides launch configurations for both console applications.
