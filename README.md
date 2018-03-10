# Illarion Server

This is the Server for the online roleplaying game [Illarion](http://illarion.org). The server is based on the
[Photon OnPremise Server](https://www.photonengine.com/en-US/OnPremise).

## Objectives

Illarion is the online multiplayer roleplaying game that is developed and maintained by the Illarion e.V.

This repository contains the sources of the game server.

## Requirements

- [Photon OnPremise Server SDK](https://www.photonengine.com/en-US/sdks#onpremiseserver) >= v4.0.29.11263
- .NET Framework 4.7
- Microsoft Visual Studio 2017
- Microsoft Windows >= 7
- [PostgreSQL Datebase](https://www.postgresql.org/)

## Build Instructions

The repository is set up to be developed and debugged with any version of Microsoft Visual Studio 2017. The build
currently required a environment variable named `PHOTON_SERVER_SDK` to be present on the system. This variable
has to point to the downloaded Photon OnPremise Server SDK directory that includes the `deploy/` and the `lib/`
directory.

Building the server and running the tests will work once the variable is present.

## Execution Instructions

Running the server requires an database to be properly set-up. For this to work a PostgreSQL Datebase needs to be
available. There are two config files related to the database.

- *Illarion.Server.Persistance.Design/IllarionServerConfig.json*

  This file contains the connection string that is used for setting up the database. The user referenced there must be
  able to access the database that is named there and it must be able to alter the database structure.

- *Illarion.Server.Photon/IllarionServerConfig.json*

  This file contains the connection string that is used for connecting the game database at runtime. The user in there
  needs to be able to access the database, read from it and write to it.

To get started with the database, the structure of the database needs to be set up. Since the server is not actively in
use right now, there is no migration for the database prepared. After building the server the package management
console of Visual Studio allows to execute the following commands:
```powershell
Add-Migration -Name Initial -Context AccountsContext -Project Illarion.Server.Persistence.Accounts.Migrations -StartupProject Illarion.Server.Persistence.Design
Add-Migration -Name Initial -Context ServerContext -Project Illarion.Server.Persistence.Server.Migrations -StartupProject Illarion.Server.Persistence.Design

Update-Database -Context AccountsContext -Project Illarion.Server.Persistence.Accounts -StartupProject Illarion.Server.Persistence.Design
Update-Database -Context ServerContext -Project Illarion.Server.Persistence.Server -StartupProject Illarion.Server.Persistence.Design
```
Doing so will create the migration for the current state of the database. Do **not** add this migration of the
repository for now. The layout for the database is not even close to be done.

After doing so the structure of the database should be present in the target database.

All classes related to the design and to updating the database are kept in isolated assemblies, to reduce the overhead
of loading the assemblies required for the database migration to the active server.